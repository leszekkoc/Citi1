using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Class <see cref="DigicoinTrader"/> declare trading options of Digicoin currency.
    /// </summary>
    public class DigicoinTrader : IDigicoinTrader
    {
        #region Fields

        private readonly IDigicoinBrokerSelector _brokers;
        private readonly ITradeRepository _trades;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initialize <see cref="DigicoinTrader"/> class.
        /// </summary>
        /// <param name="brokers">Digicoin trading brokers.</param>
        /// <param name="trades">Trades repository.</param>
        public DigicoinTrader(IDigicoinBrokerSelector brokers, ITradeRepository trades)
        {
            if (brokers == null)
            {
                throw new ArgumentNullException("brokers");
            }
            if (trades == null)
            {
                throw new ArgumentNullException("trades");
            }
            _trades = trades;
            _brokers = brokers;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Buy Digicoin.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <param name="order">Amount to buy.</param>
        /// <returns>Overall order cost, including the Broker commission.</returns>
        /// <exception cref="ArgumentException">Client name must be provided.</exception>
        /// <exception cref="ArgumentException">"Orders can only be in multiples of 10 Digicoins.</exception>
        public decimal Buy(string clientName, int order)
        {
            return Trade(clientName, TradeType.Buy, order);
        }

        /// <summary>
        /// Sell Digicoin.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <param name="order">Amount to buy.</param>
        /// <returns>Overall order cost, including the Broker commission.</returns>
        /// <exception cref="ArgumentException">Client name must be provided.</exception>
        /// <exception cref="ArgumentException">"Orders can only be in multiples of 10 Digicoins.</exception>
        public decimal Sell(string clientName, int order)
        {
            return Trade(clientName, TradeType.Sell, order);
        }

        private decimal Trade(string clientName, TradeType type, int order)
        {
            Validate(clientName, order);

            var hundreds = (int)(order / 100);
            var result = TradeHundrets(clientName, type, order, hundreds);
            result = TradeTens(clientName, type, order, hundreds, result);

            return result;
        }

        private decimal TradeTens(string clientName, TradeType type, int order, int hundreds, decimal result)
        {
            var tens = (order - hundreds * 100);
            var quote = _brokers.GetQuote(tens);
            if (quote == null)
            {
                throw new Exception(string.Format("No broker for order of {0}!", tens));
            }
            if (quote.Value > 0)
            {
                result += quote.Value;
                _trades.Add(clientName, quote.Broker, type, tens, quote.Value);
            }

            return result;
        }

        private decimal TradeHundrets(string clientName, TradeType type, int order, int hundreds)
        {
            decimal result = 0;
            var quote = _brokers.GetQuote(100);
            if (quote == null)
            {
                throw new Exception("No broker for order of 100!");
            }
            for (int i = 0 ; i < hundreds ; i++)
            {
                result += quote.Value;
                _trades.Add(clientName, quote.Broker, type, 100, quote.Value);
            }

            return result;
        }

        private void Validate(string clientName, int order)
        {
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name must be provided!");
            }
            if (order % 10 != 0)
            {
                throw new ArgumentException("Orders can only be in multiples of 10 Digicoins!");
            }
        }

        #endregion Methods
    }
}
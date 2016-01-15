using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Class <see cref="DigicoinReports"/> declare reports for Digicoin trades.
    /// </summary>
    public class DigicoinReports : IDigicoinReports
    {
        #region Fields

        private readonly ITradeRepository _trades;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initialize <see cref="DigicoinReports"/> class.
        /// </summary>
        /// <param name="trades">Trades repository.</param>
        public DigicoinReports(ITradeRepository trades)
        {
            if (trades == null)
            {
                throw new ArgumentNullException("trades");
            }
            _trades = trades;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Generate client net position report.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <returns>Returns null when not client trades.</returns>
        public decimal? ClientNetPosition(string clientName)
        {
            // "The calculation is wrong. I have contact Bartosz to provide correct logic of the calculation but: quote 'As for the calculation I don’t know the definite answer but it doesn’t really matter, it’s the structure and code that are relevant.'
            var trades = _trades.GetAllBy(clientName);
            if (trades != null && trades.Count() > 0)
            {
                decimal result = 0;
                foreach (var item in trades)
                {
                    if (item.Type == TradeType.Sell)
                    {
                        result -= item.Value;
                    }
                    else
                    {
                        result += item.Value;
                    }
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// Generate broker transactions report.
        /// </summary>
        /// <param name="broker">Broker.</param>
        /// <returns>Returns null when not broker trades.</returns>
        public int? BrokerTransactions(IDigicoinBroker broker)
        {
            var trades = _trades.GetAllBy(broker);
            if (trades != null && trades.Count() > 0)
            {
                int result = 0;
                foreach (var item in trades)
                {
                    result += item.Order;
                }
                return result;
            }
            return null;
        }

        #endregion Methods
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Class <see cref="TradeRepository"/> declare trade repository.
    /// </summary>
    public class TradeRepository : ITradeRepository
    {
        #region Fields

        // repository as we do not have database
        private readonly List<Trade> _trades = new List<Trade>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Adds new trade to repository.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <param name="broker">Broker.</param>
        /// <param name="type">Trade type.</param>
        /// <param name="order">Trade order.</param>
        /// <param name="value">Trade value.</param>
        /// <exception cref="ArgumentException">Client name must be provided.</exception>
        /// <exception cref="ArgumentException">Broker must be provided.</exception>
        public void Add(string clientName, IDigicoinBroker broker, TradeType type, int order, decimal value)
        {
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name must be provided!");
            }
            if (broker == null)
            {
                throw new ArgumentException("Broker must be provided!");
            }
            var trade = new Trade(clientName, broker, type, order, value);
            _trades.Add(trade);
        }

        /// <summary>
        /// Gets all trades of client.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <returns>All client trades.</returns>
        public IEnumerable<ITrade> GetAllBy(string clientName)
        {
            return _trades.Where(x => x.ClientName == clientName).OfType<ITrade>();
        }

        /// <summary>
        /// Gets all trades of broker.
        /// </summary>
        /// <param name="broker">Broker.</param>
        /// <returns>All broker trades.</returns>
        public IEnumerable<ITrade> GetAllBy(IDigicoinBroker broker)
        {
            return _trades.Where(x => x.Broker == broker).OfType<ITrade>();
        }

        #endregion Methods
    }
}
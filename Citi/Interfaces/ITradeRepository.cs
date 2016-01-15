using System.Collections.Generic;
using System.Linq;

namespace Citi
{
    /// <summary>
    /// Interface <see cref="ITradeRepository"/> define trade repository.
    /// </summary>
    public interface ITradeRepository
    {
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
        void Add(string clientName, IDigicoinBroker broker, TradeType type, int order, decimal value);

        /// <summary>
        /// Gets all trades of client.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <returns>All client trades.</returns>
        IEnumerable<ITrade> GetAllBy(string clientName);

        /// <summary>
        /// Gets all trades of broker.
        /// </summary>
        /// <param name="broker">Broker.</param>
        /// <returns>All broker trades.</returns>
        IEnumerable<ITrade> GetAllBy(IDigicoinBroker broker);
    }
}
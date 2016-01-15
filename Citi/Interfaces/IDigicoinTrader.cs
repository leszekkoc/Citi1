namespace Citi
{
    /// <summary>
    /// Interface <see cref="IDigicoinTrader"/> define trading options of Digicoin currency.
    /// </summary>
    public interface IDigicoinTrader
    {
        /// <summary>
        /// Buy Digicoin.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <param name="order">Amount to buy.</param>
        /// <returns>Overall order cost, including the Broker commission.</returns>
        /// <exception cref="ArgumentException">Client name must be provided.</exception>
        /// <exception cref="ArgumentException">"Orders can only be in multiples of 10 Digicoins.</exception>
        decimal Buy(string clientName, int order);

        /// <summary>
        /// Sell Digicoin.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <param name="order">Amount to buy.</param>
        /// <returns>Overall order cost, including the Broker commission.</returns>
        /// <exception cref="ArgumentException">Client name must be provided.</exception>
        /// <exception cref="ArgumentException">"Orders can only be in multiples of 10 Digicoins.</exception>
        decimal Sell(string clientName, int order);
    }
}
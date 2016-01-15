namespace Citi
{
    /// <summary>
    /// Interface <see cref="IDigicoinReports"/> define reports for Digicoin trades.
    /// </summary>
    public interface IDigicoinReports
    {
        /// <summary>
        /// Generate client net position report.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        /// <returns>Returns null when not client trades.</returns>
        decimal? ClientNetPosition(string clientName);

        /// <summary>
        /// Generate broker transactions report.
        /// </summary>
        /// <param name="broker">Broker.</param>
        /// <returns>Returns null when not broker trades.</returns>
        int? BrokerTransactions(IDigicoinBroker broker);
    }
}
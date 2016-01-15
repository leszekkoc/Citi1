namespace Citi
{
    /// <summary>
    /// Interface <see cref="ITrade"/> define single trade.
    /// </summary>
    public interface ITrade
    {
        /// <summary>
        /// Client name.
        /// </summary>
        string ClientName { get; }

        /// <summary>
        /// Broker.
        /// </summary>
        IDigicoinBroker Broker { get; }

        /// <summary>
        /// Trade order.
        /// </summary>
        int Order { get; }

        /// <summary>
        /// Trade value.
        /// </summary>
        decimal Value { get; }

        /// <summary>
        /// Trade type.
        /// </summary>
        TradeType Type { get; }
    }
}
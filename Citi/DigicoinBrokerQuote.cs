namespace Citi
{
    /// <summary>
    /// Class <see cref="IDigicoinBrokerQuote"/> declare broker and quote value pair model.
    /// </summary>
    internal class DigicoinBrokerQuote : IDigicoinBrokerQuote
    {
        #region Properties

        /// <summary>
        /// Broker.
        /// </summary>
        public IDigicoinBroker Broker { get; private set; }

        /// <summary>
        /// Quote value.
        /// </summary>
        public decimal Value { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize <see cref="DigicoinBrokerQuote"/> class.
        /// </summary>
        /// <param name="broker"></param>
        /// <param name="value"></param>
        public DigicoinBrokerQuote(IDigicoinBroker broker, decimal value)
        {
            Broker = broker;
            Value = value;
        }

        #endregion Constructors
    }
}
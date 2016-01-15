using System;
using System.Collections.Generic;

namespace Citi
{
    /// <summary>
    /// Class <see cref="DigicoinBrokerSelector"/> declare provider of trading broker for Digicoin operations.
    /// </summary>
    public class DigicoinBrokerSelector : IDigicoinBrokerSelector
    {
        #region Fields

        private Dictionary<int, IDigicoinBrokerQuote> _brokers;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initialize <see cref="DigicoinBrokerSelector"/> class.
        /// </summary>
        /// <param name="brokers">Digicoin trading brokers.</param>
        public DigicoinBrokerSelector(IDigicoinBroker[] brokers)
        {
            if (brokers == null)
            {
                throw new ArgumentNullException("brokers");
            }
            _brokers = new Dictionary<int, IDigicoinBrokerQuote>();
            _brokers.Add(0, new DigicoinBrokerQuote(null, 0));

            Initialize(brokers);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets best broker quote for order.
        /// </summary>
        /// <param name="order">Order.</param>
        /// <returns>Returns best Digicoin broker quote.</returns>
        public IDigicoinBrokerQuote GetQuote(int order)
        {
            if (_brokers.ContainsKey(order))
            {
                return _brokers[order];
            }
            return null;
        }

        private void Initialize(IDigicoinBroker[] brokers)
        {
            for (int i = 1 ; i <= 10 ; i++)
            {
                IDigicoinBrokerQuote quote = null;

                for (int b = 0 ; b < brokers.Length ; b++)
                {
                    var q = brokers[b].GetQuote(i * 10);
                    if (q.HasValue && (quote == null || quote.Value > q.Value))
                    {
                        quote = new DigicoinBrokerQuote(brokers[b], q.Value);
                    }
                }

                if (quote != null)
                {
                    _brokers.Add(i * 10, quote);
                }
            }
        }

        #endregion Methods
    }
}
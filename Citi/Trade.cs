using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Class <see cref="Trade"/> declare single trade.
    /// </summary>
    public struct Trade : ITrade
    {
        #region Properties

        //List<DigicoinTrade>
        /// <summary>
        /// Client name.
        /// </summary>
        public string ClientName { get; private set; }

        /// <summary>
        /// Broker.
        /// </summary>
        public IDigicoinBroker Broker { get; private set; }

        /// <summary>
        /// Trade order.
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Trade value.
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Trade type.
        /// </summary>
        public TradeType Type { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize <see cref="Trade"/> class.
        /// </summary>
        /// <param name="clientName">Client name.</param>
        public Trade(string clientName, IDigicoinBroker broker, TradeType type, int order, decimal value)
        {
            ClientName = clientName;
            Broker = broker;
            Type = type;
            Order = order;
            Value = value;
        }

        #endregion Constructors
    }
}
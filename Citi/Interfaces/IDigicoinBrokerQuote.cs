using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Interface <see cref="IDigicoinBrokerQuote"/> define broker and quote value pair model.
    /// </summary>
    public interface IDigicoinBrokerQuote
    {
        /// <summary>
        /// Broker.
        /// </summary>
        IDigicoinBroker Broker { get; }

        /// <summary>
        /// Quote value.
        /// </summary>
        decimal Value { get; }
    }
}
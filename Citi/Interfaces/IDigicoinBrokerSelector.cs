using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Interface <see cref="IDigicoinBrokerSelector"/> define provider of trading broker for Digicoin operations.
    /// </summary>
    public interface IDigicoinBrokerSelector
    {
        /// <summary>
        /// Gets best broker quote for order.
        /// </summary>
        /// <param name="order">Order.</param>
        /// <returns>Returns best Digicoin broker quote.</returns>
        IDigicoinBrokerQuote GetQuote(int order);
    }
}
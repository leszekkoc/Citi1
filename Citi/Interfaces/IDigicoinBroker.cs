using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi
{
    /// <summary>
    /// Interface <see cref="IDigicoinBroker"/> define trading broker for Digicoin operations.
    /// </summary>
    public interface IDigicoinBroker
    {
        #region Properties

        ///// <summary>
        ///// Quote per Digicoin.
        ///// </summary>
        //decimal Quote { get; }

        #endregion Properties

        #region Methods

        ///// <summary>
        ///// Gets commission per order volume.
        ///// </summary>
        ///// <param name="order">Order volume.</param>
        ///// <returns></returns>
        //decimal GetCommission(int order);

        /// <summary>
        /// Gets commission per order volume.
        /// </summary>
        /// <param name="order">Order volume.</param>
        /// <returns>Overall order cost, including the Broker commission.</returns>
        decimal? GetQuote(int order);

        #endregion Methods
    }
}
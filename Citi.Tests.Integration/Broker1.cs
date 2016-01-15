using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi.Tests.Integration
{
    internal class Broker1 : IDigicoinBroker
    {
        public decimal? GetQuote(int order)
        {
            return order * 1.49M * 1.05M;
        }
    }
}
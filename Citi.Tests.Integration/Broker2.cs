using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi.Tests.Integration
{
    internal class Broker2 : IDigicoinBroker
    {
        public decimal? GetQuote(int order)
        {
            switch (order)
            {
                case 10:
                case 20:
                case 30:
                case 40:
                    return order * 1.52M * 1.03M;

                case 50:
                case 60:
                case 70:
                case 80:
                    return order * 1.52M * 1.025M;

                case 90:
                case 100:
                    return order * 1.52M * 1.02M;
            }
            return null;
        }
    }
}
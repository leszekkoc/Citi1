using Citi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi.Tests.Integration
{
    [TestClass()]
    public class DigicoinTraderTests
    {
        private IDigicoinBroker _broker1 = new Broker1();
        private IDigicoinBroker _broker2 = new Broker2();
        private IDigicoinBrokerSelector _brokers;
        private ITradeRepository _trades;
        private DigicoinTrader _trader;

        [TestInitialize]
        public void Initalize()
        {
            _brokers = new DigicoinBrokerSelector(new IDigicoinBroker[] { _broker1, _broker2 });
            _trades = new TradeRepository();
            _trader = new DigicoinTrader(_brokers, _trades);
        }

        [TestMethod()]
        public void Buy_10_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 10);

            Assert.AreEqual(15.645M, result);
        }

        [TestMethod()]
        public void Buy_40_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 40);

            Assert.AreEqual(62.58M, result);
        }

        [TestMethod()]
        public void Buy_50_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 50);

            Assert.AreEqual(77.9M, result);
        }

        [TestMethod()]
        public void Buy_100_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 100);

            Assert.AreEqual(155.04M, result);
        }

        [TestMethod()]
        public void Buy_80_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 80);

            Assert.AreEqual(124.64M, result);
        }

        [TestMethod()]
        public void Buy_70_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 70);

            Assert.AreEqual(109.06M, result);
        }

        [TestMethod()]
        public void Buy_130_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 130);

            Assert.AreEqual(201.975M, result);
        }

        [TestMethod()]
        public void Buy_60_ReturnsValue()
        {
            var result = _trader.Buy("Client A", 60);

            Assert.AreEqual(93.48M, result);
        }
    }
}
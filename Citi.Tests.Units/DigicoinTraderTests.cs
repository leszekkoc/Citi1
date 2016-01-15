using Citi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citi.Tests.Units
{
    [TestClass()]
    public class DigicoinTraderTests
    {
        private DigicoinTrader _trader;
        private IDigicoinBrokerSelector _brokers;
        private ITradeRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _brokers = Substitute.For<IDigicoinBrokerSelector>();
            _repository = Substitute.For<ITradeRepository>();
            _trader = new DigicoinTrader(_brokers, _repository);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Client name must be provided!")]
        public void Buy_UserNameIsEmpty_ThrowsException()
        {
            _trader.Buy("", 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Orders can only be in multiples of 10 Digicoins!")]
        public void Buy_OrderIsNotMultipleOf10_ThrowsException()
        {
            _trader.Buy("Client Name", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Client name must be provided!")]
        public void Sell_UserNameIsEmpty_ThrowsException()
        {
            _trader.Sell("", 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Orders can only be in multiples of 10 Digicoins!")]
        public void Sell_OrderIsNotMultipleOf10_ThrowsException()
        {
            _trader.Sell("Client Name", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "No broker for order of 100!")]
        public void Sell_HundredsBrokerIsNull_ThrowsException()
        {
            _brokers.GetQuote(100).Returns(default(IDigicoinBrokerQuote));

            _trader.Sell("Client Name", 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "No broker for order of 10!")]
        public void Sell_TensBrokerIsNull_ThrowsException()
        {
            _brokers.GetQuote(10).Returns(default(IDigicoinBrokerQuote));

            _trader.Sell("Client Name", 10);
        }

        [TestMethod()]
        public void Sell_HundredsBrokerExists_ReturnsValue()
        {
            var quote = Substitute.For<IDigicoinBrokerQuote>();
            quote.Value.Returns(200);
            _brokers.GetQuote(100).Returns(quote);

            var result = _trader.Sell("Client Name", 100);

            Assert.AreEqual(200, result);
        }

        [TestMethod()]
        public void Sell_TensBrokerExists_ReturnsValue()
        {
            var quote = Substitute.For<IDigicoinBrokerQuote>();
            quote.Value.Returns(20);
            _brokers.GetQuote(10).Returns(quote);

            var result = _trader.Sell("Client Name", 10);

            Assert.AreEqual(20, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "No broker for order of 100!")]
        public void Buy_HundredsBrokerIsNull_ThrowsException()
        {
            _brokers.GetQuote(100).Returns(default(IDigicoinBrokerQuote));

            _trader.Buy("Client Name", 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "No broker for order of 10!")]
        public void Buy_TensBrokerIsNull_ThrowsException()
        {
            _brokers.GetQuote(10).Returns(default(IDigicoinBrokerQuote));

            _trader.Buy("Client Name", 10);
        }

        [TestMethod()]
        public void Buy_HundredsBrokerExists_ReturnsValue()
        {
            var quote = Substitute.For<IDigicoinBrokerQuote>();
            quote.Value.Returns(200);
            _brokers.GetQuote(100).Returns(quote);

            var result = _trader.Buy("Client Name", 100);

            Assert.AreEqual(200, result);
        }

        [TestMethod()]
        public void Buy_TensBrokerExists_ReturnsValue()
        {
            var quote = Substitute.For<IDigicoinBrokerQuote>();
            quote.Value.Returns(20);
            _brokers.GetQuote(10).Returns(quote);

            var result = _trader.Buy("Client Name", 10);

            Assert.AreEqual(20, result);
        }
    }
}
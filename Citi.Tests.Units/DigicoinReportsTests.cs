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
    public class DigicoinReportsTests
    {
        private string clientName = "client name";
        private ITradeRepository _trades;
        private DigicoinReports _reports;

        [TestInitialize]
        public void Initialization()
        {
            _trades = Substitute.For<ITradeRepository>();
            _reports = new DigicoinReports(_trades);
        }

        [TestMethod()]
        public void ClientNetPosition_NoClientTrades_ReturnsNull()
        {
            var result = _reports.ClientNetPosition(clientName);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void ClientNetPosition_OneSellTrade_ReturnsValue()
        {
            var trade = Substitute.For<ITrade>();
            trade.Value.Returns(10);
            trade.Type.Returns(TradeType.Sell);

            _trades.GetAllBy(clientName).Returns(new ITrade[] { trade });

            var result = _reports.ClientNetPosition(clientName);

            Assert.AreEqual(-10, result);
        }

        [TestMethod()]
        public void ClientNetPosition_OneBuyTrade_ReturnsValue()
        {
            var trade = Substitute.For<ITrade>();
            trade.Value.Returns(10);
            trade.Type.Returns(TradeType.Buy);

            _trades.GetAllBy(clientName).Returns(new ITrade[] { trade });

            var result = _reports.ClientNetPosition(clientName);

            Assert.AreEqual(10, result);
        }

        [TestMethod()]
        public void ClientNetPosition_OneBuyAndOneSellTrade_ReturnsValue()
        {
            var trade1 = Substitute.For<ITrade>();
            trade1.Value.Returns(40);
            trade1.Type.Returns(TradeType.Sell);

            var trade2 = Substitute.For<ITrade>();
            trade2.Value.Returns(50);
            trade2.Type.Returns(TradeType.Buy);

            _trades.GetAllBy(clientName).Returns(new ITrade[] { trade1, trade2 });

            var result = _reports.ClientNetPosition(clientName);

            Assert.AreEqual(10, result);
        }

        [TestMethod()]
        public void ClientNetPosition_ComplexTrades_ReturnsValue()
        {
            var trade1 = Substitute.For<ITrade>();
            trade1.Value.Returns(124.64M);
            trade1.Type.Returns(TradeType.Sell);

            var trade2 = Substitute.For<ITrade>();
            trade2.Value.Returns(62.58M);
            trade2.Type.Returns(TradeType.Buy);

            var trade3 = Substitute.For<ITrade>();
            trade3.Value.Returns(93.48M);
            trade3.Type.Returns(TradeType.Sell);

            var trade4 = Substitute.For<ITrade>();
            trade4.Value.Returns(155.04M);
            trade4.Type.Returns(TradeType.Buy);

            _trades.GetAllBy(clientName).Returns(new ITrade[] { trade1, trade2, trade3, trade4 });

            var result = _reports.ClientNetPosition(clientName);

            Assert.AreEqual(0, result, "It will fail while the calculation is wrong. I have contact Bartosz to provide correct logic of the calculation but: quote 'As for the calculation I don’t know the definite answer but it doesn’t really matter, it’s the structure and code that are relevant.'");
        }

        [TestMethod()]
        public void BrokerTransactions_NoBrokerTrades_ReturnsNull()
        {
            var broker = Substitute.For<IDigicoinBroker>();

            var result = _reports.BrokerTransactions(broker);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void BrokerTransactions_OneBuyAndOneSellTrade_ReturnsValue()
        {
            var broker = Substitute.For<IDigicoinBroker>();

            var trade1 = Substitute.For<ITrade>();
            trade1.Order.Returns(40);
            trade1.Type.Returns(TradeType.Sell);

            var trade2 = Substitute.For<ITrade>();
            trade2.Order.Returns(50);
            trade2.Type.Returns(TradeType.Buy);

            _trades.GetAllBy(broker).Returns(new ITrade[] { trade1, trade2 });

            var result = _reports.BrokerTransactions(broker);

            Assert.AreEqual(90, result);
        }
    }
}
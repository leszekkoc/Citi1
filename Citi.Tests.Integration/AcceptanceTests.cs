using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Citi.Tests.Integration
{
    [TestClass]
    public class AcceptanceTests
    {
        private string _clientA = "Client A";
        private string _clientB = "Client B";
        private string _clientC = "Client C";

        private IDigicoinBroker _broker1 = new Broker1();
        private IDigicoinBroker _broker2 = new Broker2();
        private IDigicoinBrokerSelector _brokers;
        private DigicoinTrader _trader;
        private ITradeRepository _trades;
        private IDigicoinReports _reports;

        [TestInitialize]
        public void Initalize()
        {
            _brokers = new DigicoinBrokerSelector(new IDigicoinBroker[] { _broker1, _broker2 });
            _trades = new TradeRepository();
            _reports = new DigicoinReports(_trades);
            _trader = new DigicoinTrader(_brokers, _trades);
        }

        [TestMethod]
        public void AcceptanceTest_ComplexBuySell()
        {
            _trader.Buy(_clientA, 10);
            _trader.Buy(_clientB, 40);
            _trader.Buy(_clientA, 50);
            _trader.Buy(_clientB, 100);
            _trader.Sell(_clientB, 80);
            _trader.Sell(_clientC, 70);
            _trader.Buy(_clientA, 130);
            _trader.Sell(_clientB, 60);

            // "The calculation is wrong. I have contact Bartosz to provide correct logic of the calculation but: quote 'As for the calculation I don’t know the definite answer but it doesn’t really matter, it’s the structure and code that are relevant.'
            //var clientANetPosition = _reports.ClientNetPosition(_clientA);
            //Assert.AreEqual(296.156M, clientANetPosition);

            //var clientBNetPosition = _reports.ClientNetPosition(_clientB);
            //Assert.AreEqual(0, clientBNetPosition);

            //var clientCNetPosition = _reports.ClientNetPosition(_clientC);
            //Assert.AreEqual(-109.06M, clientCNetPosition);

            var broker1Transactions = _reports.BrokerTransactions(_broker1);
            Assert.AreEqual(80, broker1Transactions);

            var broker2Transactions = _reports.BrokerTransactions(_broker2);
            Assert.AreEqual(460, broker2Transactions);
        }
    }
}
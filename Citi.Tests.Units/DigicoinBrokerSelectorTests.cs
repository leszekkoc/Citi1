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
    public class DigicoinBrokerSelectorTests
    {
        private IDigicoinBroker _brokerA;
        private IDigicoinBroker _brokerB;
        private DigicoinBrokerSelector _selector;

        [TestInitialize]
        public void Initialize()
        {
            _brokerA = Substitute.For<IDigicoinBroker>();
            _brokerB = Substitute.For<IDigicoinBroker>();
        }

        [TestMethod()]
        public void Initialize_NoBrokerForOrder_SetNull()
        {
            _brokerA.GetQuote(10).Returns(default(decimal?));
            _brokerB.GetQuote(10).Returns(default(decimal?));

            _selector = new DigicoinBrokerSelector(new IDigicoinBroker[] { _brokerA, _brokerB });

            var result = _selector.GetQuote(10);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void Initialize_OneBrokerForOrder_SetQuote()
        {
            _brokerA.GetQuote(10).Returns(10M);
            _brokerB.GetQuote(10).Returns(default(decimal?));

            _selector = new DigicoinBrokerSelector(new IDigicoinBroker[] { _brokerA, _brokerB });

            var result = _selector.GetQuote(10);

            Assert.AreEqual(_brokerA, result.Broker);
            Assert.AreEqual(10M, result.Value);
        }

        [TestMethod()]
        public void Initialize_TwoBrokerForOrder_DoNotReplaceSmallerQuote()
        {
            _brokerA.GetQuote(10).Returns(10M);
            _brokerB.GetQuote(10).Returns(20M);

            _selector = new DigicoinBrokerSelector(new IDigicoinBroker[] { _brokerA, _brokerB });

            var result = _selector.GetQuote(10);

            Assert.AreEqual(_brokerA, result.Broker);
            Assert.AreEqual(10M, result.Value);
        }

        [TestMethod()]
        public void Initialize_TwoBrokerForOrder_DoReplaceBiggerQuote()
        {
            _brokerA.GetQuote(10).Returns(20M);
            _brokerB.GetQuote(10).Returns(10M);

            _selector = new DigicoinBrokerSelector(new IDigicoinBroker[] { _brokerA, _brokerB });

            var result = _selector.GetQuote(10);

            Assert.AreEqual(_brokerB, result.Broker);
            Assert.AreEqual(10M, result.Value);
        }
    }
}
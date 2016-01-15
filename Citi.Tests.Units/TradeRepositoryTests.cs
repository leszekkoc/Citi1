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
    public class TradeRepositoryTests
    {
        private TradeRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new TradeRepository();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Client name must be provided!")]
        public void Add_ClientNameIsNull_ThrowsException()
        {
            var broker = Substitute.For<IDigicoinBroker>();

            _repository.Add(null, broker, TradeType.Buy, 10, 13);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Broker must be provided!")]
        public void Add_BrokerIsNull_ThrowsException()
        {
            _repository.Add("Client name", null, TradeType.Buy, 10, 13);
        }

        [TestMethod()]
        public void Add_CorrectInput_Success()
        {
            var broker = Substitute.For<IDigicoinBroker>();

            _repository.Add("client namr", broker, TradeType.Buy, 10, 13);
        }
    }
}
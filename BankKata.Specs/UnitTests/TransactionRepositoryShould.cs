using System;
using BankKata.Clock;
using BankKata.Model;
using Moq;
using NUnit.Framework;

namespace BankKata.Specs.UnitTests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private readonly DateTime _Today = new DateTime(2015, 8, 24);
        private  Mock<IClock> _Clock;
        private TransactionRepository _TransactionRepository;

        [TestFixtureSetUp]
        public void Initialize()
        {
            _Clock = new Mock<IClock>();
            _TransactionRepository = new TransactionRepository(_Clock.Object);
        }

        [Test]
        public void CreateAndStoreADepositTransaction()
        {
            _Clock.Setup(a => a.Today()).Returns(_Today);
            _TransactionRepository.AddDeposit(1000m);

            Assert.AreEqual(1, _TransactionRepository.AllTransactions().Count);
            Assert.AreEqual(GetTransaction(1000, _Today),
                _TransactionRepository.AllTransactions()[0]);
        }

        [Test]
        public void CreateAndStoreAWithdrawalTransaction()
        {
            _Clock.Setup(a => a.Today()).Returns(_Today);
            _TransactionRepository.AddWithdrawal(500m);

            Assert.AreEqual(1, _TransactionRepository.AllTransactions().Count);
            Assert.AreEqual(GetTransaction(-500m, _Today),
                _TransactionRepository.AllTransactions()[0]);
        }

        private static Transaction GetTransaction(decimal amount, DateTime date)
        {
            return new Transaction {Amount = amount, Date = date};
        }
    }
}

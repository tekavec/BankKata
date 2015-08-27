using System;
using BankKata.Model;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private readonly DateTime _Today = new DateTime(2015, 8, 24);
        private TransactionRepository _TransactionRepository;

        [TestFixtureSetUp]
        public void Initialize()
        {
            _TransactionRepository = new TransactionRepository();
        }

        [TearDown]
        public void Cleanup()
        {
            _TransactionRepository = new TransactionRepository();
        }

        [Test]
        public void StoreATransaction()
        {
            var transaction = GetTransaction(new Money(1000m), _Today);

            _TransactionRepository.Add(transaction);

            Assert.AreEqual(1, _TransactionRepository.AllTransactions().Count);
            Assert.AreEqual(GetTransaction(new Money(1000m), _Today),
                _TransactionRepository.AllTransactions()[0]);
        }

        private static Transaction GetTransaction(Money money, DateTime date)
        {
            return new Transaction {Money = money, Date = date};
        }
    }
}

using System.Collections.Generic;
using BankKata.Model;
using BankKata.Printer;
using Moq;
using NUnit.Framework;

namespace BankKata.Specs.UnitTests
{
    [TestFixture]
    public class AccountShould
    {
        private Mock<ITransactionRepository> _TransactionRepository;
        private Mock<IStatementPrinter> _StatementPrinter;

        private Account _Account;

        [TestFixtureSetUp]
        public void Initialize()
        {
            _TransactionRepository = new Mock<ITransactionRepository>();
            _StatementPrinter = new Mock<IStatementPrinter>();
            _Account = new Account(_TransactionRepository.Object, _StatementPrinter.Object);
        }

        [Test]
        public void StoreAWithdraw()
        {
            _Account.Withdraw(500);

            _TransactionRepository.Verify(a => a.AddWithdrawal(500m));
        }

        [Test]
        public void PrintAStatement()
        {
            IList<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction());
            _TransactionRepository.Setup(a => a.AllTransactions()).Returns(transactions);

            _Account.PrintStatement();

            _StatementPrinter.Verify(a => a.Print(transactions));
        }
    }
}

using System;
using System.Collections.Generic;
using BankKata.Clock;
using BankKata.Model;
using BankKata.Printer;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class AccountShould
    {
        private readonly DateTime _Today = new DateTime(2015, 8, 24);
        private Mock<ITransactionRepository> _TransactionRepository;
        private Mock<IStatementPrinter> _StatementPrinter;
        private Mock<IClock> _Clock;

        private Account _Account;

        [TestFixtureSetUp]
        public void Initialize()
        {
            _Clock = new Mock<IClock>();
            _TransactionRepository = new Mock<ITransactionRepository>();
            _StatementPrinter = new Mock<IStatementPrinter>();
            _Account = new Account(_TransactionRepository.Object, _StatementPrinter.Object, _Clock.Object);
        }

        [Test]
        public void StoreADeposit()
        {
            var transaction = GetTransaction(500m, _Today);
            _Clock.Setup(a => a.Today()).Returns(_Today);

            _Account.Deposit(500);

            _TransactionRepository.Verify(a => a.Add(transaction));
        }

        [Test]
        public void StoreAWithdraw()
        {
            var transaction = GetTransaction(-500m, _Today);
            _Clock.Setup(a => a.Today()).Returns(_Today);

            _Account.Withdraw(500);

            _TransactionRepository.Verify(a => a.Add(transaction));
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


        private static Transaction GetTransaction(decimal amount, DateTime date)
        {
            return new Transaction { Amount = amount, Date = date };
        }
    }
}

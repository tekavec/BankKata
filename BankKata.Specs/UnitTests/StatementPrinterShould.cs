using System;
using System.Collections.Generic;
using BankKata.Console;
using BankKata.Model;
using BankKata.Printer;
using Moq;
using NUnit.Framework;

namespace BankKata.Specs.UnitTests
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private Mock<IBankConsole> _Console;
        private StatementPrinter _StatementPrinter;
        private string _StatementHeader = "| Date | Amount | Balance";

        [TestFixtureSetUp]
        public void Initialize()
        {
            _Console = new Mock<IBankConsole>();
            _StatementPrinter = new StatementPrinter(_Console.Object);
        }

        [Test]
        public void PrintAHeader()
        {
            _StatementPrinter.PrintHeader();

            _Console.Verify(a => a.WriteLine(_StatementHeader));
        }

        [Test]
        public void PrintTransactionsInAReverseChronologicalOrder()
        {
            IList<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction { Amount = 1000m, Date = new DateTime(2012, 1, 10) });
            transactions.Add(new Transaction { Amount = -500m, Date = new DateTime(2012, 1, 14) });
            transactions.Add(new Transaction { Amount = 2000m, Date = new DateTime(2012, 1, 13) });

            _StatementPrinter.Print(transactions);

            _Console.Verify(a => a.WriteLine(_StatementHeader));
            _Console.Verify(a => a.WriteLine("| 14/01/2012 | -500.00 | 2,500.00"));
            _Console.Verify(a => a.WriteLine("| 13/01/2012 | 2,000.00 | 3,000.00"));
            _Console.Verify(a => a.WriteLine("| 10/01/2012 | 1,000.00 | 1,000.00"));
        }

    }
}

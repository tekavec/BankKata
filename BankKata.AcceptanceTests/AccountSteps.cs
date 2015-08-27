using System;
using System.Globalization;
using System.Text;
using BankKata.Clock;
using BankKata.Console;
using BankKata.Model;
using BankKata.Printer;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BankKata.AcceptanceTests
{
    [Binding]
    public class AccountSteps
    {
        private Mock<IClock> _Clock;
        private ITransactionRepository _TransactionRepository;
        private IStatementPrinter _StatementPrinter;
        private Account _Account;
        private Mock<IBankConsole> _Console;
        private readonly IFormatProvider _Culture = new CultureInfo("en-GB", true);

        [Given(@"that account is created")]
        public void GivenThatAccountIsCreated()
        {
            _Clock = new Mock<IClock>();
            _Console = new Mock<IBankConsole>();
            _TransactionRepository = new TransactionRepository();
            _StatementPrinter = new StatementPrinter(_Console.Object);
            _Account = new Account(_TransactionRepository, _StatementPrinter, _Clock.Object);
        }

        [Given(@"a client makes a deposit of (.*) on '(.*)'")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
            _Clock.Setup(a => a.Today()).Returns(Convert.ToDateTime(date, _Culture));

            _Account.Deposit(amount);
        }

        [Given(@"a deposit of (.*) on '(.*)'")]
        public void GivenADepositOfOn(decimal amount, string date)
        {
            _Clock.Setup(a => a.Today()).Returns(Convert.ToDateTime(date, _Culture));

            _Account.Deposit(amount);
        }

        [Given(@"a withdrawal of (.*) on '(.*)'")]
        public void GivenAWithdrawalOfOn(decimal amount, string date)
        {
            _Clock.Setup(a => a.Today()).Returns(Convert.ToDateTime(date, _Culture));

            _Account.Withdraw(amount);
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            _Account.PrintStatement();
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(Table table)
        {
            var header = new StringBuilder();
            foreach (var item in table.Header)
            {
                header.Append(string.Format("| {0} ", item));
            }
            var headerLine = header.ToString().Trim();
            var expectedStatementLines = table.CreateSet<StatementLine>();
            //TODO Sequence!
            _Console.Verify(c => c.WriteLine(headerLine));
            foreach (var expectedStatementLine in expectedStatementLines)
            {
                var statementLine = string.Format("| {0} | {1} | {2}",
                    Convert.ToDateTime(expectedStatementLine.Date, _Culture).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    expectedStatementLine.Amount.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    expectedStatementLine.Balance.ToString("#,##0.00", CultureInfo.InvariantCulture));
                _Console.Verify(c => c.WriteLine(statementLine));
            }
        }
    }

    public class StatementLine
    {
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}

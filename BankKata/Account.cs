using BankKata.Clock;
using BankKata.Model;
using BankKata.Printer;

namespace BankKata
{
    public class Account
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IStatementPrinter _StatementPrinter;
        private readonly IClock _Clock;

        public Account(
            ITransactionRepository transactionRepository, 
            IStatementPrinter statementPrinter, 
            IClock clock)
        {
            _Clock = clock;
            _TransactionRepository = transactionRepository;
            _StatementPrinter = statementPrinter;
        }

        public void PrintStatement()
        {
            _StatementPrinter.Print(_TransactionRepository.AllTransactions());
        }

        public void Deposit(decimal amount)
        {
            _TransactionRepository.Add(GetTransaction(amount));
        }

        public void Withdraw(decimal amount)
        {
            _TransactionRepository.Add(GetTransaction(-amount));
        }

        private Transaction GetTransaction(decimal amount)
        {
            return new Transaction { Amount = amount, Date = _Clock.Today() };
        }

    }
}
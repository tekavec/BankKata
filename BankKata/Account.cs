using BankKata.Model;
using BankKata.Printer;

namespace BankKata
{
    public class Account
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IStatementPrinter _StatementPrinter;

        public Account(ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            _TransactionRepository = transactionRepository;
            _StatementPrinter = statementPrinter;
        }

        public void PrintStatement()
        {
            _StatementPrinter.Print(_TransactionRepository.AllTransactions());
        }

        public void Deposit(decimal amount)
        {
            _TransactionRepository.AddDeposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            _TransactionRepository.AddWithdrawal(amount);
        }
    }
}
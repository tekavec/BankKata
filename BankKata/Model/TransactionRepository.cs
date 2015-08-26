using System.Collections.Generic;
using BankKata.Clock;

namespace BankKata.Model
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IList<Transaction> _Transactions = new List<Transaction> ();
        private readonly IClock _Clock;

        public TransactionRepository(IClock clock)
        {
            _Clock = clock;
        }

        public void AddDeposit(decimal amount)
        {
            _Transactions.Add(CreateTransaction(amount));
        }

        public IList<Transaction> AllTransactions()
        {
            return _Transactions;
        }

        public void AddWithdrawal(decimal amount)
        {
            _Transactions.Add(CreateTransaction(-amount));
        }

        private Transaction CreateTransaction(decimal amount)
        {
            return new Transaction{Amount = amount, Date = _Clock.Today()};
        }
    }
}
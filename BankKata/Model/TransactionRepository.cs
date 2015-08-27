using System.Collections.Generic;

namespace BankKata.Model
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IList<Transaction> _Transactions = new List<Transaction> ();

        public IList<Transaction> AllTransactions()
        {
            return _Transactions;
        }

        public void Add(Transaction transaction)
        {
            _Transactions.Add(transaction);
        }
    }
}
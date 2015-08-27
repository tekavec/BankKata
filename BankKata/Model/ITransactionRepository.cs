using System.Collections.Generic;

namespace BankKata.Model
{
    public interface ITransactionRepository
    {
        IList<Transaction> AllTransactions();
        void Add(Transaction transaction);
    }
}
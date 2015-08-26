using System.Collections.Generic;

namespace BankKata.Model
{
    public interface ITransactionRepository
    {
        void AddDeposit(decimal amount);
        IList<Transaction> AllTransactions();
        void AddWithdrawal(decimal amount);
    }
}
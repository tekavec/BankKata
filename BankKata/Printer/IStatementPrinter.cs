using System.Collections.Generic;
using BankKata.Model;

namespace BankKata.Printer
{
    public interface IStatementPrinter
    {
        void Print(IList<Transaction> transactions);
    }
}
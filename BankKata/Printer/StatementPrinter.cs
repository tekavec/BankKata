using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BankKata.Console;
using BankKata.Model;

namespace BankKata.Printer
{
    public class StatementPrinter : IStatementPrinter
    {
        private readonly IBankConsole _Console;
        private const string StatementHeader = "| Date | Amount | Balance";

        public StatementPrinter(IBankConsole console)
        {
            _Console = console;
        }

        public void Print(IList<Transaction> transactions)
        {
            _Console.WriteLine(StatementHeader);
            decimal balance = transactions.Sum(a => a.Money.Amount);
            foreach (var transaction in transactions.OrderByDescending(a => a.Date))
            {
                 _Console.WriteLine(GetFormattedLine(transaction, balance));
                 balance -= transaction.Money.Amount;
            }
        }

        private static string GetFormattedLine(Transaction transaction, decimal balance)
        {
            return string.Format("| {0} | {1} | {2}",
                FormattedDate(transaction.Date),
                FormattedAmount(transaction.Money.Amount),
                FormattedAmount(balance));
        }

        private static string FormattedDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private static string FormattedAmount(decimal amount)
        {
            return amount.ToString("#,##0.00", CultureInfo.InvariantCulture);
        }

        public void PrintHeader()
        {
            _Console.WriteLine(StatementHeader);
        }
    }
}
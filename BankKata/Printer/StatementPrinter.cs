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
            var balance = new Money(transactions.Sum(a => a.Money.Amount));
            foreach (var transaction in transactions.OrderByDescending(a => a.Date))
            {
                 _Console.WriteLine(GetFormattedLine(transaction, balance));
                 balance.Amount -= transaction.Money.Amount;
            }
        }

        private static string GetFormattedLine(Transaction transaction, Money balance)
        {
            return string.Format("| {0} | {1} | {2}",
                FormattedDate(transaction.Date),
                transaction.Money.FormattedAmount(),
                balance.FormattedAmount());
        }

        private static string FormattedDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public void PrintHeader()
        {
            _Console.WriteLine(StatementHeader);
        }
    }
}
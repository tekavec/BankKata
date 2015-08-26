using System;
using System.Globalization;
using BankKata.Model;

namespace BankKata.Clock
{
    public class Clock : IClock
    {
        public string TodayAsString()
        {
            var today = Today();
            return today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public virtual DateTime Today()
        {
            var today = DateTime.UtcNow;
            return today;
        }
    }
}
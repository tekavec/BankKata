using System;

namespace BankKata.Clock
{
    public class Clock : IClock
    {
        public DateTime Today()
        {
            var today = DateTime.UtcNow;
            return today;
        }
    }
}
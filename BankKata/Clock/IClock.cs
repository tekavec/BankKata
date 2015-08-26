using System;

namespace BankKata.Clock
{
    public interface IClock
    {
        string TodayAsString();
        DateTime Today();
    }
}
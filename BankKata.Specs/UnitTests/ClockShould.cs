using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankKata.Model;
using Moq;
using NUnit.Framework;

namespace BankKata.Specs.UnitTests
{
    [TestFixture]
    public class ClockShould
    {

        [Test]
        public void ReturnTodaysDateInddMMyyyyFormat()
        {
            var clock = new TestableClock();

            Assert.AreEqual("24/08/2015", clock.TodayAsString());
        }
    }

    internal class TestableClock : Clock.Clock
    {
        public override DateTime Today()
        {
            return new DateTime(2015, 8, 24);
        }
    }
}

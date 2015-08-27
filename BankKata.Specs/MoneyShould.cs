using BankKata.Model;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class MoneyShould
    {

        [Test]
        public void ReturnAmountAsFormattedString()
        {
            var money = new Money(2500m);

            Assert.AreEqual("2,500.00", money.FormattedAmount());
        }
    }
}

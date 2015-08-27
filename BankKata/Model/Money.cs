using System.Globalization;

namespace BankKata.Model
{
    public class Money
    {
        private const string DefaultFormat = "#,##0.00";

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }

        public string FormattedAmount()
        {
            return Amount.ToString(DefaultFormat, CultureInfo.InvariantCulture);
        }

        protected bool Equals(Money other)
        {
            return Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }
    }
}
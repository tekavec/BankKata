using System;

namespace BankKata.Model
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Money Money { get; set; }

        protected bool Equals(Transaction other)
        {
            return Date.Equals(other.Date) && Equals(Money, other.Money);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Date.GetHashCode()*397) ^ (Money != null ? Money.GetHashCode() : 0);
            }
        }
    }

}
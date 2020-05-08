namespace AG.PaymentApp.Domain.Core.ValueObject
{
    using System;
    public class Currency
    {
        public static Currency Default = new EuroCurrency();

        public Currency()
        { }

        protected Currency(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }

        public string Symbol { get; set; }
        public string Name { get; set; }

        #region Equality
        public static bool operator ==(Currency c1, Currency c2)
        {
            // Both null or same instance
            if (ReferenceEquals(c1, c2))
                return true;

            // Return false if one is null, but not both 
            if (((object)c1 == null) || ((object)c2 == null))
                return false;

            return c1.Equals(c2);
        }
        public static bool operator !=(Currency c1, Currency c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            if (this == (Currency)obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Currency)obj;
            return string.Equals(Symbol, other.Symbol, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }
        public override int GetHashCode()
        {
            const int hashIndex = 307;
            var result = (Symbol != null ? Symbol.GetHashCode() : 0);
            result = (result * hashIndex) ^ (Name != null ? Name.GetHashCode() : 0);
            return result;
        }
        #endregion
    }

    public class DollarCurrency : Currency
    {
        public static DollarCurrency Instance = new DollarCurrency();

        public DollarCurrency()
            : base("$", "USD")
        {
        }
    }

    public class EuroCurrency : Currency
    {
        public static EuroCurrency Instance = new EuroCurrency();

        public EuroCurrency()
            : base("€", "EUR")
        {
        }
    }

    public class GbpCurrency : Currency
    {
        public static GbpCurrency Instance = new GbpCurrency();

        public GbpCurrency()
            : base("£", "GBP")
        {
        }
    }

    public class RealCurrency : Currency
    {
        public static RealCurrency Instance = new RealCurrency();

        public RealCurrency()
            : base("R$", "BRL")
        {
        }
    }
}
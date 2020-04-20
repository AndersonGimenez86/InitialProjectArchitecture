namespace AG.PaymentApp.Domain.Core.ValueObject
{
    using System;
    using AG.PaymentApp.Domain.Core.Enum;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class CreditCard
    {
        public Guid CreditCardID { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public DateTime ExpireDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditCardType CreditCardType { get; set; }
        public int CVV { get; set; }

        #region Equality
        public static bool operator ==(CreditCard c1, CreditCard c2)
        {
            // Both null or same instance
            if (ReferenceEquals(c1, c2))
                return true;

            // Return false if one is null, but not both 
            if (((object)c1 == null) || ((object)c2 == null))
                return false;

            return c1.Equals(c2);
        }
        public static bool operator !=(CreditCard c1, CreditCard c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            if (this == (CreditCard)obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (CreditCard)obj;
            return string.Equals(Number, other.Number, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Owner, other.Owner, StringComparison.InvariantCultureIgnoreCase);
        }
        public override int GetHashCode()
        {
            const int hashIndex = 307;
            var result = (Number != null ? Number.GetHashCode() : 0);
            result = (result * hashIndex) ^ (Owner != null ? Owner.GetHashCode() : 0);
            return result;
        }
        #endregion
    }

}
namespace AG.PaymentApp.Domain.Entity.Shoppers
{
    using System;
    using AG.PaymentApp.Domain.Entity.Bases;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.ValueObject;

    public class Shopper : BaseEvent
    {
        public static Shopper CreateNew(Gender gender, Guid shopperID, string firstname, string lastname, string email)
        {
            var shopper = new Shopper
            {
                Id = shopperID,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender
            };
            return shopper;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; private set; }

        #region Behavior

        /// <summary>
        /// Set the full postal address of the shopper.
        /// </summary>
        /// <param name="address">New address</param>
        /// <returns>this instance</returns>
        public Shopper SetAddress(Address address)
        {
            if (address != null)
            {
                Address = address;
                Address.ID = Guid.NewGuid();
                Address.DateCreated = DateTime.Now;
            }

            return this;
        }
        #endregion

        #region Identity Management
        public static bool operator ==(Shopper c1, Shopper c2)
        {
            // Both null or same instance
            if (ReferenceEquals(c1, c2))
                return true;

            // Return false if one is null, but not both 
            if (((object)c1 == null) || ((object)c2 == null))
                return false;

            return c1.Equals(c2);
        }
        public static bool operator !=(Shopper c1, Shopper c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (this == (Shopper)obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            var other = (Shopper)obj;

            // Your identity logic goes here.  
            // You may refactor this code to the method of an entity interface 
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}

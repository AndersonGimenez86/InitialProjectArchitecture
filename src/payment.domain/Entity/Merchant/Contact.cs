namespace AG.PaymentApp.Domain.Entity.Merchants
{
    using System.Collections.Generic;
    using System.Linq;

    public class Contact
    {
        public Contact()
        {
            this.AccountManager = Enumerable.Empty<int>();
            this.SupportTeam = Enumerable.Empty<int>();
        }

        public IEnumerable<int> AccountManager { get; set; }

        public IEnumerable<int> SupportTeam { get; set; }
    }
}
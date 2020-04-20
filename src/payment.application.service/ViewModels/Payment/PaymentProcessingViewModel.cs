namespace AG.PaymentApp.Application.Services.DTO.Payments
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AG.PaymentApp.Domain.ValueObject;

    public class PaymentProcessingViewModel
    {
        public PaymentProcessingViewModel()
        {
            Messages = new Collection<string>();
        }

        [Required]
        public Guid MerchantID { get; set; }
        [Required]
        public Guid ShopperID { get; set; }
        public CreditCard CreditCard { get; set; }
        public Country Country { get; set; }
        public Money Amount { get; set; }
        [NotMapped]
        public ICollection<string> Messages { get; private set; }
        [NotMapped]
        public bool Denied { get; private set; }

        public void Block()
        {
            this.Denied = true;
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}

namespace AG.PaymentApp.application.services.DTO.Merchants
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AG.PaymentApp.Domain.ValueObject;

    public class MerchantDTO
    {
        public Guid MerchantID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Acronym { get; set; }
        public Country Country { get; set; }
        public Currency Currency { get; set; }
    }
}

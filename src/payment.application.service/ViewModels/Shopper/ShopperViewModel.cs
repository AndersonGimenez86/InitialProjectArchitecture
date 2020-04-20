namespace AG.PaymentApp.Application.Services.DTO.Shoppers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class ShopperViewModel
    {
        public Guid ShopperID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
    }
}

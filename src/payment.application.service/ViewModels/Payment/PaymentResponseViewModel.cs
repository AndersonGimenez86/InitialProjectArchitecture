namespace AG.PaymentApp.Application.Services.DTO.Payments
{
    using System;
    using AG.PaymentApp.Domain.Core.Enum;

    public class PaymentProcessingResponseViewModel
    {
        public Guid PaymentID { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}

namespace AG.PaymentApp.application.services.DTO.Payments
{
    using System;
    using AG.PaymentApp.Domain.Enum;

    public class PaymentProcessingResponseViewModel
    {
        public Guid PaymentID { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}

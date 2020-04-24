namespace AG.PaymentApp.Application.Services.DTO.Payments
{
    using System;
    using System.Collections.Generic;
    using AG.PaymentApp.Domain.Core.Enum;

    public class PaymentProcessingResponseViewModel
    {
        public Guid PaymentID { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public IEnumerable<string> ErrorMessage { get; set; }
    }
}

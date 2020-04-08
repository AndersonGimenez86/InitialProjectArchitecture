namespace AG.PaymentApp.application.services.DTO.Payments
{
    using AG.PaymentApp.Domain.Entity.Payments;

    public class PaymentProcessedDTO
    {
        public PaymentProcessedDTO()
        {
        }
        public string OrderID { get; set; } = string.Empty;
        public PaymentConfirmation PaymentDetails { get; set; } = new PaymentConfirmation();
    }
}

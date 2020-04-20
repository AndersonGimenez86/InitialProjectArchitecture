namespace AG.PaymentApp.Application.Services.DTO.Payments
{
    using AG.PaymentApp.Domain.Entity.Payments;

    public class PaymentProcessedViewModel
    {
        public PaymentProcessedViewModel()
        {
        }
        public string OrderID { get; set; } = string.Empty;
        public PaymentConfirmation PaymentDetails { get; set; } = new PaymentConfirmation();
    }
}

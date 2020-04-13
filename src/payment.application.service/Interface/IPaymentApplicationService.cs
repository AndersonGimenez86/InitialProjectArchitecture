namespace AG.PaymentApp.application.services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.services.DTO.Payments;

    public interface IPaymentApplicationService
    {
        Task<PaymentProcessingResponseViewModel> CreateAsync(PaymentProcessingViewModel paymentProcessingDTO);
        Task<PaymentViewModel> GetAsync(Guid paymentID);
        Task<IEnumerable<PaymentViewModel>> GetAllAsync();
        Task<PaymentViewModel> GetLastPaymentReceivedAsync(Guid shopperID);
    }
}

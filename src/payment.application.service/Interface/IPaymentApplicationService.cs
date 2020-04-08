namespace AG.PaymentApp.application.services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.services.DTO.Payments;

    public interface IPaymentApplicationService
    {
        Task<PaymentProcessingResponseDTO> CreateAsync(PaymentProcessingDTO paymentProcessingDTO);
        Task<PaymentDTO> GetAsync(Guid paymentID);
        Task<IEnumerable<PaymentDTO>> GetAllAsync();
        Task<PaymentDTO> GetLastPaymentReceivedAsync(Guid shopperID);
    }
}

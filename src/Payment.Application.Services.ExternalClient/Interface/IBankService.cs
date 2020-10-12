using System;
using System.Threading.Tasks;

namespace Payment.Application.Services.ExternalClient.Interface
{
    public interface IBankService
    {
        Task<(bool IsSuccess, string response, string ErrorMessage)> GetOperationAsync(Guid id);
    }
}

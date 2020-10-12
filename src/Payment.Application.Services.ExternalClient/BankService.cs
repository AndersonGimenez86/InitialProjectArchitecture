using Microsoft.Extensions.Logging;
using Payment.Application.Services.ExternalClient.Interface;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Payment.Application.Services.ExternalClient
{
    public class BankService : IBankService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<BankService> logger;

        public BankService(IHttpClientFactory httpClientFactory, ILogger<BankService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, string response, string ErrorMessage)> GetOperationAsync(Guid id)
        {
            try
            {
                var client = httpClientFactory.CreateClient("BankService");
                var response = await client.GetAsync("api/ThirdPartTransaction");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<string>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}

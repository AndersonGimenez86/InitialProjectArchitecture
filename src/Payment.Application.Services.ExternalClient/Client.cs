namespace AG.Payment.Application.Services.ExternalClient
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using AG.Payment.Infrastructure.Crosscutting.Settings.EndPoints;
    using Payment.Application.Services.ExternalClient.Interface;
    public class Client : IClient
    {
        private HttpClient client;
        private readonly IHttpClientFactory httpClientFactory;

        public Client(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public Task<HttpClient> GetClientObject(EndPointSettings endPointSettings)
        {
            return Task.FromResult(httpClientFactory.CreateClient(endPointSettings.Name));
        }
    }
}

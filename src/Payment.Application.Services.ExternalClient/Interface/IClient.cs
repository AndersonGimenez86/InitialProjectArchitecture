namespace AG.Payment.Application.Services.ExternalClient.Interface
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using AG.Payment.Infrastructure.Crosscutting.Settings.EndPoints;

    public interface IClient
    {
        Task<HttpClient> GetClientObject(EndPointSettings endPointSettings);
    }
}

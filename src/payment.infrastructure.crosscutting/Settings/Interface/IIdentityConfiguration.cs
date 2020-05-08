namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    public interface IIdentityConfiguration
    {
        string ApiName { get; set; }
        string Authority { get; set; }
        string ClientKey { get; set; }
        string ClientSecret { get; set; }
        bool EnableAuth { get; set; }
        string[] Scopes { get; set; }
    }
}
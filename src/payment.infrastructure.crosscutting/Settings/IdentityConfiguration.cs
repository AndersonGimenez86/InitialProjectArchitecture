namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    public class IdentityConfiguration : IIdentityConfiguration
    {
        public string ApiName { get; set; }

        public string Authority { get; set; }

        public string ClientKey { get; set; }

        public string ClientSecret { get; set; }

        public bool EnableAuth { get; set; }
        public string[] Scopes { get; set; }
    }
}

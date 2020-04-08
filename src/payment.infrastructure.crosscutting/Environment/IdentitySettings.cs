namespace AG.PaymentApp.infrastructure.crosscutting.Environment
{
    public class IdentitySettings
    {
        public string ApiName { get; set; }

        public string Authority { get; set; }

        public string ClientKey { get; set; }

        public string ClientSecret { get; set; }

        public bool EnableAuth { get; set; }
        public string[] Scopes { get; set; }
    }
}

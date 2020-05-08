namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    public class EnvironmentConfiguration : IEnvironmentConfiguration
    {
        public string HostUri { get; set; }

        public string SwaggerPath { get; set; }
    }
}

namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    public interface IEnvironmentConfiguration
    {
        string HostUri { get; set; }
        string SwaggerPath { get; set; }
    }
}
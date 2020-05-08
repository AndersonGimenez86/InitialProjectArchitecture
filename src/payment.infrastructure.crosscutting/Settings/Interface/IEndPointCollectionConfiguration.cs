namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    using System.Collections.Generic;
    using AG.Payment.Infrastructure.Crosscutting.Settings.EndPoints;
    public interface IEndPointCollectionConfiguration
    {
        IEnumerable<EndPointConfiguration> EndPointSettings { get; set; }
    }
}
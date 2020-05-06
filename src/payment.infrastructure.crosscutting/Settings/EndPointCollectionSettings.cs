namespace AG.Payment.Infrastructure.Crosscutting.Settings
{
    using System.Collections.Generic;
    using AG.Payment.Infrastructure.Crosscutting.Settings.EndPoints;
    public class EndPointCollectionSettings
    {
        public IEnumerable<EndPointSettings> EndPointSettings { get; set; }
    }
}

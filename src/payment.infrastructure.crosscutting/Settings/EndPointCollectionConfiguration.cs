﻿namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    using System.Collections.Generic;
    using AG.Payment.Infrastructure.Crosscutting.Settings.EndPoints;
    public class EndPointCollectionConfiguration : IEndPointCollectionConfiguration
    {
        public IEnumerable<EndPointConfiguration> EndPointSettings { get; set; }
    }
}
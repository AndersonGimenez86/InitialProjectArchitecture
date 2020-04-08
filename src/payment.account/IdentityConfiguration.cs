using System.Collections.Generic;
using IdentityServer4.Models;

namespace AG.PaymentApp.account
{
    public class IdentityConfiguration
    {
        public static IEnumerable<ApiResource> Apis =>
      new List<ApiResource>
      {
            new ApiResource("AG.com-privacy", "Payment Gateway")
      };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                     new Client
                            {
                                ClientId="AG.com-privacy",
                                Enabled = true,
                                ClientName="AG.com-privacy",
                                AllowedGrantTypes = GrantTypes.Implicit,
                                ClientSecrets = new List<Secret>
                                {
                                    new Secret("8b95ed02-0ae4-4345-9edc-feeb61f9e284".Sha256())
                                },
                                AllowedScopes = new List<string>
                                {
                                    "paymentgateway-integrations"
                                },
                                RedirectUris = new List<string>
                                {
                                    "http://localhost:5050/swagger/oauth2-redirect.html"
                                },
                                AllowedCorsOrigins = new List<string>
                                {
                                    "http://localhost:5050",
                                    "http://localhost:5050"
                                },
                                AllowAccessTokensViaBrowser = true,
                             }
                     };

        public static IEnumerable<IdentityResource> Ids =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
    }
}

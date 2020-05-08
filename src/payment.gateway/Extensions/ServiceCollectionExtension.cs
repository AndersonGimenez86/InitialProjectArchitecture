namespace AG.PaymentApp.gateway.Extensions
{
    using AG.PaymentApp.Infrastructure.Crosscutting.Environment;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IdentityConfiguration identitySettings)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", CreateInfoForApiVersion());
                options.DescribeAllEnumsAsStrings();

                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Scheme = IdentityServerAuthenticationDefaults.AuthenticationScheme,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        Implicit = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri($"{identitySettings.Authority}/connect/authorize"),
                //            TokenUrl = new Uri($"{identitySettings.Authority}/connect/token"),
                //            Scopes = new Dictionary<string, string>
                //            {
                //                { "paymentgateway-integrations", "Demo API - full access" }
                //            }
                //        }
                //    }
                //});
            });

            return services;
        }
        private static OpenApiInfo CreateInfoForApiVersion()
        {
            var info = new OpenApiInfo()
            {
                Title = "AG.com",
                Version = "v1",
                Description = "AG.com Anderson Gimenez project test",
                Contact = new OpenApiContact()
                {
                    Name = "Anderson Gimenez",
                    Email = "andersonvilas@gmail.com"
                }
            };

            return info;
        }
    }
}

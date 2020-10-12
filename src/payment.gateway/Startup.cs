using AG.Payment.Infrastructure.Crosscutting.Settings;
using AG.PaymentApp.gateway.Extensions;
using AG.PaymentApp.Infrastructure.Crosscutting.Environment;
using AG.PaymentApp.Infrastructure.Crosscutting.IoC;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using System;

namespace AG.PaymentApp.gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            var identitySettings = new IdentitySettings();
            Configuration.GetSection(SectionNames.ApplicationIdentitySection).Bind(identitySettings);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddIdentityServerAuthentication(options =>
            //{
            //    options.Authority = identitySettings.Authority;
            //    options.RequireHttpsMetadata = false;
            //    options.ApiName = identitySettings.ApiName;
            //    options.ApiSecret = identitySettings.ClientSecret;
            //    options.ClaimsIssuer = identitySettings.Authority;

            //});


            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddSwagger(identitySettings);

            services.AddDataProtection();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            services.AddHttpClient("BankService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Bank"]);
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMinutes(5)));

            DependencyInjectionBootstraper.InitializeAppSettings(services, this.Configuration);
            DependencyInjectionBootstraper.RegisterServices(services, this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IOptions<EnvironmentSettings> environmentSettings,
            IOptions<EndPointCollectionSettings> endPointCollectionSettings
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.DocumentTitle = "AG API";
                c.SwaggerEndpoint(environmentSettings.Value.SwaggerPath, "AG.com API V1");
                c.OAuthClientId("AG.com-privacy");
                c.OAuthAppName("AG.com-privacy");

            });

            app.UseAuthentication();
            //app.UseAuthorization();

            DependencyInjectionBootstraper.InitializeServices(app.ApplicationServices);
        }
    }
}

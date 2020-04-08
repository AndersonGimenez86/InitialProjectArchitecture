namespace AG.PaymentApp.gateway.Extensions
{
    using Microsoft.AspNetCore.Hosting;

    public static class TestPermissionExtension
    {
        public static bool AllowPost(this IHostingEnvironment environment)
        {
            return environment.IsDevelopment() || environment.IsStaging();
        }
    }
}

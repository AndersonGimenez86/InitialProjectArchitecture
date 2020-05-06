using Hangfire.Dashboard;

namespace Payment.Gateway.Scheduler.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();​
            return true;
        }
    }
}

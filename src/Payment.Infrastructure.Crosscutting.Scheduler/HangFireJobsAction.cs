using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.States;

namespace AG.Payment.Infrastructure.Crosscutting.Scheduler
{
    public class HangFireJobsAction
    {
        private readonly BackgroundJobClient backgroundJobClient;

        public HangFireJobsAction()
        {
            backgroundJobClient = new BackgroundJobClient();
        }
        public void DeleteRecurringJobWhenExists(string identifier)
        {
            RecurringJob.RemoveIfExists(identifier);
        }

        public bool CheckIfJobAlreadyProcessing(string id)
        {
            var processingCount = JobStorage.Current.GetMonitoringApi().ProcessingCount();
            var processingJobs = JobStorage.Current.GetMonitoringApi().ProcessingJobs(0, processingCount > int.MaxValue ? int.MaxValue : (int)processingCount);

            return processingJobs.Exists(j => j.Value.Job.Args.Any(ja => ja.ToString() == id));
        }

        public string Enqueue(Expression<Action> job, string queueName)
        {
            var state = new EnqueuedState(queueName);
            return this.backgroundJobClient.Create(job, state);
        }

        public string Enqueue(Expression<Func<Task>> job, string queueName)
        {
            var state = new EnqueuedState(queueName);
            return this.backgroundJobClient.Create(job, state);
        }
    }
}

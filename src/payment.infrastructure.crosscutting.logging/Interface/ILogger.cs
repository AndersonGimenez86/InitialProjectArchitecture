namespace AG.PaymentApp.Infrastructure.Crosscutting.Logging.Interface
{
    public interface ILogger
    {
        void WriteLog<T>(LogTemplate<T> logTemplate);
    }
}

namespace AG.PaymentApp.infrastructure.crosscutting.logging.Interface
{
    public interface ILogger
    {
        void WriteLog<T>(LogTemplate<T> logTemplate);
    }
}

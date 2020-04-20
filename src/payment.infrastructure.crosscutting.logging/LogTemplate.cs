namespace AG.PaymentApp.Infrastructure.Crosscutting.Logging
{
    public abstract class LogTemplate<TData>
    {
        public TData Data { get; protected set; }

        public abstract LogLevel LogLevel { get; }
        public abstract string Message { get; }
    }
}

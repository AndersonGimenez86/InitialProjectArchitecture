namespace AG.PaymentApp.infrastructure.crosscutting.logging
{
    public class GenericLog : LogTemplate<string>
    {
        private readonly string message;

        public GenericLog(string message)
        {
            this.message = message;
        }

        public override LogLevel LogLevel => LogLevel.Warning;

        public override string Message => this.message;
    }
}

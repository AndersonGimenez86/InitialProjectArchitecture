namespace AG.PaymentApp.infrastructure.crosscutting.logging
{
    using AG.PaymentApp.infrastructure.crosscutting.logging.Interface;

    internal class Logger : ILogger
    {
        private readonly ILog logger;

        public Logger(ILog logger)
        {
            this.logger = logger;
        }

        public void WriteLog<T>(LogTemplate<T> logTemplate)
        {
            switch (logTemplate.LogLevel)
            {
                case LogLevel.Verbose:
                    this.logger.Verbose(logTemplate.Message, () => logTemplate.Data);
                    break;

                case LogLevel.Info:
                    this.logger.Info(logTemplate.Message, () => logTemplate.Data);
                    break;

                case LogLevel.Warning:
                    this.logger.Warning(logTemplate.Message, () => logTemplate.Data);
                    break;

                case LogLevel.Error:
                    this.logger.Error(logTemplate.Message, () => logTemplate.Data);
                    break;

                case LogLevel.Fatal:
                    this.logger.Fatal(logTemplate.Message, () => logTemplate.Data);
                    break;
            }
        }
    }
}

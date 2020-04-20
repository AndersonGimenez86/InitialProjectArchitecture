namespace AG.PaymentApp.Infrastructure.Crosscutting.Logging
{
    using System.Runtime.CompilerServices;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging.Interface;
    using AG.PaymentApp.Infrastructure.Crosscutting.Settings.Logging;

    public static class GlobalLogInitializer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ILog SetupLogger(LoggingSettings loggingSettings)
        {
            //Log.Current = new Logger(
            //    (LogLevel)Enum.Parse(typeof(LogLevel), loggingSettings.LogLevel),
            //    new DefaultJsonLogDocumentRender(),
            //    new RollingFileBySizeWriter(loggingSettings.FilePath)
            //);

            //return Log.Current;

            return null;
        }
    }
}

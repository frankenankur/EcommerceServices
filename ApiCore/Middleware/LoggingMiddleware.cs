using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace ApiCore.Middleware
{
    public class LoggingMiddleware
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggingMiddleware() { }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        public void LogFatal(string message)
        {
            logger.Fatal(message);
        }

        public static void ConfigureLoggerService(IServiceCollection services)
        {
            services.AddSingleton<LoggingMiddleware>();
        }
    }
}

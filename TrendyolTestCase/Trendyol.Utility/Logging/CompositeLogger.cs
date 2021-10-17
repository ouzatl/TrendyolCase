using Microsoft.Extensions.Logging;
using System;

namespace Trendyol.Utility.Logging
{
    public class CompositeLogger : ICompositeLogger
    {
        private readonly ILogger _logger;
        public CompositeLogger(ILogger<CompositeLogger> logger)
        {
            _logger = logger;
        }

        public void Info(string message, object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void Error(string message, Exception ex)
        {
            _logger.LogError(null, message, ex);
        }

        public void Warning(string message, Exception ex)
        {
            _logger.LogWarning(message, ex);
        }

        public void Warning(string message, object[] args)
        {
            _logger.LogCritical(message, args);
        }
    }
}

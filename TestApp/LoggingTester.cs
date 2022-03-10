using System.Diagnostics.CodeAnalysis;

namespace TestApp;
public class LoggingTester : ILoggingTester
{
    private readonly ILogger<LoggingTester> _logger;

    public LoggingTester(ILogger<LoggingTester> logger)
    {
        _logger = logger;
    }

    public void LogError(string message)
    {
        ArgumentNullException.ThrowIfNull(_logger, nameof(_logger));
        _logger.LogError(message);
    }   
}


using System.Collections.Concurrent;

namespace APICatalogo.Logging;

public class CustomLoggerProvider(CustomerLoggerProviderConfiguration configuration) : ILoggerProvider
{
    ConcurrentDictionary<string, CustomerLogger> loggers = new();
    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, configuration));
    }

    public void Dispose() => loggers.Clear();
}

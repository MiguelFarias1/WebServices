using System.Collections.Concurrent;

namespace APICatalogo.Logging;

public class CustomLoggerProvider(
    CustomerLoggerProviderConfiguration configuration,
    ConcurrentDictionary<string, CustomerLogger> loggers
    ) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, configuration));
    }

    public void Dispose()
    {

    }
}

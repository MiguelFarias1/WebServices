
namespace APICatalogo.Logging;

public class CustomerLogger(string loggerName, CustomerLoggerProviderConfiguration configuration) : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == configuration.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

        WriteTextOnFile(message);
    }

    private async void WriteTextOnFile(string message)
    {
        string caminho = @"C:\Users\Migue\Documents\Logs\logs.txt";

        using StreamWriter writer = new(caminho, true);

        try
        {
            await writer.WriteLineAsync(message);
            writer.Close();
        }
        catch
        {

        }
    }
}

#pragma warning disable CA1822 // Mark members as static.
#pragma warning disable RS0030 // Do not use banned APIs.

namespace AccessModifiersInCsharp;

internal class Logger
{
    protected internal string LogMessage(string message) => $"Logged at {DateTime.Now}, Message: {message}";
}

#pragma warning disable IDE0040 // Add accessibility modifiers.

namespace AccessModifiersInCsharp;

class DerivedLogger : Logger
{
    public string LogMessageFromDerivedClass(string message) => $"Derived Log: {LogMessage(message)}";
}

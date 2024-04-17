#pragma warning disable CA1822 // Mark members as static.

namespace AccessModifiersInCsharp;

public class Calculator
{
    public int Value { get; set; }

    public int IncrementValue(int value) => value + 1;
}

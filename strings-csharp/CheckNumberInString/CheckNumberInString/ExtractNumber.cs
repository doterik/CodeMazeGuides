#pragma warning disable MA0009 // Add regex evaluation timeout.
#pragma warning disable SA1601 // Partial elements should be documented.

using System.Buffers;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckNumberInString;

public static partial class ExtractNumber
{
    // Define valid numerical characters including digits, minus sign, and decimal point.
    private static readonly SearchValues<char> NumericSearchValues = SearchValues.Create(['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.']);

    [GeneratedRegex(@"(?:^|(?<=(?:\s|[^-\d])))-?\d+(?:\.\d+)?\b(?!-)")]
    private static partial Regex NumberRegex();

    public static string ExtractNumberUsingRegEx(string inputString)
    {
        var extractedNumbers = new List<double>();

        foreach (var value in NumberRegex().Matches(inputString).Select(match => match.Value))
        {
            if (double.TryParse(value, CultureInfo.InvariantCulture, out var parsedNumber))
            {
                extractedNumbers.Add(parsedNumber);
            }
        }

        return string.Join(';', extractedNumbers);
    }

    public static string ExtractNumbersUsingLinq(string inputString)
        => string.Join(';', new string(inputString
            .Where(c => char.IsBetween(c, '0', '9') || c == '.' || c == '-' || char.IsWhiteSpace(c))
            .ToArray()).Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)
            .Where(s => !s.All(c => c == '.') && !s[1..].Any(c => c == '-')));

    public static string ExtractNumberUsingStringBuilder(string inputString)
    {
        var numbers = new List<double>();
        var currentNumber = new StringBuilder();
        var isInsideNumber = false;

        foreach (var c in inputString)
        {
            if (char.IsBetween(c, '0', '9') || c == '.' || c == '-')
            {
                _ = currentNumber.Append(c);
                isInsideNumber = true;
            }
            else if (isInsideNumber)
            {
                AddNumberToList(currentNumber.ToString(), numbers);
                _ = currentNumber.Clear();
                isInsideNumber = false;
            }
        }

        if (currentNumber.Length > 0)
        {
            AddNumberToList(currentNumber.ToString(), numbers);
        }

        return string.Join(';', numbers);
    }

    public static string ExtractNumberUsingSpan(string inputString)
    {
        var numbers = new List<double>();

        var inputStringSpan = inputString.AsSpan();
        while (true)
        {
            var startIndex = inputStringSpan.IndexOfAny(NumericSearchValues);
            if (startIndex == -1)
                break;

            inputStringSpan = inputStringSpan[startIndex..];

            var endIndex = inputStringSpan.IndexOfAnyExcept(NumericSearchValues);
            if (endIndex == -1)
            {
                AddNumberToList(inputStringSpan, numbers);
                break;
            }

            AddNumberToList(inputStringSpan[..endIndex], numbers);
            inputStringSpan = inputStringSpan[endIndex..];
        }

        return string.Join(';', numbers);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void AddNumberToList(ReadOnlySpan<char> numberSpan, List<double> numbers)
    {
        if (double.TryParse(numberSpan, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
        {
            numbers.Add(number);
        }
    }
}

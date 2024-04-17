using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Order;

namespace CheckNumberInString;

[MemoryDiagnoser]
[HideColumns(Column.RatioSD, Column.AllocRatio)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class BenchmarkProcess
{
    private const string InputString = "The price is $42.75 for two items and $18.50 for one item.";

    [Benchmark]
    public string ExtractNumberUsingRegExMethod() => ExtractNumber.ExtractNumberUsingRegEx(InputString);

    [Benchmark(Baseline = true)]
    public string ExtractNumberUsingLinqMethod() => ExtractNumber.ExtractNumbersUsingLinq(InputString);

    [Benchmark]
    public string ExtractNumberUsingStringBuilderMethod() => ExtractNumber.ExtractNumberUsingStringBuilder(InputString);

    [Benchmark]
    public string ExtractNumberUsingSpanMethod() => ExtractNumber.ExtractNumberUsingSpan(InputString);
}

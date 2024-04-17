// #pragma warning disable RCS1239 // Use 'for' statement instead of 'while' statement.

using BenchmarkDotNet.Attributes;

namespace BaselineStylingInBenchmarkDotNet;

[Config(typeof(StyleConfig))]
public class BaselineStylingBenchmark(int finalNumber = 2_000)
{
    [Benchmark(Baseline = true)]
    public int UseForLoop()
    {
        var sum = 0;
        for (var i = 1; i <= finalNumber; i++)
        {
            sum += i;
        }

        return sum;
    }

    [Benchmark]
    public int UseWhileLoop()
    {
        var sum = 0;
        var i = 1;
        while (i <= finalNumber)
        {
            sum += i;
            i++;
        }

        return sum;
    }

    [Benchmark]
    public int UseEnumerableSum() => Enumerable.Range(1, finalNumber).Sum();

    [Benchmark]
    public int UseFormula() => finalNumber * (1 + finalNumber) / 2; // Sn = a1+a2+a3+...+an = n(a1 + an) / 2
}

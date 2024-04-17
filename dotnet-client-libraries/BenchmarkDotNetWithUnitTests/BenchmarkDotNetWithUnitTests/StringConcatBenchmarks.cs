#pragma warning disable IDE1006 // Naming Styles.
#pragma warning disable CA1822  // Mark members as static.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkDotNetWithUnitTests;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringConcatBenchmarks
{
    private const string FirstName = "John";
    private const string LastName = "Doe";

    [Benchmark]
    public string StringConcat() => FirstName + " " + LastName;

    [Benchmark]
    public string StringFormat() => string.Format("{0} {1}", FirstName, LastName);

    [Benchmark]
    public string StringInterpolation() => $"{FirstName} {LastName}";

    [Benchmark]
    public string StringConcatWithJoin() => string.Join(" ", FirstName, LastName);
}

/*
| Method               | Mean       | Error     | StdDev    | Rank | Gen0   | Allocated |
|--------------------- |-----------:|----------:|----------:|-----:|-------:|----------:|
| StringConcat         |  0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |      - |         - |
| StringInterpolation  |  0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |      - |         - |
| StringConcatWithJoin | 38.6974 ns | 0.1170 ns | 0.0977 ns |    2 | 0.0095 |      80 B |
| StringFormat         | 87.6339 ns | 0.2372 ns | 0.2103 ns |    3 | 0.0048 |      40 B |

*/
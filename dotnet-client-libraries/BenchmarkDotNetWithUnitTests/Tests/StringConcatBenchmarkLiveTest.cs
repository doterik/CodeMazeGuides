#pragma warning disable IDE1006 // Naming Styles.

using System.Collections.Immutable;
using BenchmarkDotNet.Reports;

namespace Tests;

public class StringConcatBenchmarkLiveTest : IClassFixture<BenchmarkFixture>
{
    private readonly ImmutableArray<BenchmarkReport> _benchmarkReports;
    private readonly BenchmarkReport _stringInterpolationReport;

    public StringConcatBenchmarkLiveTest(BenchmarkFixture benchmarkFixture)
    {
        _benchmarkReports = benchmarkFixture.BenchmarkSummary.Reports;
        _stringInterpolationReport = _benchmarkReports.First(x
            => x.BenchmarkCase.Descriptor.DisplayInfo is "StringConcatBenchmarks.StringInterpolation");
    }

    [Fact]
    public void WhenBenchmarkTestsAreRun_ThenFourCasesMustBeExecuted()
    {
        var benchmarkCases = _benchmarkReports.Length;

        Console.WriteLine($"benchmarkCases: {benchmarkCases}");

        Assert.Equal(4, benchmarkCases);
    }

    [Fact]
    public void WhenStringInterpolationCaseIsExecuted_ThenItShouldNotTakeMoreThanFifteenNanoSecs()
    {
        var stats = _stringInterpolationReport.ResultStatistics;

        Console.WriteLine($"stats.Mean: {stats?.Mean}");

        Assert.True(stats is { Mean: < 15 }, $"Mean was {stats.Mean}");
    }

    [Fact]
    public void WhenStringInterpolationCaseIsExecuted_ThenItShouldNotConsumeMemoryMoreThanMaxAllocation()
    {
        const int MaxAllocation = 1_342_178_216;

        var memoryStats = _stringInterpolationReport.GcStats;
        var stringInterpolationCase = _stringInterpolationReport.BenchmarkCase;
        var allocation = memoryStats.GetBytesAllocatedPerOperation(stringInterpolationCase);
        var totalAllocatedBytes = memoryStats.GetTotalAllocatedBytes(true);

        Console.WriteLine($"allocation: {allocation}");
        Console.WriteLine($"totalAllocatedBytes: {totalAllocatedBytes}");

        Assert.True(allocation <= MaxAllocation, $"Allocation was {allocation}");
        Assert.True(totalAllocatedBytes <= MaxAllocation, $"TotalAllocatedBytes was {totalAllocatedBytes}");
    }

    [Fact]
    public void WhenStringInterpolationCaseIsExecuted_ThenZeroAllocationInGen1AndGen2()
    {
        var memoryStats = _stringInterpolationReport.GcStats;

        Console.WriteLine($"memoryStats.Gen1Collections: {memoryStats.Gen1Collections}");
        Console.WriteLine($"memoryStats.Gen2Collections: {memoryStats.Gen2Collections}");

        Assert.True(memoryStats.Gen1Collections is 0, $"Gen1Collections was {memoryStats.Gen1Collections}");
        Assert.True(memoryStats.Gen2Collections is 0, $"Gen2Collections was {memoryStats.Gen2Collections}");
    }
}

/*
StringConcatBenchmarks.StringInterpolation: DefaultJob
Runtime = .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.000 ns, StdErr = 0.000 ns (NaN%), N = 14, StdDev = 0.000 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.000 ns, Max = 0.000 ns
IQR = 0.000 ns, LowerFence = 0.000 ns, UpperFence = 0.000 ns
ConfidenceInterval = [0.000 ns; 0.000 ns] (CI 99.9%), Margin = 0.000 ns (NaN% of Mean)
Skewness = NaN, Kurtosis = NaN, MValue = 2
*/
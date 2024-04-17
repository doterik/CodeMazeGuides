#pragma warning disable IDE1006 // Naming Styles.
// #pragma warning disable SA1309 // Field names should not begin with underscore.

using BaselineStylingInBenchmarkDotNet;

namespace Tests;

public class BaselineStylingTests
{
    private readonly int _expectedSum = 2_001_000;
    private readonly BaselineStylingBenchmark _baselineStylingBenchmark = new();

    [Fact]
    public void WhenUseForLoopIsCalledThenReturnsTheCorrectSum()
    {
        var result = _baselineStylingBenchmark.UseForLoop();

        Assert.Equal(_expectedSum, result);
    }

    [Fact]
    public void WhenUseWhileLoopIsCalledThenReturnsTheCorrectSum()
    {
        var result = _baselineStylingBenchmark.UseWhileLoop();

        Assert.Equal(_expectedSum, result);
    }

    [Fact]
    public void WhenUseEnumerableSumIsCalledThenReturnsTheCorrectSum()
    {
        var result = _baselineStylingBenchmark.UseEnumerableSum();

        Assert.Equal(_expectedSum, result);
    }

    [Fact]
    public void WhenUseFormulaIsCalledThenReturnsTheCorrectSum()
    {
        var result = _baselineStylingBenchmark.UseFormula();

        Assert.Equal(_expectedSum, result);
    }
}

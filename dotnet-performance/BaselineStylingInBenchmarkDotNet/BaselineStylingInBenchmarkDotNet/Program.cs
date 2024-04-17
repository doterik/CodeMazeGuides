using BaselineStylingInBenchmarkDotNet;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<BaselineStylingBenchmark>();

/*
| Method           | Mean          | Error      | StdDev     | Median        | Ratio         | RatioSD |
|----------------- |--------------:|-----------:|-----------:|--------------:|--------------:|--------:|
| UseForLoop       |   854.5461 ns |  3.6751 ns |  3.2579 ns |   853.7738 ns |      baseline |         |
| UseWhileLoop     |   852.3052 ns |  1.2593 ns |  1.1163 ns |   852.2260 ns | 1.003x faster |   0.00x |
| UseEnumerableSum | 5,695.5019 ns | 48.7997 ns | 45.6473 ns | 5,701.2970 ns | 6.666x slower |   0.06x |
| UseFormula       |     0.0016 ns |  0.0033 ns |  0.0029 ns |     0.0001 ns |            NA |      NA |
*/

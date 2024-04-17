using BenchmarkDotNet.Running;
using BenchmarkDotNetWithUnitTests;

var summary = BenchmarkRunner.Run<StringConcatBenchmarks>();
Console.WriteLine($"summary: {summary}"); // ...

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

/*
// AfterAll
// Benchmark Process 33928 has exited with code 0.

Mean = 38.697 ns, StdErr = 0.027 ns (0.07%), N = 13, StdDev = 0.098 ns
Min = 38.507 ns, Q1 = 38.627 ns, Median = 38.735 ns, Q3 = 38.756 ns, Max = 38.822 ns
IQR = 0.129 ns, LowerFence = 38.434 ns, UpperFence = 38.949 ns
ConfidenceInterval = [38.580 ns; 38.814 ns] (CI 99.9%), Margin = 0.117 ns (0.30% of Mean)
Skewness = -0.67, Kurtosis = 2.06, MValue = 2

// ** Remained 0 (0,0 %) benchmark(s) to run. Estimated finish 2024-04-17 13:34 (0h 0m from now) **
Successfully reverted power plan (GUID: 381b4222-f694-41f0-9685-ff5bb260df2e FriendlyName: Balanced)
// ***** BenchmarkRunner: Finish  *****

// * Export *
  BenchmarkDotNet.Artifacts\results\BenchmarkDotNetWithUnitTests.StringConcatBenchmarks-report.csv
  BenchmarkDotNet.Artifacts\results\BenchmarkDotNetWithUnitTests.StringConcatBenchmarks-report-github.md
  BenchmarkDotNet.Artifacts\results\BenchmarkDotNetWithUnitTests.StringConcatBenchmarks-report.html

// * Detailed results *
StringConcatBenchmarks.StringConcat: DefaultJob
Runtime = .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.000 ns, StdErr = 0.000 ns (NaN%), N = 12, StdDev = 0.000 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.000 ns, Max = 0.000 ns
IQR = 0.000 ns, LowerFence = 0.000 ns, UpperFence = 0.000 ns
ConfidenceInterval = [0.000 ns; 0.000 ns] (CI 99.9%), Margin = 0.000 ns (NaN% of Mean)
Skewness = NaN, Kurtosis = NaN, MValue = 2
-------------------- Histogram --------------------
[-0.500 ns ; 0.500 ns) | @@@@@@@@@@@@
---------------------------------------------------

StringConcatBenchmarks.StringInterpolation: DefaultJob
Runtime = .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.000 ns, StdErr = 0.000 ns (NaN%), N = 14, StdDev = 0.000 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.000 ns, Max = 0.000 ns
IQR = 0.000 ns, LowerFence = 0.000 ns, UpperFence = 0.000 ns
ConfidenceInterval = [0.000 ns; 0.000 ns] (CI 99.9%), Margin = 0.000 ns (NaN% of Mean)
Skewness = NaN, Kurtosis = NaN, MValue = 2
-------------------- Histogram --------------------
[-0.500 ns ; 0.500 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

StringConcatBenchmarks.StringConcatWithJoin: DefaultJob
Runtime = .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 38.697 ns, StdErr = 0.027 ns (0.07%), N = 13, StdDev = 0.098 ns
Min = 38.507 ns, Q1 = 38.627 ns, Median = 38.735 ns, Q3 = 38.756 ns, Max = 38.822 ns
IQR = 0.129 ns, LowerFence = 38.434 ns, UpperFence = 38.949 ns
ConfidenceInterval = [38.580 ns; 38.814 ns] (CI 99.9%), Margin = 0.117 ns (0.30% of Mean)
Skewness = -0.67, Kurtosis = 2.06, MValue = 2
-------------------- Histogram --------------------
[38.452 ns ; 38.877 ns) | @@@@@@@@@@@@@
---------------------------------------------------

StringConcatBenchmarks.StringFormat: DefaultJob
Runtime = .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 87.634 ns, StdErr = 0.056 ns (0.06%), N = 14, StdDev = 0.210 ns
Min = 87.401 ns, Q1 = 87.493 ns, Median = 87.569 ns, Q3 = 87.730 ns, Max = 88.070 ns
IQR = 0.237 ns, LowerFence = 87.139 ns, UpperFence = 88.085 ns
ConfidenceInterval = [87.397 ns; 87.871 ns] (CI 99.9%), Margin = 0.237 ns (0.27% of Mean)
Skewness = 0.98, Kurtosis = 2.64, MValue = 2
-------------------- Histogram --------------------
[87.286 ns ; 88.184 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

// * Summary *

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22635.3495)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100-preview.4.24215.10
  [Host]     : .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.21104), X64 RyuJIT AVX2


| Method               | Mean       | Error     | StdDev    | Rank | Gen0   | Allocated |
|--------------------- |-----------:|----------:|----------:|-----:|-------:|----------:|
| StringConcat         |  0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |      - |         - |
| StringInterpolation  |  0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |      - |         - |
| StringConcatWithJoin | 38.6974 ns | 0.1170 ns | 0.0977 ns |    2 | 0.0095 |      80 B |
| StringFormat         | 87.6339 ns | 0.2372 ns | 0.2103 ns |    3 | 0.0048 |      40 B |

// * Warnings *
ZeroMeasurement
  StringConcatBenchmarks.StringConcat: Default        -> The method duration is indistinguishable from the empty method duration
  StringConcatBenchmarks.StringInterpolation: Default -> The method duration is indistinguishable from the empty method duration

// * Hints *
Outliers
  StringConcatBenchmarks.StringConcat: Default         -> 3 outliers were removed (5.66 ns..5.77 ns)
  StringConcatBenchmarks.StringInterpolation: Default  -> 1 outlier  was  removed (5.27 ns)
  StringConcatBenchmarks.StringConcatWithJoin: Default -> 2 outliers were removed (44.55 ns, 44.67 ns)
  StringConcatBenchmarks.StringFormat: Default         -> 1 outlier  was  removed (93.67 ns)

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Rank      : Relative position of current benchmark mean among all benchmarks (Arabic style)
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ns      : 1 Nanosecond (0.000000001 sec)

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:01:51 (111.3 sec), executed benchmarks: 4

Global total time: 00:02:24 (144.97 sec), executed benchmarks: 4
// * Artifacts cleanup *
Artifacts cleanup is finished

c:\repos\fork\CodeMazeGuides\dotnet-client-libraries\BenchmarkDotNetWithUnitTests\BenchmarkDotNetWithUnitTests\~bin\Release\net9.0\BenchmarkDotNetWithUnitTests.exe (process 10868) exited with code 0.
Press any key to close this window . . .
*/
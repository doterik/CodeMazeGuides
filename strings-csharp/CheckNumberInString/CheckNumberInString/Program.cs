#if !DEBUG
using BenchmarkDotNet.Running;
using CheckNumberInString;
#endif
using static CheckNumberInString.ExtractNumber;

const string InputString = "The price is $42.75 for two items and $18.50 for one item.";
Console.WriteLine($"""
    String: '{InputString}'

    Extracting Number From String Using RegularExpression (RegEx) Method -> {ExtractNumberUsingRegEx(InputString)}
    Extracting Number From String Using Linq Method -> {ExtractNumbersUsingLinq(InputString)}
    Extracting Number From String Using StringBuilder Method -> {ExtractNumberUsingStringBuilder(InputString)}
    Extracting Number From String Using Span Method -> {ExtractNumberUsingSpan(InputString)}
    """);

#if !DEBUG
Console.Write("\nRun Benchmark? [Y/...] ");
if (Console.ReadKey(true).Key == ConsoleKey.Y) _ = BenchmarkRunner.Run<BenchmarkProcess>();
#endif

/*
| Method                                | Mean       | Error    | StdDev   | Ratio | Gen0   | Allocated |
|-------------------------------------- |-----------:|---------:|---------:|------:|-------:|----------:|
| ExtractNumberUsingLinqMethod          |   606.0 ns |  1.66 ns |  1.47 ns |  1.00 | 0.0639 |     536 B |
| ExtractNumberUsingStringBuilderMethod |   998.6 ns |  4.65 ns |  3.88 ns |  1.65 | 0.0439 |     368 B |
| ExtractNumberUsingRegExMethod         | 1,222.4 ns | 13.37 ns | 10.44 ns |  2.02 | 0.1087 |     912 B |
| ExtractNumberUsingSpanMethod          | 1,328.3 ns | 24.73 ns | 23.13 ns |  2.19 | 0.0210 |     176 B |


| Method                                | Mean       | Error    | StdDev   | Ratio | Gen0   | Allocated |
|-------------------------------------- |-----------:|---------:|---------:|------:|-------:|----------:|
| ExtractNumberUsingLinqMethod          |   831.0 ns | 10.44 ns |  9.77 ns |  1.00 | 0.0963 |     808 B |
| ExtractNumberUsingSpanMethod          |   862.0 ns | 13.01 ns | 10.86 ns |  1.04 | 0.0210 |     176 B |
| ExtractNumberUsingStringBuilderMethod | 1,000.5 ns |  6.37 ns |  4.97 ns |  1.20 | 0.0439 |     368 B |
| ExtractNumberUsingRegExMethod         | 1,289.4 ns | 24.90 ns | 23.29 ns |  1.55 | 0.1049 |     888 B |
*/

// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MoviesBenchmark;
// https://www.briangetsbinary.com/software%20engineering/dotnet/csharp/performance/2022/05/26/benchmarkdotnet-ef-core-vs-ef-6-part-1.html
Console.WriteLine("Begining Movies Bench Marks");

BenchmarkRunner.Run<MovieDbContextBenchMark>();
using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TestBenchmark
{
    static class EasiestTestClass
    {
        public static void OnTestsStart() =>
            BenchmarkRunner.Run<MyClass>();
    }
}

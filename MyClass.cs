using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace TestBenchmark
{
    public class MyClass
    {
        void _simulateWork()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
            return a.ToString();
        }

        public static void PbStaticVoid() {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
            return a.ToString();
        }

        [Benchmark(Description = "PbVoid")]
        public void PbVoid() =>
            _simulateWork();

        [Benchmark(Description = "PbVirtualVoid")]
        public virtual void PbVirtualVoid() =>
            _simulateWork();

        public static void PbGenericStaticVoid<T>()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
            return a.ToString();
        }

        public static void PbGenericStaticVoid() =>
            PbGenericStaticVoid<int>();


        [Benchmark(Description = "PbGenericVoid")]
        public void PbGenericVoid() =>
            _simulateWork();

        [Benchmark(Description = "PbDynamic")]
        public dynamic PbDynamic()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
            return a.ToString();
        }

    }
}

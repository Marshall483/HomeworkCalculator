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
            string a = "";
            for (int i = 0; i < 10000; i++)
                a += i.ToString();
        }

       // [Benchmark(Description = "PbStaticVoid")]
        public static void PbStaticVoid() {
            string a = "";
            for (int i = 0; i < 10000; i++)
                a += i.ToString();
        }

        [Benchmark(Description = "PbVoid")]
        public void PbVoid() =>
            _simulateWork();

        [Benchmark(Description = "PbVirtualVoid")]
        public virtual void PbVirtualVoid() =>
            _simulateWork();

        public static void PbGenericStaticVoid<T>()
        {
            string a = "";
            for (int i = 0; i < 10000; i++)
                a += i.ToString();
        }

        //[Benchmark(Description = "PbGenericStaticVoid")]
        public static void PbGenericStaticVoid() =>
            PbGenericStaticVoid<int>();


        [Benchmark(Description = "PbGenericVoid")]
        public void PbGenericVoid() =>
            _simulateWork();

        [Benchmark(Description = "PbDynamic")]
        public dynamic PbDynamic()
        {
            string a = "";
            for (int i = 0; i < 10000; i++)
                a += i.ToString();
            return a;
        }

    }
}

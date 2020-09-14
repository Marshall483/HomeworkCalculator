using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne
{
    class Program
    {
        static void PrintRes(int res) => Console.WriteLine($"Result: {res}");
        static void Main()
        {
            var a = Calculator.RequestValue();
            var @operator = Calculator.RequestOperator();
            var b = Calculator.RequestValue();
            var result = Calculator.Calculate(a, b, @operator);

            PrintRes(result);
            Console.ReadKey();
        }
    }
}

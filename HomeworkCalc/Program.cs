using System;

namespace HomeworkCalc
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

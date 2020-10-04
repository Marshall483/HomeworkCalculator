using System;

namespace HomeworkCalc
{
    class Program
    {
        static void PrintRes(int res) => Console.WriteLine($"Result: {res}");
        
        static void Main()
        {
            var a = Input.RequestValue();
            var action = Input.RequestOperator();
            var b = Input.RequestValue();
            var result = Calculator.Calculate(a, b, action);

            PrintRes(result);
            Console.ReadKey();
        }
    }
}

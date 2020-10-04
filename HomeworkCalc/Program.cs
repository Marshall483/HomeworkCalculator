using System;

namespace HomeworkCalc
{
    class Program
    {
        static void PrintRes(int res) => Console.WriteLine($"Result: {res}");
        
        static void Main()
        {
            var firstVal = Input.RequestValue();
            var action = Input.RequestOperator();
            var secVal = Input.RequestValue();
            var result = Calculator.Calculate(firstVal, secVal, action);

            PrintRes(result);
            Console.ReadKey();
        }
    }
}

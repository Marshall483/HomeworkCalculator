using System;

namespace HomeworkOne
{
    class Calculator
    {

        public static int GetValue() => int.Parse(Console.ReadLine());

        public static string GetOperator() => Console.ReadLine();
        public static string RequestOperator()
        {
            Console.WriteLine("Now write operation...");
            return GetOperator();
        }
        public static int RequestValue()
        {
            Console.WriteLine("Enter the value...");
            return GetValue();
        }
        static int Sum(int first, int second) => first + second;
        static int Difference(int first, int second) => first - second;
        static int Divide(int first, int second)
        {
            if (second != 0) return first / second;
            else Console.WriteLine("Divide by zero!");
            return -1;
        }
        static int Mult(int first, int second) => first * second;

        public static int Calculate(int first, int second, string @operator)
        {
            switch (@operator)
            {
                case "+": return Sum(first, second);
                case "-": return Difference(first, second);
                case "*": return Mult(first, second);
                case "/": return Divide(first, second);
                default: throw new NotSupportedException("Operation has not defined!");
            }
        }

    }
}

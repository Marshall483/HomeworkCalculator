using System;

namespace HomeworkCalc
{
    public class Calculator
    {  
        static int Sum(int first, int second) => first + second;
        static int Difference(int first, int second) => first - second;
        public static int Divide(int first, int second)
        {
            if (second != 0) return first / second;
            else throw new DivideByZeroException();
        }
        static int Mult(int first, int second) => first * second;

        public static int Calculate(int first, int second, string action)
        {
            switch (action)
            {
                case "+": return Sum(first, second);
                case "-": return Difference(first, second);
                case "*": return Mult(first, second);
                case "/": return Divide(first, second);
                default: throw new NotSupportedException();
            }
        }
    }
}
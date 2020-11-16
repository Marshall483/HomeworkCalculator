using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcOnline.Data.Interface;

namespace CalcOnline.Middleware
{
    public class Calculator : ICalculator
    {

        public int Sum(int first, int second) => first + second;
        public int Difference(int first, int second) => first - second;
        public int Divide(int first, int second)
        {
            if (second != 0) return first / second;
            else return int.MinValue;
        }
        public int Mult(int first, int second) => first * second;

        public int Calculate(int first, int second, string action)
        {
            switch (action)
            {
                case "+": return Sum(first, second);
                case "-": return Difference(first, second);
                case "*": return Mult(first, second);
                case "/": return Divide(first, second);
                default: return int.MinValue;
            }
        }
    }
}

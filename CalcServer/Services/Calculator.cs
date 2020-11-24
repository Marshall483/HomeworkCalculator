using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcOnline.Data.Interface;

namespace CalcOnline.Services
{
    public class Calculator : ICalculator
    {
        readonly char[] operators = { '+', '-', '*', '/' }; 
        public double Sum(double first, double second) => first + second;
        public double Difference(double first, double second) => first - second;
        public double Divide(double first, double second)
        {
            if (second != 0) return first / second;
            else return double.MinValue;
        }
        public double Mult(double first, double second) => first * second;

        public double Calculate(double first, double second, string action)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcOnline.Data.Interface
{
    public interface ICalculator
    {
        public double Sum(double left, double right);
        public double Difference(double left, double right);
        public double Divide(double left, double right);
        public double Mult(double left, double right);

        public double Calculate(double left, double right, string action);
    }
}

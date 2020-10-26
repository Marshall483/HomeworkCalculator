using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TrainingApp
{
    class Program
    {

        static void ExpressionAddition(double first, double second)
        {
            MethodInfo consoleWr = typeof(Console).GetMethod( "WriteLine" , new[] { typeof(double) });
            ParameterExpression _first = Expression.Parameter(typeof(double), "first");
            ParameterExpression _second = Expression.Parameter(typeof(double), "second");

            Expression[] param = new[] { _first, _second };

            BinaryExpression add = BinaryExpression.Add(_first, _second);
            MethodCallExpression call = Expression.Call(null, consoleWr, add);

            Expression<Action<double, double>> lambda = Expression.Lambda<Action<double, double>>(call, new[] { _first, _second });

            Action<double, double> compiled = lambda.Compile();

            compiled(first, second);

        }
        static void Main(string[] args)
        {
            ExpressionAddition(10, 20);
            Console.ReadKey();
        }
    }
}

using System;
using System.Linq.Expressions;
using System.Reflection;
using TrainingApp.Interfaces;
using TrainingApp.Services;

namespace TrainingApp
{
    class Program
    {

        static string _url = "https://localhost:44344/Calculator";

        static void Main(string[] args)
        {
            IConvertor convertor = new PostfixConvertor();
            IClient client = new JsonConnector(_url);
            IExpressionBuilder builder = new ExpressionBuilder();
            IVisitor visitor = new CalculatorExpressionVisitor(client);


            string pattern = "(2+3)/6*7+8*9";
            var postfixForm = convertor.ToPostfix(pattern);
            var expression = builder.BuildExpression(postfixForm);
            var result = visitor.VisitAsync(expression);

            Console.WriteLine(result.Result);
            
            Console.ReadKey();    
        }
    }
}

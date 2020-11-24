using System;
using TrainingApp.Data;
using TrainingApp.Interfaces;
using TrainingApp.Services;

namespace TrainingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Constants.Url;
            IConvertor convertor = new PostfixConvertor();
            IClient client = new JsonConnector(url);
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

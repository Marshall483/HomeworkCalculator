using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.Interfaces;

namespace TrainingApp.Services
{
    class CalculatorExpressionVisitor : ExpressionVisitor, IVisitor
    {

        readonly IClient _client;
        readonly Dictionary<ExpressionType, string> operationsDictionary = new Dictionary<ExpressionType, string>()
        {
            { ExpressionType.Add, "+" },
            { ExpressionType.Subtract, "-" },
            { ExpressionType.Multiply, "*" },
            { ExpressionType.Divide, "/" }
        };

        public CalculatorExpressionVisitor(IClient client) => 
            this._client = client; 


        public async Task<double> VisitAsync(Expression node)
        {
            string operation;

            if (node.NodeType.Equals(ExpressionType.Constant))
                return VisitConstant(node);
            else
                operation = operationsDictionary[node.NodeType];


            var thisBynaryNode = node as BinaryExpression;
            var deepToLeft = Task.Run( () => VisitAsync(thisBynaryNode.Left) );
            var deepToRight = Task.Run( () => VisitAsync(thisBynaryNode.Right) );
            await Task.Yield();
            var results = await Task.WhenAll(new[] { deepToLeft, deepToRight });
            var res = await _client.Connect(first: results[0],
                                            action: operation,
                                            second: results[1]);
            return res;
        }

        protected double VisitConstant(Expression node) =>
            Convert.ToDouble(((ConstantExpression)node).Value);
    }
}

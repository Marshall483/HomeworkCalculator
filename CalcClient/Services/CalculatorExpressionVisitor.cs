using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TrainingApp.Interfaces;

namespace TrainingApp.Services
{
    class CalculatorExpressionVisitor : ExpressionVisitor, IVisitor
    {
        readonly IClient _client;
        readonly Dictionary<ExpressionType, string> operationsDictionary;
        
        public CalculatorExpressionVisitor(IClient client)
        {
            this._client = client;
            operationsDictionary = new Dictionary<ExpressionType, string>()
            {
                { ExpressionType.Add, "+" },
                { ExpressionType.Subtract, "-" },
                { ExpressionType.Multiply, "*" },
                { ExpressionType.Divide, "/" }
            };
        }

        public async Task<double> VisitConstantAsync(Expression node)
        {
            string operation;

            var handleNodeType = Visit(node);
            
            if (node.NodeType.Equals(ExpressionType.Constant))
                return Convert.ToDouble((node as ConstantExpression).Value);
            else
                operation = operationsDictionary[node.NodeType];

            var thisBinaryNode = node as BinaryExpression;
            
            var deepToLeft = Task.Run( () => VisitConstantAsync(thisBinaryNode.Left ) );
            var deepToRight = Task.Run( () => VisitConstantAsync(thisBinaryNode.Right ) );
                await Task.Yield();
            
            var results = await Task.WhenAll(new[] { deepToLeft, deepToRight });
            var result = await _client.Connect(first: Convert.ToDouble(results[0]),
                                            action: operation,
                                            second: Convert.ToDouble(results[1]) );
            return result;
        }

        protected BinaryExpression Visit(BinaryExpression node) =>
            node;

        protected ConstantExpression Visit(ConstantExpression node) =>
            node;
    }
}

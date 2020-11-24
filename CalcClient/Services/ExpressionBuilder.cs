using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TrainingApp.Interfaces;

namespace TrainingApp.Services
{
    class ExpressionBuilder : IExpressionBuilder
    {
        public Expression BuildExpression(Queue<char> postfixForm) 
        {
            var exprassionStack = new Stack<Expression>();

            foreach(char token in postfixForm)
            {
                if (char.IsDigit(token))
                    exprassionStack.Push(Expression.Constant(Convert.ToDecimal(token.ToString()), typeof(decimal)));
                else
                {
                    Expression second = exprassionStack.Pop();
                    Expression first = exprassionStack.Pop();
                    switch (token)
                    {
                        case '+': exprassionStack.Push(Expression.Add(first, second)); break;
                        case '-': exprassionStack.Push(Expression.Subtract(first, second)); break;
                        case '*': exprassionStack.Push(Expression.Multiply(first, second)); break;
                        case '/': exprassionStack.Push(Expression.Divide(first, second)); break;
                    }
                }    
            }
            return exprassionStack.Pop();
        }
    }
}

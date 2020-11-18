using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TrainingApp.Interfaces;

namespace TrainingApp.Services
{
    class ExpressionBuilder : IExpressionBuilder
    {
        public Expression BuildExpression(Queue<char> postfixForm) // 12+34*-5/
        {
            Stack<Expression> exStk = new Stack<Expression>();

            foreach(char token in postfixForm)
            {
                if (char.IsDigit(token))
                    exStk.Push(Expression.Constant(Convert.ToDecimal(token.ToString()), typeof(decimal)));
                else
                {
                    Expression second = exStk.Pop();
                    Expression first = exStk.Pop();
                    switch (token)
                    {
                        case '+': exStk.Push(Expression.Add(first, second)); break;
                        case '-': exStk.Push(Expression.Subtract(first, second)); break;
                        case '*': exStk.Push(Expression.Multiply(first, second)); break;
                        case '/': exStk.Push(Expression.Divide(first, second)); break;
                    }
                }    
            }

            return exStk.Pop();
        }
    }
}

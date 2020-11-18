using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TrainingApp.Interfaces
{
    public interface IExpressionBuilder
    {

        public Expression BuildExpression(Queue<char> postfixForm);

    }
}

using System;
using Xunit;
using CalcOnline.Services;
using ExpressionProcessLibrary;
using System.Collections.Generic;

namespace xUnitTests
{
    public class Tests
    {

        [Theory]
        [InlineData(1, "+", 2, 3)]
        [InlineData(3.4, "-", 0.4, 3)]
        [InlineData(2.5, "*", 9, 22.5)]
        [InlineData(3.9, "/", 1.3, 3)]

        public void CanCalculateSimpleExpression(double left, string action, double right, double expected)
        {
            Calculator engine = new Calculator();

            var actual = engine.Calculate(left, right, action);

            Assert.Equal(actual, expected);

        }

        [Theory]
        [InlineData("1+2", new char[] { '1', '2', '+' })] //12+
        [InlineData("1+2*3", new char[] { '1', '2', '3', '*', '+' })] //123*+
        [InlineData("(1+2)*3", new char[] { '1', '2', '+', '3', '*' })] //12+3*
        [InlineData("(1+2)*(3+4)", new char[] { '1', '2', '+', '3', '4','+', '*' })] //12+34+*

        public void CanParseSimpleExpression(string expression, char[] expected)
        {
            IConvertor convertor = new PostfixConvertor();

            var actual = convertor.ToPostfix(expression);

            for (int i = 0; i < expected.Length; i++)
                Assert.Equal(actual.Dequeue(), expected[i]);

        }

    }
}

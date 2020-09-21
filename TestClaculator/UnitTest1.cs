using System;
using NUnit.Framework;
using HomeworkCalc;

namespace TestClaculator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Sum_42and_10_52returned()
        {
            int a = 42;
            int b = 10;
            string @operator = "+";
            int expected = 52;
            
             int actual = Calculator.Calculate(a, b, @operator);
             
             Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dif_89and_15returned74()
        {
            int a = 89;
            int b = 15;
            string @operator = "-";
            int expected = 74;
            
            int actual = Calculator.Calculate(a, b, @operator);
             
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Div_32and_8_expected4()
        {
            int a = 32;
            int b = 8;
            string @operator = "/";
            int expected = 4;
            
            int actual = Calculator.Calculate(a, b, @operator);
             
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DivByZero_ErrExpected()
        {
            int a = 0;
            int b = 0;
            string @operator = "/";
            
            Assert.Throws<DivideByZeroException>( 
                () => Calculator.Calculate(a, b, @operator));
        }

        [Test]
        public void Mult_16and_4_64expected()
        {
        int a = 16;
        int b = 4;
        string @operator = "*";
        int expected = 64;
            
        int actual = Calculator.Calculate(a, b, @operator);
             
        Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InvalidOperation_ErrExpected()
        {
            int a = 0;
            int b = 0;
            string @operator = "InvalidOperator";

            Assert.Throws<NotSupportedException>(
                () => Calculator.Calculate(a, b, @operator));
        }

        [Test]
        public void DivideMeth_9And3_3Expected()
        {
            int a = 9;
            int b = 3;
            int expected = 3;
            
            int actual = Calculator.Divide(a, b);
             
            Assert.AreEqual(expected, actual); 
        }
        
        [Test]
        public void DivideMeth_ErrExpected()
        {
            int a = 0;
            int b = 0;
            
            Assert.Throws<DivideByZeroException>(
                () => Calculator.Divide(a, b));
        }

    }
}
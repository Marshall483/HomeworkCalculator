using NUnit.Framework;

namespace HomeworkOne
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void Sum()
        {
            Assert.AreEqual(20, Calculator.Calculate(13, 7, "+"));
        }

        [TestCase]
        public void Sub()
        {
            Assert.AreEqual(34, Calculator.Calculate(45, 11, "-"));
        }

        [TestCase]
        public void Div()
        {
            Assert.AreEqual(7, Calculator.Calculate(49, 7, "/"));
        }

        [TestCase]
        public void DivByZero()
        {
            Assert.AreEqual(-1, Calculator.Calculate(0, 0, "/"));
        }

        [TestCase]
        public void Mult()
        {
            Assert.AreEqual(75, Calculator.Calculate(25, 3, "*"));
        }

    }
}

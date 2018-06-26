using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class MinTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Min_InnerCalculation_CorrectValue()
        {
            func.Function = @"Min(1+1, 1+2, 1+3)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Min_NestedMinFunctions_CorrectValue()
        {
            func.Function = @"Min(6, Min(5, 4, Min(3,2,1)), 7)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_Add_IsCorrect()
        {
            func.Function = @"min(5,6)+min(1, 2, 3, 4)";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_Decimal_Multiply_Both_IsCorrect()
        {
            func.Function = @"4*min(5,6)";
            Assert.AreEqual(20, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_IsCorrect()
        {
            func.Function = @"Min(1, 2, 3, 4)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_Multiply_1_IsCorrect()
        {
            func.Function = @"min(5,6)*min(1, 2, 3, 4)";
            Assert.AreEqual(5, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_Multiply_Post_IsCorrect()
        {
            func.Function = @"min(5, 2, 3, 4)*2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_Subtract_Decimal_Devide_IsCorrect()
        {
            func.Function = @"(Min(6.5,6.7)-Min(1.5, 2, 3, 4))/2";
            Assert.AreEqual(2.5, func.EvaluateNumeric());
        }

        [Test]
        public void Min_Numbers_Subtract_Decimal_IsCorrect()
        {
            func.Function = @"min(5.5,6)-min(2, 3, 1.5, 2, 3, 4)";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Min_NumbersAndVariable_EmptyVariableIgnored()
        {
            func.Function = @"min(a, 2, 3, 4)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Min_TwoSumFunctions_NoException()
        {
            func.Function = @"Min(1) + Min(1)";
        }

        [Test]
        public void Min_TwoSumFunctions001_CorrectValue()
        {
            func.Function = @"Min(1) + Min(1)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Min_WithVariable001_CorrectValue()
        {
            func.Function = @"Min(a, b)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(1, func.EvaluateNumeric());
        }
    }
}

using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class MaxTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Max_InnerCalculation_CorrectValue()
        {
            func.Function = @"Max(1+1, 1+2, 1+3)";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Max_NestedMaxFunctions_CorrectValue()
        {
            func.Function = @"Max(6, Max(5, 4, Max(3,2,8)), 7)";
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_Add_IsCorrect()
        {
            func.Function = @"Max(5,6)+Max(1, 2, 3, 4)";
            Assert.AreEqual(10, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_Decimal_Multiply_Both_IsCorrect()
        {
            func.Function = @"4*Max(5,6)";
            Assert.AreEqual(24, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_IsCorrect()
        {
            func.Function = @"Max(1, 2, 4, 3)";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_Multiply_1_IsCorrect()
        {
            func.Function = @"Max(5,6)*Max(1, 2, 3, 4)";
            Assert.AreEqual(24, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_Multiply_Post_IsCorrect()
        {
            func.Function = @"Max(5, 2, 3, 4)*2";
            Assert.AreEqual(10, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_Subtract_Decimal_Devide_IsCorrect()
        {
            func.Function = @"(Max(6.5,6.7)-Max(1.5, 2, 3, 4))/2";
            Assert.AreEqual(1.35, func.EvaluateNumeric());
        }

        [Test]
        public void Max_Numbers_Subtract_Decimal_IsCorrect()
        {
            func.Function = @"Max(5.5,6.2)-Max(2, 3, 1.5, 2, 3, 4)";
            Assert.AreEqual(2.2d, func.EvaluateNumeric());
        }

        [Test]
        public void Max_NumbersAndVariable_EmptyVariableIgnored()
        {
            func.Function = @"Max(a, 2, 3, 4)";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Max_TwoSumFunctions_NoException() { func.Function = @"Max(1) + Max(1)"; }

        [Test]
        public void Max_TwoSumFunctions001_CorrectValue()
        {
            func.Function = @"Max(1) + Max(1)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Max_WithVariable001_CorrectValue()
        {
            func.Function = @"Max(a, b)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(2, func.EvaluateNumeric());
        }
    }
}

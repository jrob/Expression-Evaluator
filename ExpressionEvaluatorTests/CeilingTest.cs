using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class CeilingTest
    {
        private Expression func;

        [SetUp]
        public void init()
        {
            func = new Expression("");
        }

        [TearDown]
        public void clear()
        {
            func.Clear();
        }

        [Test]
        public void Ceiling_InnerCalclationAdd_CorrectValue()
        {
            func.Function = @"ceiling(3+1.5)";
            Assert.AreEqual(5, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculation_CorrectValue()
        {
            func.Function = @"ceiling(3.1)";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationDevide_CorrectValue()
        {
            func.Function = @"ceiling(5/3)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationMulti_CorrectValue()
        {
            func.Function = @"ceiling(5*1.5)";
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationNegative_CorrectValue()
        {
            func.Function = @"ceiling(-0.12 )";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationNegativeRound_CorrectValue()
        {
            func.Function = @"ceiling(-7.12 )";
            Assert.AreEqual(-7, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationParenthesis_CorrectValue()
        {
            func.Function = @"ceiling(3/4+4)";
            Assert.AreEqual(5, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationParens_CorrectValue()
        {
            func.Function = @"ceiling(6+{3/4+4})";
            Assert.AreEqual(11, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationSubstract_CorrectValue()
        {
            func.Function = @"ceiling(2.56 -1.5)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_MidPoint001_CorrectValue()
        {
            func.Function = @"ceiling(1.5*0)";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_InnerCalculationParenthesisSum_CorrectValue()
        {
            func.Function = @"ceiling(6+{3/sum(4,4)})";
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(
            typeof(ExpressionException), ExpectedMessage = "Ceiling",
            MatchType = MessageMatch.Contains)]
        public void Ceiling_TooManyParameters_CorrectValue()
        {
            func.Function = @"ceiling(1.123, 2, 3)";
            Assert.AreEqual(1.12m, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_TrailingDigits001_CorrectValue()
        {
            func.Function = @"ceiling(1.123, 1)";
            Assert.AreEqual(1.2m, func.EvaluateNumeric());
        }

        [Test]
        public void Ceiling_TrailingDigits002_CorrectValue()
        {
            func.Function = @"ceiling(1.123, 2)";
            Assert.AreEqual(1.13m, func.EvaluateNumeric());
        }
    }
}

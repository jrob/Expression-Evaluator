using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class HoursFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void HoursOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "hours(2)";
            Assert.AreEqual(new TimeSpan(72000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "hours(0.5)";
            Assert.AreEqual(new TimeSpan(18000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "hours(-2)";
            Assert.AreEqual(new TimeSpan(-72000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "hours(-0.5)";
            Assert.AreEqual(new TimeSpan(-18000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            var func = "hours(2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            var func = "hours(0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            var func = "hours(-2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            var func = "hours(-0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            var func = "hours 2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            var func = "hours 0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            var func = "hours -2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            var func = "hours -0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            var func = "hours 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            var func = "hours 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            var func = "hours -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            var func = "hours -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class MinutesFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void MinutesOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "minutes(2)";
            Assert.AreEqual(new TimeSpan(1200000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void MinutesOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "minutes(0.5)";
            Assert.AreEqual(new TimeSpan(300000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void MinutesOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "minutes(-2)";
            Assert.AreEqual(new TimeSpan(-1200000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void MinutesOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "minutes(-0.5)";
            Assert.AreEqual(new TimeSpan(-300000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            var func = "minutes(2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            var func = "minutes(0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            var func = "minutes(-2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            var func = "minutes(-0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            var func = "minutes 2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            var func = "minutes 0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            var func = "minutes -2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            var func = "minutes -0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            var func = "minutes 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            var func = "minutes 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            var func = "minutes -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void MinutesOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            var func = "minutes -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

    }
}

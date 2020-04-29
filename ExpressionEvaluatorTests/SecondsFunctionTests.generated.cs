using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SecondsFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void SecondsOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "seconds(2)";
            Assert.AreEqual(new TimeSpan(20000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void SecondsOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "seconds(0.5)";
            Assert.AreEqual(new TimeSpan(5000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void SecondsOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "seconds(-2)";
            Assert.AreEqual(new TimeSpan(-20000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void SecondsOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "seconds(-0.5)";
            Assert.AreEqual(new TimeSpan(-5000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            var func = "seconds(2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            var func = "seconds(0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            var func = "seconds(-2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            var func = "seconds(-0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            var func = "seconds 2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            var func = "seconds 0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            var func = "seconds -2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            var func = "seconds -0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            var func = "seconds 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            var func = "seconds 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            var func = "seconds -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            var func = "seconds -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

    }
}

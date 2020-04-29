using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AbsFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void AbsOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "abs(2)";
            Assert.AreEqual(2d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "abs(0.5)";
            Assert.AreEqual(0.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "abs(-2)";
            Assert.AreEqual(2d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "abs(-0.5)";
            Assert.AreEqual(0.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            var func = "abs(2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            var func = "abs(0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            var func = "abs(-2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            var func = "abs(-0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Close missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            var func = "abs 2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            var func = "abs 0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            var func = "abs -2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            var func = "abs -0.5)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open missing", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            var func = "abs 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            var func = "abs 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            var func = "abs -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            var func = "abs -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Open and close parenthesis required", ex.Message);
        }

    }
}

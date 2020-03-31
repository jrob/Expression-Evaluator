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
            Assert.Throws<ExpressionException>(() => _func.Function = "abs(2", "Close missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs(0.5", "Close missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs(-2", "Close missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs(0.5", "Close missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs 2)", "Close missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs 0.5)", "Close missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs -2)", "Open missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs -0.5)", "Open missing");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs 2", "Open and close parenthesis required");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs 0.5", "Open and close parenthesis required");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs -2", "Open and close parenthesis required");
        }

        [Test]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "abs -0.5", "Open and close parenthesis required");
        }

    }
}

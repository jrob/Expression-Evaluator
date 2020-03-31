using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LnFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void LnOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "ln(2)";
            Assert.AreEqual(0.69314718055994529d, _func.EvaluateNumeric());
        }

        [Test]
        public void LnOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "ln(0.5)";
            Assert.AreEqual(-0.69314718055994529d, _func.EvaluateNumeric());
        }

        [Test]
        public void LnOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "ln(-2)";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void LnOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "ln(-0.5)";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln(2", "Close missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln(0.5", "Close missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln(-2", "Close missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln(-0.5", "Close missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln 2)", "Open missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln 0.5)", "Open missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln -2)", "Open missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln -0.5)", "Open missing");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln 2", "Open and close parenthesis required");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln 0.5", "Open and close parenthesis required");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln -2", "Open and close parenthesis required");
        }

        [Test]
        public void LnOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "ln -0.5", "Open and close parenthesis required");
        }

    }
}

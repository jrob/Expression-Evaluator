using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NegFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void NegOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "neg(2)";
            Assert.AreEqual(-2d, _func.EvaluateNumeric());
        }

        [Test]
        public void NegOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "neg(0.5)";
            Assert.AreEqual(-0.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void NegOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "neg(-2)";
            Assert.AreEqual(2d, _func.EvaluateNumeric());
        }

        [Test]
        public void NegOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "neg(-0.5)";
            Assert.AreEqual(0.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg(2", "Close missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg(0.5", "Close missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg(-2", "Close missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg(-0.5", "Close missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg 2)", "Open missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg 0.5)", "Open missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg -2)", "Open missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg -0.5)", "Open missing");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg 2", "Open and close parenthesis required");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg 0.5", "Open and close parenthesis required");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg -2", "Open and close parenthesis required");
        }

        [Test]
        public void NegOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "neg -0.5", "Open and close parenthesis required");
        }

    }
}

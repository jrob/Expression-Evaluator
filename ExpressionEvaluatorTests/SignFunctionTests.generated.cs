using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SignFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void SignOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "sign(2)";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SignOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "sign(0.5)";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SignOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "sign(-2)";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SignOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "sign(-0.5)";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign(2", "Close missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign(0.5", "Close missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign(-2", "Close missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign(-0.5", "Close missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign 2)", "Open missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign 0.5)", "Open missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign -2)", "Open missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign -0.5)", "Open missing");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign 2", "Open and close parenthesis required");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign 0.5", "Open and close parenthesis required");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign -2", "Open and close parenthesis required");
        }

        [Test]
        public void SignOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "sign -0.5", "Open and close parenthesis required");
        }

    }
}

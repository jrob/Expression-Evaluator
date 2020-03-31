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
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds(2", "Close missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds(0.5", "Close missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds(-2", "Close missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds(-0.5", "Close missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds 2)", "Open missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds 0.5)", "Open missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds -2)", "Open missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds -0.5)", "Open missing");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds 2", "Open and close parenthesis required");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds 0.5", "Open and close parenthesis required");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds -2", "Open and close parenthesis required");
        }

        [Test]
        public void SecondsOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "seconds -0.5", "Open and close parenthesis required");
        }

    }
}

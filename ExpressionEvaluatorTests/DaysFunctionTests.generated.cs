using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DaysFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void DaysOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "days(2)";
            Assert.AreEqual(new TimeSpan(1728000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "days(0.5)";
            Assert.AreEqual(new TimeSpan(432000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "days(-2)";
            Assert.AreEqual(new TimeSpan(-1728000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "days(-0.5)";
            Assert.AreEqual(new TimeSpan(-432000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days(2", "Close missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days(0.5", "Close missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days(-2", "Close missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days(-0.5", "Close missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days 2)", "Open missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days 0.5)", "Open missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days -2)", "Open missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days -0.5)", "Open missing");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days 2", "Open and close parenthesis required");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days 0.5", "Open and close parenthesis required");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days -2", "Open and close parenthesis required");
        }

        [Test]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "days -0.5", "Open and close parenthesis required");
        }

    }
}

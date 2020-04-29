using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class MultiplicationOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 * 2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 * 0.5";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 * -2";
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 * -0.5";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 * 2";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 * 0.5";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 * -2";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 * -0.5";
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 * 2";
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 * 0.5";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 * -2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 * -0.5";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 * 2";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 * 0.5";
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 * -2";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 * -0.5";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a * -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 * a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 * a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 * a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 * a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 * a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 * a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 * a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 * a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 * a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 * a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 * a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 * a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 * a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 * a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 * a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 * a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a * b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            var func = "2 *";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            var func = "0.5 *";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            var func = "-2 *";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            var func = "-0.5 *";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            var func = "* 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            var func = "* 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            var func = "* -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultiplicationOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            var func = "* -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

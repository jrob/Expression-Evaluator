using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AdditionOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 + 2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 + 0.5";
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 + -2";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 + -0.5";
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 + 2";
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 + 0.5";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 + -2";
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 + -0.5";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 + 2";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 + 0.5";
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 + -2";
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 + -0.5";
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 + 2";
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 + 0.5";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 + -2";
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 + -0.5";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a + -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 + a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 + a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 + a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 + a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 + a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 + a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 + a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 + a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 + a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 + a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 + a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 + a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 + a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 + a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 + a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 + a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            var func = "2 +";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            var func = "0.5 +";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            var func = "-2 +";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            var func = "-0.5 +";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            var func = "+ 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            var func = "+ 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            var func = "+ -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AdditionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            var func = "+ -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

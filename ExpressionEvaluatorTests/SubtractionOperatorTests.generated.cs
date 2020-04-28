using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SubtractionOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 - 2";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 - 0.5";
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 - -2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 - -0.5";
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 - 2";
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 - 0.5";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 - -2";
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 - -0.5";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 - 2";
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 - 0.5";
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 - -2";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 - -0.5";
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 - 2";
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 - 0.5";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 - -2";
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 - -0.5";
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a - -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 - a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 - a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 - a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 - a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 - a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 - a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 - a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 - a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 - a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 - a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 - a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 - a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 - a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 - a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 - a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 - a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-2.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(1.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0d, _func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            var func = "2 -";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void SubtractionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            var func = "0.5 -";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void SubtractionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            var func = "-2 -";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void SubtractionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            var func = "-0.5 -";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void SubtractionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            var func = "- -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void SubtractionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            var func = "- -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

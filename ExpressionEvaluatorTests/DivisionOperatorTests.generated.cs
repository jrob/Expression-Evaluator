using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DivisionOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 / 2";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 / 0.5";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 / -2";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 / -0.5";
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 / 2";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 / 0.5";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 / -2";
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 / -0.5";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 / 2";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 / 0.5";
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 / -2";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 / -0.5";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 / 2";
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 / 0.5";
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 / -2";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 / -0.5";
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a / -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 / a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 / a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 / a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 / a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 / a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 / a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 / a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 / a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 / a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 / a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 / a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 / a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 / a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 / a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 / a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 / a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(-0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a / b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1d, _func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "2 /", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "0.5 /", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-2 /", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-0.5 /", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "/ 2", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "/ 0.5", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "/ -2", "Operator error");
        }

        [Test]
        public void DivisionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "/ -0.5", "Operator error");
        }

    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PowerOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 ^ 2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 ^ 0.5";
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 ^ -2";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 ^ -0.5";
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 ^ 2";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 ^ 0.5";
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 ^ -2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 ^ -0.5";
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 ^ 2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 ^ 0.5";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 ^ -2";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 ^ -0.5";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 ^ 2";
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 ^ 0.5";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 ^ -2";
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 ^ -0.5";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a ^ -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 ^ a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 ^ a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 ^ a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 ^ a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 ^ a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 ^ a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 ^ a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 ^ a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 ^ a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 ^ a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 ^ a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 ^ a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 ^ a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 ^ a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 ^ a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 ^ a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0.70710678118654757d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1.4142135623730952d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(0.25d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a ^ b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "2 ^", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "0.5 ^", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-2 ^", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-0.5 ^", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "^ 2", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "^ 0.5", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "^ -2", "Operator error");
        }

        [Test]
        public void PowerOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "^ -0.5", "Operator error");
        }

    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class GreaterEqualOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 >= 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 >= 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 >= -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 >= -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 >= 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 >= 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 >= -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 >= -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 >= 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 >= 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 >= -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 >= -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 >= 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 >= 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 >= -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 >= -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a >= -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 >= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 >= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 >= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 >= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 >= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 >= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 >= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 >= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 >= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 >= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 >= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 >= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 >= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 >= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 >= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 >= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            var func = "2 >=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            var func = "0.5 >=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            var func = "-2 >=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            var func = "-0.5 >=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            var func = ">= 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            var func = ">= 0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            var func = ">= -2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqualOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            var func = ">= -0.5";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

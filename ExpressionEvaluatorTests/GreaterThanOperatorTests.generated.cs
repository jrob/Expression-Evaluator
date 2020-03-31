using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class GreaterThanOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 > 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 > 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 > -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 > -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 > 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 > 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 > -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 > -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 > 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 > 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 > -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 > -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 > 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 > 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 > -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 > -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a > -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 > a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 > a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 > a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 > a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 > a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 > a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 > a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 > a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 > a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 > a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 > a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 > a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 > a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 > a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 > a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 > a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "2 >", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "0.5 >", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-2 >", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-0.5 >", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "> 2", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "> 0.5", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "> -2", "Operator error");
        }

        [Test]
        public void GreaterThanOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "> -0.5", "Operator error");
        }

    }
}

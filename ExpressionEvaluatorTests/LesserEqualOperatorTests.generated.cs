using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LesserEqualOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 <= 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 <= 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 <= -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 <= -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 <= 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 <= 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 <= -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 <= -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 <= 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 <= 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 <= -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 <= -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 <= 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 <= 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 <= -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 <= -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a <= -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 <= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 <= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 <= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 <= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 <= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 <= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 <= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 <= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 <= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 <= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 <= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 <= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 <= a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 <= a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 <= a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 <= a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "2 <=", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "0.5 <=", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-2 <=", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-0.5 <=", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "<= 2", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "<= 0.5", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "<= -2", "Operator error");
        }

        [Test]
        public void LesserEqualOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "<= -0.5", "Operator error");
        }

    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LesserThanOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 < 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 < 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 < -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 < -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 < 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 < 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 < -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 < -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 < 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 < 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 < -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 < -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 < 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 < 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 < -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 < -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a < -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 < a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 < a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 < a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 < a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 < a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 < a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 < a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 < a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 < a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 < a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 < a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 < a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 < a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 < a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 < a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 < a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "2 <", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "0.5 <", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-2 <", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-0.5 <", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "< 2", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "< 0.5", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "< -2", "Operator error");
        }

        [Test]
        public void LesserThanOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "< -0.5", "Operator error");
        }

    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NotEqualNumericOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "2 != 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "2 != 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "2 != -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "2 != -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "0.5 != 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "0.5 != 0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "0.5 != -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "0.5 != -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-2 != 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-2 != 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-2 != -2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-2 != -0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            _func.Function = "-0.5 != 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            _func.Function = "-0.5 != 0.5";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            _func.Function = "-0.5 != -2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            _func.Function = "-0.5 != -0.5";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -2";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -0.5";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -2";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -0.5";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -2";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -0.5";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != 0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -2";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "a != -0.5";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 != a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 != a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "2 != a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "2 != a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 != a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 != a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 != a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "0.5 != a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 != a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 != a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 != a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-2 != a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 != a";
            _func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 != a";
            _func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 != a";
            _func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            _func.Function = "-0.5 != a";
            _func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -2d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", -0.5d);
            _func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "2 !=", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "0.5 !=", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-2 !=", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "-0.5 !=", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "!= 2", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "!= 0.5", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "!= -2", "Operator error");
        }

        [Test]
        public void NotEqualNumericOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "!= -0.5", "Operator error");
        }

    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class EqualBooleanOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrue_IsCorrect()
        {
            _func.Function = "True == True";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalse_IsCorrect()
        {
            _func.Function = "True == False";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrue_IsCorrect()
        {
            _func.Function = "False == True";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalse_IsCorrect()
        {
            _func.Function = "False == False";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == True";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == False";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == True";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == False";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrueWithRightVariable_IsCorrect()
        {
            _func.Function = "True == a";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalseWithRightVariable_IsCorrect()
        {
            _func.Function = "True == a";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrueWithRightVariable_IsCorrect()
        {
            _func.Function = "False == a";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalseWithRightVariable_IsCorrect()
        {
            _func.Function = "False == a";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrueWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalseWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrueWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", false);
            _func.AddSetVariable("b", true);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalseWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", false);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_MalformedExpressionBooleanTrueLeftOfOperator_ThrowsException()
        {
            var func = "True ==";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void EqualBooleanOperator_MalformedExpressionBooleanFalseLeftOfOperator_ThrowsException()
        {
            var func = "False ==";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void EqualBooleanOperator_MalformedExpressionBooleanTrueRightOfOperator_ThrowsException()
        {
            var func = "== True";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void EqualBooleanOperator_MalformedExpressionBooleanFalseRightOfOperator_ThrowsException()
        {
            var func = "== False";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

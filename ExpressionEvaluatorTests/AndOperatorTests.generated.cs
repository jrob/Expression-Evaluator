using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AndOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrue_IsCorrect()
        {
            _func.Function = "True && True";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalse_IsCorrect()
        {
            _func.Function = "True && False";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrue_IsCorrect()
        {
            _func.Function = "False && True";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalse_IsCorrect()
        {
            _func.Function = "False && False";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            _func.Function = "a && True";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            _func.Function = "a && False";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            _func.Function = "a && True";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            _func.Function = "a && False";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrueWithRightVariable_IsCorrect()
        {
            _func.Function = "True && a";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalseWithRightVariable_IsCorrect()
        {
            _func.Function = "True && a";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrueWithRightVariable_IsCorrect()
        {
            _func.Function = "False && a";
            _func.AddSetVariable("a", true);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalseWithRightVariable_IsCorrect()
        {
            _func.Function = "False && a";
            _func.AddSetVariable("a", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrueWithVariable_IsCorrect()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalseWithVariable_IsCorrect()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrueWithVariable_IsCorrect()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", false);
            _func.AddSetVariable("b", true);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalseWithVariable_IsCorrect()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", false);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_MalformedExpressionBooleanTrueLeftOfOperator_ThrowsException()
        {
            var func = "True &&";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AndOperator_MalformedExpressionBooleanFalseLeftOfOperator_ThrowsException()
        {
            var func = "False &&";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AndOperator_MalformedExpressionBooleanTrueRightOfOperator_ThrowsException()
        {
            var func = "&& True";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void AndOperator_MalformedExpressionBooleanFalseRightOfOperator_ThrowsException()
        {
            var func = "&& False";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

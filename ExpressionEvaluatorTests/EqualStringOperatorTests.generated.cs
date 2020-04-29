using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class EqualStringOperatorTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirst_IsCorrect()
        {
            _func.Function = "'first' == 'first'";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecond_IsCorrect()
        {
            _func.Function = "'first' == '1sec.ond'";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirst_IsCorrect()
        {
            _func.Function = "'1sec.ond' == 'first'";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecond_IsCorrect()
        {
            _func.Function = "'1sec.ond' == '1sec.ond'";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirstWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == 'first'";
            _func.AddSetVariable("a", "first");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecondWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == '1sec.ond'";
            _func.AddSetVariable("a", "first");
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == 'first'";
            _func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithLeftVariable_IsCorrect()
        {
            _func.Function = "a == '1sec.ond'";
            _func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirstWithRightVariable_IsCorrect()
        {
            _func.Function = "'first' == a";
            _func.AddSetVariable("a", "first");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecondWithRightVariable_IsCorrect()
        {
            _func.Function = "'first' == a";
            _func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithRightVariable_IsCorrect()
        {
            _func.Function = "'1sec.ond' == a";
            _func.AddSetVariable("a", "first");
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithRightVariable_IsCorrect()
        {
            _func.Function = "'1sec.ond' == a";
            _func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirstWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", "first");
            _func.AddSetVariable("b", "first");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecondWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", "first");
            _func.AddSetVariable("b", "1sec.ond");
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", "1sec.ond");
            _func.AddSetVariable("b", "first");
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithVariable_IsCorrect()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", "1sec.ond");
            _func.AddSetVariable("b", "1sec.ond");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_MalformedExpressionStringFirstLeftOfOperator_ThrowsException()
        {
            var func = "'first' ==";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void EqualStringOperator_MalformedExpressionStringSecondLeftOfOperator_ThrowsException()
        {
            var func = "'1sec.ond' ==";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void EqualStringOperator_MalformedExpressionStringFirstRightOfOperator_ThrowsException()
        {
            var func = "== 'first'";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void EqualStringOperator_MalformedExpressionStringSecondRightOfOperator_ThrowsException()
        {
            var func = "== '1sec.ond'";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

    }
}

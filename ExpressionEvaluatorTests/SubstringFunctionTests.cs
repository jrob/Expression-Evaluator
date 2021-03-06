﻿using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SubstringFunctionTests
    {
        private Expression _func;

        [SetUp]
        public void Init()
        {
            _func = new Expression("");
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        public void SubstringOperator_CalledWithFloat_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0.1, 3)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = _func.Evaluate<String>());
            StringAssert.Contains("One or more of the substring parameters contain decimals and not integers", ex.Message);
        }

        [Test]
        public void SubstringOperator_CalledWithIntegers_IsCorrect()
        {
            _func.Function = "substring('hello', 0, 3)";
            NUnit.Framework.Assert.AreEqual("hel", _func.Evaluate<String>());
        }

        [Test]
        public void SubstringOperator_CalledWithNegativeIndex_IsCorrect()
        {
            _func.Function = "substring('hello', -1, 3)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = _func.Evaluate<String>());
            StringAssert.Contains("StartIndex cannot be less than zero.", ex.Message);
        }

        [Test]
        public void SubstringOperator_ExecuteSubstringOnNonString_OperatorError()
        {
            _func.Function = "substring(3a, 0, 1)";
            ExpressionException ex = Assert.Throws<InvalidTypeExpressionException>(() => _func.Function = _func.Evaluate<String>());
            StringAssert.Contains("Result was null because of an invalid type", ex.Message);
        }

        [Test]
        public void SubstringOperator_InnerCalculation_IsCorrect()
        {
            _func.Function = "substring('hello', 1-1, 1+2)";
            NUnit.Framework.Assert.AreEqual("hel", _func.Evaluate<String>());
        }

        [Test]
        public void SubstringOperator_PositiveFractionNotIntegerWithLeftVariable_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0, a)";
            _func.AddSetVariable("a", 2.1);
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = _func.Evaluate<String>());
            StringAssert.Contains("One or more of the substring parameters contain decimals and not integers", ex.Message);
        }

        [Test]
        public void SubstringOperator_PositiveFractionWithLeftVariableOfWrongType_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0, a)";
            _func.AddSetVariable("a", "b");
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = _func.Evaluate<String>());
            StringAssert.Contains("Substring operator used incorrectly", ex.Message);
        }

        [Test]
        public void SubstringOperator_VariableWithoutSetVariable_OperatorError()
        {
            _func.Function = "substring('hello', a, 2)";
            ExpressionException ex = Assert.Throws<InvalidTypeExpressionException>(() => _func.Function = _func.Evaluate<String>());
            StringAssert.Contains("Result was null because of an invalid type", ex.Message);
        }
    }
}

using System;
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
            Assert.Throws<ExpressionException>(() => _func.Evaluate<String>(), "One or more of the substring parameters contain decimals and not integers");
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
            Assert.Throws<ExpressionException>(() => _func.Evaluate<String>(), "StartIndex cannot be less than zero.");
        }

        [Test]
        public void SubstringOperator_ExecuteSubstringOnNonString_OperatorError()
        {
            _func.Function = "substring(3a, 0, 1)";
            Assert.Throws<InvalidTypeExpressionException>(() => _func.Evaluate<String>(), "Result was null because of an invalid type");
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
            Assert.Throws<ExpressionException>(() => _func.Evaluate<String>(), "One or more of the substring parameters contain decimals and not integers");
        }

        [Test]
        public void SubstringOperator_PositiveFractionWithLeftVariableOfWrongType_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0, a)";
            _func.AddSetVariable("a", "b");
            Assert.Throws<ExpressionException>(() => _func.Evaluate<String>(), "Substring operator used incorrectly");
        }

        [Test]
        public void SubstringOperator_VariableWithoutSetVariable_OperatorError()
        {
            _func.Function = "substring('hello', a, 2)";
            Assert.Throws<InvalidTypeExpressionException>(() => _func.Evaluate<String>(), "Result was null because of an invalid type");
        }
    }
}

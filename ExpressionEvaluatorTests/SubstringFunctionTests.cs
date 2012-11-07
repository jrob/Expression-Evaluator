using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    [TestClass]
    public class SubstringFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void SubstringOperator_CalledWithIntegers_IsCorrect()
        {
            func.Function = "substring('hello', 0, 3)";
            NUnit.Framework.Assert.AreEqual("hel", func.Evaluate<String>());
        }
        
        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error! \"substring\".", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_CalledWithNegativeIndex_IsCorrect()
        {
            func.Function = "substring('hello', -1, 3)";
            func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "One or more of the substring parameters contain decimals and not integers", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_CalledWithFloat_IsNotCorrect()
        {
            func.Function = "substring('hello', 0.1, 3)";
            func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "One or more of the substring parameters contain decimals and not integers", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_PositiveFractionNotIntegerWithLeftVariable_IsNotCorrect()
        {
            func.Function = "substring('hello', 0, a)";
            func.AddSetVariable("a", 2.1);
            func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "Substring operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_PositiveFractionWithLeftVariableOfWrongType_IsNotCorrect()
        {
            func.Function = "substring('hello', 0, a)";
            func.AddSetVariable("a", "b");
            func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(InvalidTypeExpressionException), ExpectedMessage = "Result was null because of an invalid type", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_VariableWithoutSetVariable_OperatorError()
        {
            func.Function = "substring('hello', a, 2)";
            func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(InvalidTypeExpressionException), ExpectedMessage = "Result was null because of an invalid type", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_ExecuteSubstringOnNonString_OperatorError()
        {
            func.Function = "substring(3a, 0, 1)";
            func.Evaluate<String>();
        }

    }
}

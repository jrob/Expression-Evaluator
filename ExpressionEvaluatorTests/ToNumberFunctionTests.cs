using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    [TestClass]
    public class ToNumberFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void ToNumberOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "toNumber('2')";
            NUnit.Framework.Assert.AreEqual(2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithPositiveDecimal_IsCorrect()
        {
            func.Function = "toNumber('2.3')";
            NUnit.Framework.Assert.AreEqual(2.3, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "toNumber('-2')";
            NUnit.Framework.Assert.AreEqual(-2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_PositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "toNumber(a)";
            func.AddSetVariable("a", "0.5");
            NUnit.Framework.Assert.AreEqual(0.5d, func.EvaluateNumeric());
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "ToNumber operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_PositiveFractionNotStringWithLeftVariable_IsNotCorrect()
        {
            func.Function = "toNumber(a)";
            func.AddSetVariable("a", 2.1);
            NUnit.Framework.Assert.AreEqual(2.1d, func.EvaluateNumeric());
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(FormatException), ExpectedMessage = "Input string was not in a correct format", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_PositiveFractionWithLeftVariableOfWrongType_IsNotCorrect()
        {
            func.Function = "toNumber(a)";
            func.AddSetVariable("a", "b");
            NUnit.Framework.Assert.AreEqual(0.5d, func.EvaluateNumeric());
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "ToNumber operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_VariableWithoutSetVariable_OperatorError()
        {
            func.Function = "toNumber(a)";
            func.EvaluateNumeric();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "ToNumber operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_VariableMixedWithDigitWithoutSetVariable_OperatorError()
        {
            func.Function = "toNumber(3a)";
            func.EvaluateNumeric();
        }

    }
}

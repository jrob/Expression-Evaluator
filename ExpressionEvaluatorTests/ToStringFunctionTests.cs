// ReSharper disable InconsistentNaming

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ToStringFunctionTests
    {
        private Expression func;

        [SetUp]
        public void init()
        {
            func = new Expression("");
        }

        [TearDown]
        public void clear()
        {
            func.Clear();
        }

        [Test]
        public void ToStringOperator_BooleanInput_IsCorrect()
        {
            func.Function = "toString(true)";
            Assert.AreEqual("True", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_BooleanInputWithSpaces_IsCorrect()
        {
            func.Function = "toString( true )";
            Assert.AreEqual("True", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_FalseConditionEvaluated_OperandCaseMatch()
        {
            func.Function = "toString(if(a>1){'Test'}else{'NotValid'})";
            func.AddSetVariable("a", 1);
            Assert.AreEqual("NotValid", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_FalseConditionEvaluated_OperatorIgnoreCase()
        {
            func.Function = "toString(If(a>1){'Test'}else{'NotValid'})";
            func.AddSetVariable("a", 1);
            Assert.AreEqual("NotValid", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_LHSCamelWithoutSpace_FalseConditionEvaluated()
        {
            func.Function = "toString(If(a == 'hi '){'hi with space'}else{'NotValid'})";
            func.AddSetVariable("a", "Hi");
            Assert.AreEqual("NotValid", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_LHSCamelWithSpace_TrueConditionEvaluated()
        {
            func.Function = "toString(If(a == 'hi '){'Hi with space'}else{'NotValid'})";
            func.AddSetVariable("a", "Hi ");
            Assert.AreEqual("Hi with space", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_LHSLowerWithoutSpace_FalseConditionEvaluated()
        {
            func.Function = "toString(If(a == 'hi '){'hi with space'}else{'NotValid'})";
            func.AddSetVariable("a", "hi");
            Assert.AreEqual("NotValid", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_LHSLowerWithSpace_TrueConditionEvaluated()
        {
            func.Function = "toString(If(a == 'hi '){'hi with space'}else{'NotValid'})";
            func.AddSetVariable("a", "hi ");
            Assert.AreEqual("hi with space", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_NumericInput_IsCorrect()
        {
            func.Function = "toString(2)";
            Assert.AreEqual("2", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_NumericInputWithSpaces_IsCorrect()
        {
            func.Function = "toString( 2 )";
            Assert.AreEqual("2", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_StringInput_IsCorrect()
        {
            func.Function = "toString('test')";
            Assert.AreEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_StringInputWithSpaces_IsCorrect()
        {
            func.Function = "toString( 'test' )";
            Assert.AreEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_TrueConditionEvaluated_OperandCaseMatch()
        {
            func.Function = "toString(if(a>1){'Test'}else{'NotValid'})";
            func.AddSetVariable("a", 2);
            Assert.AreEqual("Test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_TrueConditionEvaluated_OperatorIgnoreCase()
        {
            func.Function = "toString(If(a>1){'Test'}else{'NotValid'})";
            func.AddSetVariable("a", 2);
            Assert.AreEqual("Test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableCaseMatch_CaseMismatchError()
        {
            func.Function = "toString('Test')";
            Assert.AreNotEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsBoolean_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", true);
            Assert.AreEqual("True", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsDateTime_IsCorrect()
        {
            var dt = DateTime.Now;
            func.Function = "toString(a)";
            func.AddSetVariable("a", dt);
            Assert.AreEqual(dt.ToString(), func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsNull_IsCorrect()
        {
            func.Function = "toString(a)";
            Assert.AreEqual("null", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsNumeric_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", 2);
            Assert.AreEqual("2", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsString_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", "test");
            Assert.AreEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsStringCaseMatch_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", "Test");
            Assert.AreEqual("Test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableWithSapce_ErrorExpectedSpaceTrimmed()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", "Test ");
            Assert.AreNotEqual("Test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableWithSapce_SpaceIsIncluded()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", "Test ");
            Assert.AreEqual("Test ", func.Evaluate<string>());
        }
    }
}

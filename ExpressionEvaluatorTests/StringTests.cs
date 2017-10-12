using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class StringTests
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
        public void String_FalseConditionEvaluated_OperandCaseMatch()
        {
            _func.Function = "if(a>1){'Test'}else{'NotValid'}";
            _func.AddSetVariable("a", 1);
            Assert.AreEqual("NotValid", _func.Evaluate<string>());
        }

        [Test]
        public void String_FalseConditionEvaluated_OperatorIgnoreCase()
        {
            _func.Function = "If(a>1){'Test'}else{'NotValid'}";
            _func.AddSetVariable("a", 1);
            Assert.AreEqual("NotValid", _func.Evaluate<string>());
        }

        [Test]
        public void String_LHSCamelWithoutSpace_FalseConditionEvaluated()
        {
            _func.Function = "If(a == 'hi '){'hi with space'}else{'NotValid'}";
            _func.AddSetVariable("a", "Hi");
            Assert.AreEqual("NotValid", _func.Evaluate<string>());
        }

        [Test]
        public void String_LHSCamelWithSpace_TrueConditionEvaluated()
        {
            _func.Function = "If(a == 'hi '){'Hi with space'}else{'NotValid'}";
            _func.AddSetVariable("a", "Hi ");
            Assert.AreEqual("Hi with space", _func.Evaluate<string>());
        }

        [Test]
        public void String_LHSLowerWithoutSpace_FalseConditionEvaluated()
        {
            _func.Function = "If(a == 'hi '){'hi with space'}else{'NotValid'}";
            _func.AddSetVariable("a", "hi");
            Assert.AreEqual("NotValid", _func.Evaluate<string>());
        }

        [Test]
        public void String_LHSLowerWithSpace_TrueConditionEvaluated()
        {
            _func.Function = "If(a == 'hi '){'hi with space'}else{'NotValid'}";
            _func.AddSetVariable("a", "hi ");
            Assert.AreEqual("hi with space", _func.Evaluate<string>());
        }

        [Test]
        [ExpectedException(
            typeof(ExpressionException), ExpectedMessage = "String grouping error",
            MatchType = MessageMatch.Contains)]
        public void String_TooManySeperators_Exception()
        {
            _func.Function = "'aoeu ''";
            _func.Evaluate<string>();
        }

        [Test]
        public void String_TrueConditionEvaluated_OperandCaseMatch()
        {
            _func.Function = "if(a>1){'Test'}else{'NotValid'}";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual("Test", _func.Evaluate<string>());
        }

        [Test]
        public void String_ValidBackSSpace_IsCorrect()
        {
            _func.Function = "'a '";
            Assert.AreEqual("a ", _func.Evaluate<string>());
        }

        [Test]
        public void String_ValidFrontSpace_IsCorrect()
        {
            _func.Function = "' a'";
            Assert.AreEqual(" a", _func.Evaluate<string>());
        }

        [Test]
        public void String_ValidNoSpaces_IsCorrect()
        {
            _func.Function = "'a'";
            Assert.AreEqual("a", _func.Evaluate<string>());
        }

        [Test]
        public void String_VariableCaseMatch_CaseMismatchError()
        {
            _func.Function = "'Yes'";
            Assert.AreNotEqual("yes", _func.Evaluate<string>());
        }

        [Test]
        public void String_VariableCaseMatch_IsCorrect()
        {
            _func.Function = "'Yes'";
            Assert.AreEqual("Yes", _func.Evaluate<string>());
        }

        [Test]
        public void String_VariableWithSapce_ErrorExpectedSpaceTrimmed()
        {
            _func.Function = "'Test '";
            Assert.AreNotEqual("Test", _func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_FalseConditionEvaluated_OperatorIgnoreCase()
        {
            _func.Function = "If(a>1){'Test'}else{'NotValid'}";
            _func.AddSetVariable("a", 1);
            Assert.AreEqual("NotValid", _func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableWithSapce_SpaceIsIncluded()
        {
            _func.Function = "'Test '";
            Assert.AreEqual("Test ", _func.Evaluate<string>());
        }
    }
}

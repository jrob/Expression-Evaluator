using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class BooleanOperatorTests
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
        public void And_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = " && true", "Operator error");
        }

        [Test]
        public void And_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "true && ", "Operator error");
        }

        [Test]
        public void And_ValidExpression001_IsCorrect()
        {
            _func.Function = "true && true";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression002_IsCorrect()
        {
            _func.Function = "true && false";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression003_IsCorrect()
        {
            _func.Function = "false && true";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression004_IsCorrect()
        {
            _func.Function = "false && false";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void Equal_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "== 5.2", "Operator error");
        }

        [Test]
        public void Equal_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 ==", "Operator error");
        }

        [Test]
        public void Equal_ValidExpression001_IsCorrect()
        {
            _func.Function = "4 == 5.2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void Equal_ValidExpression002_IsCorrect()
        {
            _func.Function = "4 == 4";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 >=", "Operator error");
        }

        [Test]
        public void GreaterEqual_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = ">= 4", "Operator error");
        }

        [Test]
        public void GreaterEqual_ValidExpression001_IsCorrect()
        {
            _func.Function = "4 >= 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_ValidExpression002_IsCorrect()
        {
            _func.Function = "4 >= 4";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_ValidExpression003_IsCorrect()
        {
            _func.Function = "4 >= 6";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void Greater_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "> 2", "Operator error");
        }

        [Test]
        public void Greater_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 >", "Operator error");
        }

        [Test]
        public void Greater_ValidExpression001_IsCorrect()
        {
            _func.Function = "4 > 2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Greater_ValidExpression002_IsCorrect()
        {
            _func.Function = "4 > 5.2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LessEqual_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "<= 6", "Operator error");
        }

        [Test]
        public void LessEqual_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 <=", "Operator error");
        }

        [Test]
        public void LessEqual_ValidExpression001_IsCorrect()
        {
            _func.Function = "4 <= 6";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LessEqual_ValidExpression002_IsCorrect()
        {
            _func.Function = "4 <= 4";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LessEqual_ValidExpression003_IsCorrect()
        {
            _func.Function = "4 <= 2";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void Less_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "< 5.2", "Operator error");
        }

        [Test]
        public void Less_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 <", "Operator error");
        }

        [Test]
        public void Less_ValidExpression001_IsCorrect()
        {
            _func.Function = "4 < 5.2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Less_ValidExpression002_IsCorrect()
        {
            _func.Function = "4 < 3";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression001_IsCorrect()
        {
            _func.Function = "true || false && false || false";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression002_IsCorrect()
        {
            _func.Function = "(true || false) && (false || false)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression003_IsCorrect()
        {
            _func.Function = "(true || false) && false || false";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression004_IsCorrect()
        {
            _func.Function = "(true || false) && true";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void MulitpleOperators_BadExpression008_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 > abs(neg )", "Operator error");
        }

        [Test]
        public void MulitpleOperators_BadExpression009_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = " > abs(neg 3.2)", "Operator error");
        }

        [Test]
        public void MulitpleOperators_BadExpression010_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 neg(abs(5.2))", "Expression formatted incorrecty");
        }

        [Test]
        public void MultipleBooleanOperators_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "true ||  && false || false", "Operator error");
        }

        [Test]
        public void MultipleBooleanOperators_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "(true || false) && ( || false)", "Operator error");
        }

        [Test]
        public void MultipleOperators_BadExpression003_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "(true || false) && false || ", "Operator error");
        }

        [Test]
        public void MultipleOperators_BadExpression004_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "(true || ) && true", "Operator error");
        }

        [Test]
        public void NotEqual_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "4 !=", "Operator error");
        }

        [Test]
        public void NotEqual_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "!= 4", "Operator error");
        }

        [Test]
        public void Or_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "true || ", "Operator error");
        }

        [Test]
        public void Or_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "|| false", "Operator error");
        }

        [Test]
        public void Or_ValidExpression001_IsCorrect()
        {
            _func.Function = "true || true";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Or_ValidExpression002_IsCorrect()
        {
            _func.Function = "true || false";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Or_ValidExpression003_IsCorrect()
        {
            _func.Function = "false || true";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Or_ValidExpression004_IsCorrect()
        {
            _func.Function = "false || false";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }
    }
}

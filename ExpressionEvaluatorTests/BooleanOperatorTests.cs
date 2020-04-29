using System.Diagnostics.Contracts;
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
            var func = " && true";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void And_BadExpression002_ExpressionException()
        {
            var func = "true &&";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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
            var func = "== 5.2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void Equal_BadExpression002_ExpressionException()
        {
            var func = "4 ==";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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
            var func = "4 >=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void GreaterEqual_BadExpression002_ExpressionException()
        {
            var func = ">= 4";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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
            var func = "> 2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void Greater_BadExpression002_ExpressionException()
        {
            var func = "4 >";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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
            var func = "<= 6";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void LessEqual_BadExpression002_ExpressionException()
        {
            var func = "4 <=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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
            var func = "< 5.2";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void Less_BadExpression002_ExpressionException()
        {
            var func = "4 <";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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
            var exp = "4 > abs(neg )";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = exp);
            StringAssert.Contains("Function error", ex.Message);
        }

        [Test]
        public void MulitpleOperators_BadExpression009_ExpressionException()
        {
            var func = " > abs(neg 3.2)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Function error", ex.Message);
        }

        [Test]
        public void MulitpleOperators_BadExpression010_ExpressionException()
        {
            var func = "4 neg(abs(5.2))";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Expression formatted incorrectly", ex.Message);
        }

        [Test]
        public void MultipleBooleanOperators_BadExpression001_ExpressionException()
        {
            var func = "true ||  && false || false";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultipleBooleanOperators_BadExpression002_ExpressionException()
        {
            var func = "(true || false) && ( || false)";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultipleOperators_BadExpression003_ExpressionException()
        {
            var func = "(true || false) && false || ";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void MultipleOperators_BadExpression004_ExpressionException()
        {
            var func = "(true || ) && true";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void NotEqual_BadExpression001_ExpressionException()
        {
            var func = "4 !=";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void NotEqual_BadExpression002_ExpressionException()
        {
            var func = "!= 4";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void Or_BadExpression001_ExpressionException()
        {
            var func = "true || ";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
        }

        [Test]
        public void Or_BadExpression002_ExpressionException()
        {
            var func = "|| false";
            ExpressionException ex = Assert.Throws<ExpressionException>(() => _func.Function = func);
            StringAssert.Contains("Operator error", ex.Message);
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

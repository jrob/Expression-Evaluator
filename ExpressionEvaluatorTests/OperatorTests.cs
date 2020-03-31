using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class OperatorTests
    {
        private Expression _func;

        [SetUp]
        public void Init()
        {
            _func = new Expression();
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        public void Ln_002()
        {
            _func.Function = "ln(5) + 1";
            Assert.AreEqual(2.6094379124341005, _func.EvaluateNumeric());
        }

        [Test]
        public void Ln_003()
        {
            _func.Function = "ln(5) * 2";
            Assert.AreEqual(3.2188758248682006, _func.EvaluateNumeric());
        }

        [Test]
        public void MulitpleOperators_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "1+(2*)", "Operator error");
        }

        [Test]
        public void MulitpleOperators_BadExpression002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "1/2*", "Operator error");
        }

        [Test]
        public void MulitpleOperators_BadExpression005_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "1-(2+3)2", "Expression formatted incorrecty");
        }

        [Test]
        public void MulitpleOperators_BadExpression007_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "1-2-3-3-2-", "Operator error");
        }

        [Test]
        public void MulitpleOperators_BadExrpession006_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "+1/", "Operator error");
        }

        [Test]
        public void Negation_BadExpression001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = "9832 neg", "Function error");
        }

        [Test]
        public void Sign003()
        {
            _func.Function = "sign(0)";
            Assert.AreEqual(1, _func.EvaluateNumeric());
        }

        [Test]
        public void Subtraction001()
        {
            _func.Function = "-23";
            Assert.AreEqual(-23, _func.EvaluateNumeric());
        }
    }
}

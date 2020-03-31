using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ToNumberFunctionTests
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
        public void ToNumberOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "toNumber('-2')";
            NUnit.Framework.Assert.AreEqual(-2.0f, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithPositiveDecimal_IsCorrect()
        {
            _func.Function = "toNumber('2.3')";
            NUnit.Framework.Assert.AreEqual(2.3, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithPositiveWholeWithSpaces_IsCorrect()
        {
            _func.Function = "toNumber(' 2 ')";
            NUnit.Framework.Assert.AreEqual(2.0f, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "toNumber('2')";
            NUnit.Framework.Assert.AreEqual(2.0f, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_PositiveFractionNotStringWithLeftVariable_IsNotCorrect()
        {
            _func.Function = "toNumber(a)";
            _func.AddSetVariable("a", 2.1);
            Assert.Throws<ExpressionException>(() => _func.EvaluateNumeric(), "ToNumber operator used incorrectly");
        }

        [Test]
        public void ToNumberOperator_PositiveFractionWithLeftVariable_IsCorrect()
        {
            _func.Function = "toNumber(a)";
            _func.AddSetVariable("a", "0.5");
            NUnit.Framework.Assert.AreEqual(0.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_ResultFromSubstringVariable_IsCorrect()
        {
            _func.Function = "toNumber(substring(a, 1, length(a) - 1))";
            _func.AddSetVariable("a", "<2.0");
            Assert.AreEqual(2.0f, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_VariableMixedWithDigitWithoutSetVariable_OperatorError()
        {
            _func.Function = "toNumber(3a)";
            Assert.Throws<ExpressionException>(() => _func.EvaluateNumeric(), "ToNumber operator used incorrectly");
        }

        [Test]
        public void ToNumberOperator_VariableNotStringButNotNumber_NaN()
        {
            _func.Function = "toNumber(a)";
            _func.AddSetVariable("a", "b");
            NUnit.Framework.Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_VariableWithoutSetVariable_OperatorError()
        {
            _func.Function = "toNumber(a)";
            Assert.Throws<ExpressionException>(() => _func.EvaluateNumeric(), "ToNumber operator used incorrectly");
        }

        [Test]
        public void ToNumber_IfValidElseWillThrowException_StillEvaluates()
        {
            _func.Function = "if (true) { tonumber('2') } else { toNumber('a') }";
            Assert.AreEqual(2.0f, _func.EvaluateNumeric());
        }

        [Test]
        public void ToNumber_IfWillThrowExceptionElseValid_StillEvaluates()
        {
            _func.Function = "if (false) { tonumber('a') } else { toNumber('2') }";
            Assert.AreEqual(2.0f, _func.EvaluateNumeric());
        }
    }
}

using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    /// <summary>
    /// Summary description for ExpressionTests
    /// </summary>
    [TestFixture]
    public class ExpressionTest
    {
        private Expression _func;

        [SetUp]
        public void Init() { _func = new Expression(""); }

        [TearDown]
        public void Clear() { _func.Clear(); }

        [Test]
        public void Add_SimpleTest_ValueIsCorrect()
        {
            _func.Function = "1+2";
            Assert.AreEqual(true, double.IsNaN(_func.GetVariableValue("a")));
            Assert.AreEqual(3, _func.EvaluateNumeric());
        }

        [Test]
        public void ClearVariables_Call_VariableAreCleared()
        {
            _func.Function = "a+b";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            _func.ClearVariables();
            Assert.AreEqual(true, double.IsNaN(_func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(_func.GetVariableValue("b")));
        }

        [Test]
        public void DivideByZero_EvaluateFunction001_IsNotANumber()
        {
            _func.Function = "2/0";
            Assert.AreEqual(true, double.IsNaN(_func.EvaluateNumeric()));
        }

        [Test]
        public void DivideByZero_EvaluateFunction002_IsNotANumber()
        {
            _func.Function = "2/(1-1)";
            Assert.AreEqual(true, double.IsNaN(_func.EvaluateNumeric()));
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrors_IsCorrect()
        {
            _func.Function = "99.999999999999/100";
            Assert.AreEqual(0.99999999999999, _func.EvaluateNumeric());
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrors01_IsCorrect()
        {
            _func.Function = "0.3 / 0.4";
            Assert.AreEqual(0.75, _func.EvaluateNumeric());
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrorsWithBoolean_IsCorrect()
        {
            _func.Function = "0.3 >= 0.75 * 0.4";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrorsWithBoolean01_IsCorrect()
        {
            _func.Function = "0.3 / 0.4 == 0.75";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrorsWithBooleanAndVariables_IsCorrect()
        {
            _func.Function = "a >= 0.75 * b";
            _func.AddSetVariable("a", 0.3);
            _func.AddSetVariable("b", 0.4);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Function001()
        {
            _func.Function = "a+b - 2";
            Assert.AreEqual("a+b - 2", _func.Function);
        }

        [Test]
        public void Function002()
        {
            _func.Function = "a +b - 2";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual("a +b - 2", _func.Function);
        }

        [Test]
        public void Function003()
        {
            _func.Function = "a + b - 2";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b - 2", _func.Function);
        }

        [Test]
        public void InFix001()
        {
            _func.Function = "a+b";
            Assert.AreEqual("a + b", _func.InFix);
        }

        [Test]
        public void InFix002()
        {
            _func.Function = "a+ b";
            Assert.AreEqual("a + b", _func.InFix);
        }

        [Test]
        public void InFix003()
        {
            _func.Function = "a +b";
            Assert.AreEqual("a + b", _func.InFix);
        }

        [Test]
        public void InFix004()
        {
            _func.Function = "a + b";
            Assert.AreEqual("a + b", _func.InFix);
        }

        [Test]
        public void InFix005()
        {
            _func.Function = "a+b-2*3/66*sign(-3)+abs(-16)^3";
            Assert.AreEqual("a + b - 2 * 3 / 66 * sign ( -3 ) + abs ( -16 ) ^ 3", _func.InFix);
        }

        [Test]
        public void PostFix001()
        {
            _func.Function = "a + b";
            Assert.AreEqual("a b +", _func.PostFix);
        }

        [Test]
        public void PostFix002()
        {
            _func.Function = "a+b";
            Assert.AreEqual("a b +", _func.PostFix);
        }

        [Test]
        public void PostFix003()
        {
            _func.Function = "a+b - 2";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual("a b + 2 -", _func.PostFix);
        }

        [Test]
        public void Power_PositivePower_IsCorrect()
        {
            _func.Function = "2^2";
            Assert.AreEqual(4, _func.EvaluateNumeric());
        }

        [Test]
        public void Power_PositiveWholeNegativePower_IsCorrect()
        {
            _func.Function = "2^-2";
            Assert.AreEqual(0.25, _func.EvaluateNumeric());
        }

        [Test]
        public void ToString001()
        {
            _func.Function = "a + b";
            Assert.AreEqual("a + b; a=null, b=null", _func.ToString());
        }

        [Test]
        public void ToString002()
        {
            _func.Function = "a + b";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b; a=2, b=3", _func.ToString());
        }

        [Test]
        public void Variable_SetThenChanged_IsCorrect()
        {
            _func.Function = "a+b";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual(2, _func.GetVariableValue("a"));
            Assert.AreEqual(3, _func.GetVariableValue("b"));

            _func.AddSetVariable("a", 3);
            _func.AddSetVariable("b", 4);
            Assert.AreEqual(3, _func.GetVariableValue("a"));
            Assert.AreEqual(4, _func.GetVariableValue("b"));
        }

        [Test]
        public void Variable002()
        {
            _func.Function = "a+b";
            Assert.AreEqual(true, double.IsNaN(_func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(_func.GetVariableValue("b")));
        }
    }
}

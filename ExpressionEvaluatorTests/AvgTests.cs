using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AvgTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Avg_BasicFormula_CorrectValue()
        {
            func.Function = @"avg(1, 2, 3)";
            Assert.AreEqual(2m, func.EvaluateNumeric());
        }

        [Test]
        public void Avg_BasicFormulaWithVariables_CorrectValue()
        {
            func.Function = @"avg(a, b, c)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            func.AddSetVariable("c", 3);
            Assert.AreEqual(2m, func.EvaluateNumeric());
        }

        [Test]
        public void Avg_VariablesWithInnerAddition_CorrectValue()
        {
            func.Function = @"avg(a, 1+2, c)";
            func.AddSetVariable("a", 1);
            Assert.AreEqual(2.0m, func.EvaluateNumeric());
        }

        [Test]
        public void Avg_VariablesWithNull_CorrectValue()
        {
            func.Function = @"avg(a, b, c)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(1.5m, func.EvaluateNumeric());
        }
    }
}

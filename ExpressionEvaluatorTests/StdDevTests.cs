using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class StdDevTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void StdDev_BasicFormula_CorrectValue()
        {
            func.Function = @"stddev(1, 2, 3)";
            Assert.AreEqual(0.8164965809277260m, func.EvaluateNumeric());
        }

        [Test]
        public void StdDev_BasicFormulaWithVariables_CorrectValue()
        {
            func.Function = @"stddev(a, b, c)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            func.AddSetVariable("c", 3);
            Assert.AreEqual(0.8164965809277260m, func.EvaluateNumeric());
        }

        [Test]
        public void StdDev_VariablesWithInnerAddition_CorrectValue()
        {
            func.Function = @"stddev(a, 1+2, c)";
            func.AddSetVariable("a", 1);
            Assert.AreEqual(1.0m, func.EvaluateNumeric());
        }

        [Test]
        public void StdDev_VariablesWithNull_CorrectValue()
        {
            func.Function = @"stddev(a, b, c)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(0.5m, func.EvaluateNumeric());
        }

        [Test]
        public void StdDev_VariablesWithSingleValue_CorrectValue()
        {
            func.Function = @"stddev(a, b, c)";
            func.AddSetVariable("a", 1);
            Assert.AreEqual(0.0m, func.EvaluateNumeric());
        }
    }
}

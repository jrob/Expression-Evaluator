using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ConditionalTests
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
        public void Grouping_OutOfOrder001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true { ) 2 } else { 1 }", "Operator error");
        }

        [Test]
        public void IfElse_CorrectFormat001_IsCorrect()
        {
            _func.Function = "if (true) { 1 } else { 2 }";
            Assert.AreEqual(1, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat002_IsCorrect()
        {
            _func.Function = "if (false) { 1 } else { 2 }";
            Assert.AreEqual(2, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat003_IsCorrect()
        {
            _func.Function = "5 + if (true) { 1 } else { 2 }";
            // 5 true 1 if 2 else +
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat004_IsCorrect()
        {
            _func.Function = "5 + if (false) { 1 } else { 2 }";
            Assert.AreEqual(7, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_ElseNoOperator_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true)  { 1  } else { }", "Operator error");
        }

        [Test]
        public void IfElse_ElseWithBoolean001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true) { 2 } else (true) { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_ElseWithBoolean002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true) { 2 } else if (true) { 1 } else (true) { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_FunctionInFalsePathThrowsException_FunctionStillEvaluates()
        {
            _func.Function = "if (true) { 1 + 1 } else { TotalDays(a) }";
            _func.AddSetVariable("a", "fail");
            Assert.AreEqual(2, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_FunctionInTruePathThrowsException_ExceptionThrown()
        {
            _func.Function = "if (false) { 1 + 1 } else { TotalDays(a) }";
            _func.AddSetVariable("a", "fail");
            Assert.Throws<ExpressionException>(() => _func.EvaluateNumeric(), "Operator error");
        }

        [Test]
        public void IfElse_IfElseMismatch001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true) { 2 } else if { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_IfElseMismatch002_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true) { 2 } else if (true) { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_IfNoExpression_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true)  {  } else { 1 }", "Operator error");
        }

        [Test]
        public void IfElse_IfNoOperator_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if  {  } else { 1 }", "Operator error");
        }

        [Test]
        public void IfElse_IfStringOperator_ExpressionException()
        {
            _func.Function = @"if ( val )  { 1 } else { 1 }";
            Assert.Throws<ExpressionException>(() => _func.EvaluateNumeric(), "variable type error");
        }

        [Test]
        public void IfElse_NestedBoolean001_IsCorrect()
        {
            _func.Function = "5 + if (8 > 1) { 1 } else { 2 }";
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBoolean002_IsCorrect()
        {
            _func.Function = "5 + if (8 > 1 || 8 < 10) { 1 } else { 2 }";
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBooleanWithVariable001_IsCorrect()
        {
            _func.Function = "5 + if (a > 1) { 1 } else { 2 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBooleanWithVariable002_IsCorrect()
        {
            _func.Function = "5 + if (a > 1 || a < 10) { 1 } else { 2 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat001_IsCorrect()
        {
            _func.Function = "if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(1, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat002_IsCorrect()
        {
            _func.Function = "5 + if (true) { if (false) { 1 } else { 2 } } else { 3 }";
            // 5 true  +
            Assert.AreEqual(7, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat003_IsCorrect()
        {
            _func.Function = "5 + if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedElseWithBoolean001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true) { if (true) { 3 } else (true) { 2 } } else { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_NestedMathmaticalWithVariable001_IsCorrect()
        {
            _func.Function = "5 + if (a > 1) { a + 1 } else { 2 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedMathmaticalWithVariable002_IsCorrect()
        {
            _func.Function = "5 + if (a > 1 || a < 10) { a + 1 } else { a + 2 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_OutOfOrder001_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"else { 2 } if (true) { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_OutOfOrder003_ExpressionException()
        {
            Assert.Throws<ExpressionException>(() => _func.Function = @"if (true) { 2 } if else (true) { 1 }", "Conditional Error");
        }

        [Test]
        public void IfElse_ToInfix001_IsCorrect()
        {
            _func.Function = "5 + if (true) { 1 } else { 2 }";
            Assert.AreEqual("5 true 1 if 2 else +", _func.PostFix);
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat001_IsCorrect()
        {
            _func.Function = "if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(1, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat002_IsCorrect()
        {
            _func.Function = "5 + if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(6, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat003_IsCorrect()
        {
            _func.Function = "if (false) { 1 } else if (true) { 2 } else { 3 }";
            Assert.AreEqual(2, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat004_IsCorrect()
        {
            _func.Function = "5 + if (false) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(7, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat005_IsCorrect()
        {
            _func.Function = "if (false) { 1 } else if (false) { 2 } else { 3 }";
            Assert.AreEqual(3, _func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat006_IsCorrect()
        {
            _func.Function = "5 + if (false) { 1 } else if (false) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void Multiline_ValidExpression001_IsCorrect()
        {
            _func.Function = "5 +" + Environment.NewLine + "if (a > 1 || a < 10)"
                + Environment.NewLine + "{ a + 1 }" + Environment.NewLine + "else"
                + Environment.NewLine + "{ a + 2 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }
    }
}

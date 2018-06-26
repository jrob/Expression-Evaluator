using System.Collections.Generic;
using System.Linq;
using ExpressionEvaluator.Procedures.Functions;
using ExpressionEvaluator.Procedures.Operators;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public static class ExpressionKeywords
    {
        public static readonly List<string> ClosingGroupOperators;
        public static readonly List<string> ConditionalOperators;
        public static readonly Dictionary<string, IVariable> Constants;
        public static readonly List<string> Functions;
        public static readonly List<string> GroupOperators;
        public static readonly List<Keyword> Keywords;
        public static readonly List<string> OpenGroupOperators;
        public static readonly List<string> Operators;
        public static readonly List<string> StringGroupOperators;

        static ExpressionKeywords()
        {
            Constants = new Dictionary<string, IVariable>()
            {
                {"null", new GenericVariable<object>("null") {Value = null}},
                {
                    "param_terminator",
                    new GenericVariable<string>("param_terminator") {Value = "param_terminator"}
                },
                {"true", new GenericVariable<bool>("true") {Value = true}},
                {"false", new GenericVariable<bool>("false") {Value = false}}
            };

            Keywords = new List<Keyword>
            {
                new Or(10),
                new And(20),
                new Equal(30),
                new GreaterEqual(30),
                new LesserEqual(30),
                new GreaterThan(30),
                new LesserThan(30),
                new NotEqual(30),
                new Addition(40),
                new Subtraction(40),
                new Multiplication(50),
                new Division(50),
                new Modulo(50),
                new Power(55),
                new Absolute(60),
                new Negate(60),
                new NaturalLog(60),
                new Sign(60),
                new Now(60),
                new Days(60),
                new Hours(60),
                new Minutes(60),
                new Seconds(60),
                new TotalDays(60),
                new TotalHours(60),
                new TotalMinutes(60),
                new TotalSeconds(60),
                new DaysComponent(60),
                new HoursComponent(60),
                new MinutesComponent(60),
                new SecondsComponent(60),
                new Contains(60),
                new ToNumber(60),
                new ToString(60),
                new ToStringFormat(60),
                new IsNumber(60),
                new Substring(60),
                new Length(60),
                new Sum(60),
                new Min(60),
                new Max(60),
                new Round(60),
                new Ceiling(60),
                new Floor(60),
                new Concatenate(60),
                new Conditional("if", 70, 2, false, false),
                new Conditional("elseif", 70, 2, false, false),
                new Conditional("else", 70, 1, true, false),
                new Grouping("Paranthesis", "(", ")"),
                new Grouping("Curley Braces", "{", "}"),
                new StringGrouping("String", "'"),
                new VariableDelimiter("Comma", ","),
            };

            Operators = Keywords.OfType<Operator>()
                .Select(x => x.Name)
                .ToList();

            Functions = Keywords.OfType<Function>()
                .Select(x => x.Name)
                .ToList();

            StringGroupOperators = Keywords.OfType<StringGrouping>()
                .Select(x => x.Delimiter)
                .ToList();

            VariableDelimiterOperators = Keywords.OfType<VariableDelimiter>()
                .Select(x => x.Delimiter)
                .ToList();

            OpenGroupOperators = Keywords.OfType<Grouping>()
                .Select(x => x.Open)
                .ToList();

            ClosingGroupOperators = Keywords.OfType<Grouping>()
                .Select(x => x.Close)
                .ToList();

            GroupOperators = ClosingGroupOperators.Union(OpenGroupOperators)
                .ToList();

            ConditionalOperators = Keywords.OfType<Conditional>()
                .Select(x => x.Name)
                .ToList();
        }

        public static List<string> VariableDelimiterOperators { get; set; }

        public static Grouping GetGroupingFromClose(string token)
        {
            return Keywords.OfType<Grouping>()
                .Where(x => x.Close == token)
                .Single();
        }

        /// <summary>
        /// Returns the precedance of an operator.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">Token to check.</param>
        /// <returns></returns>
        public static int GetPrecedence(string token)
        {
            if (Keywords.Where(x => x.Name == token)
                .Count() == 1) {
                return Keywords.Where(x => x.Name == token)
                    .Single()
                    .Precedance;
            }

            return 0;
        }

        /// <summary>
        /// Checks to see if a string is an operand.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">String to check</param>
        /// <returns></returns>
        public static bool IsOperand(string token)
        {
            if (!IsOperator(token)
                && !GroupOperators.Contains(token)
                && !IsVariableDelilimter(token)) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks to see if a string is an operator.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">String to check</param>
        /// <returns></returns>
        public static bool IsOperator(string token)
        {
            return Operators.Union(Functions)
                .Union(ConditionalOperators)
                .Contains(token);
        }

        public static bool IsVariableDelilimter(string token)
        {
            return VariableDelimiterOperators.Contains(token);
        }
    }
}

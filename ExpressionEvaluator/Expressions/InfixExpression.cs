using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class InfixExpression
    {
        private string _expression;
        private string _original;
        private string[] _tokens;

        public InfixExpression(string expression)
        {
            AutoVariables = new Dictionary<string, IVariable>();
            _original = expression;
            expression = replaceStrings(expression);
            Expression = Expand(expression.ToLower());
            _tokens = Expression.Split(new[] {' '});

            CheckGrouping(Expression);
            CheckFunctionFormatting(Expression, _tokens);
            CheckConditionals(Expression, _tokens);
        }

        public string Original { get { return _original; } }
        public IEnumerable<string> Tokens { get { return _tokens; } }
        public Dictionary<string, IVariable> AutoVariables { get; private set; }
        public string Expression
        {
            get { return _expression; }
            private set { _expression = value; }
        }

        private void CheckConditionalFormatting(string inFix)
        {
            string errorMsg = "Conditional Error! Boolean statement formatted incorrectly. "
                + inFix;

            // Find any instances of an "if" followed by something othern then a "(".
            if (Regex.IsMatch(inFix, @" if(?! *\()")) {
                throw new ExpressionException(errorMsg);
            }

            // Find any instances of an "else" followed by something othern then a "{" or an "if".
            if (Regex.IsMatch(inFix, @"else(?! *(if|{))")) {
                throw new ExpressionException(errorMsg);
            }
        }

        private void CheckConditionals(string inFix, string[] tokens)
        {
            CheckForMatchingIfElse(inFix, tokens);
            CheckConditionalFormatting(inFix);
        }

        private void CheckForMatchingIfElse(string inFix, string[] tokens)
        {
            string errorMsg =
                "Conditional Error! If/Else mismatch. Should be in the following form: if (...) {...} else if (...) {...} else {...}. "
                + inFix;

            var workStack = new Stack<string>();
            foreach (var token in tokens) {
                if (!ExpressionKeywords.ConditionalOperators.Contains(token)) {
                    continue;
                }

                if (token == "if") {
                    workStack.Push(token);
                    continue;
                }

                if (workStack.Count == 0) {
                    throw new ExpressionException(errorMsg);
                }

                var last = workStack.Pop();

                if (last != "if") {
                    throw new ExpressionException(errorMsg);
                }

                if (token == "elseif") {
                    workStack.Push("if");
                }
            }

            if (workStack.Count != 0) {
                throw new ExpressionException(errorMsg + " " + inFix);
            }
        }

        private void CheckFunctionFormatting(string inFix, string[] tokens)
        {
            for (int i = 0; i < tokens.Length; i++) {
                var token = tokens[i];
                if (!ExpressionKeywords.Functions.Contains(token)) {
                    continue;
                }

                if (i + 1 >= tokens.Length
                    || tokens[i + 1] != "(") {
                    throw new ExpressionException(
                        "Function error! " + token
                        + " not formatted correctly. Open and close parenthesis required. "
                        + inFix);
                }
            }
        }

        private void CheckGrouping(string inFix)
        {
            string errorMsg = "Grouping error! Open missing. " + " " + inFix;

            var groupingStack = new Stack<char>();
            foreach (var token in inFix.ToArray()) {
                if (!ExpressionKeywords.GroupOperators.Contains(token.ToString())) {
                    continue;
                }

                if (ExpressionKeywords.OpenGroupOperators.Contains(token.ToString())) {
                    groupingStack.Push(token);
                    continue;
                }

                if (groupingStack.Count == 0) {
                    throw new ExpressionException(errorMsg);
                }

                var last = groupingStack.Pop();

                if (ExpressionKeywords.ClosingGroupOperators.Contains(token.ToString())) {
                    Grouping g = ExpressionKeywords.GetGroupingFromClose(token.ToString());
                    if (last.ToString() != g.Open) {
                        throw new ExpressionException(errorMsg);
                    }
                }
            }

            if (groupingStack.Count != 0) {
                throw new ExpressionException("Grouping error! Close missing. " + " " + inFix);
            }
        }

        /// <summary>
        /// Expandn the spaces around operators and operands.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="function">Function to expand.</param>
        /// <returns></returns>
        private string Expand(string function)
        {
            // Clean the function.
            //function = Regex.Replace(function, @"[ ]+", @""); // Remove spaces

            function = Regex.Replace(function, "\r\n", " ");
            function = Regex.Replace(function, ",", " , ");

            foreach (var x in ExpressionKeywords.Operators.Union(ExpressionKeywords.GroupOperators)
            ) {
                function = function.Replace(x, " " + x + " ");
            }

            // Join the else if into a single operator.
            function = function.Replace("else if", "elseif");
            function = function.Replace("< =", "<=");
            function = function.Replace("> =", ">=");
            function = function.Trim();
            function = Regex.Replace(function, @"[ ]+", @" "); // Collapses multiple spaces

            // Fix scientific notation.
            function = Regex.Replace(function, @"(\d)[ ]?e[ ]?([+-])[ ]?(\d+)", @"$1e$2$3");

            //function = ScientificNotationCorrection(function);
            function = FixNegativeRealValues(function);

            return function;
        }

        private string FixNegativeRealValues(string function)
        {
            // Fix negatives a the start of a function.
            function = Regex.Replace(function, @"^- (\b)", @"-$1");

            // Fix negatives after a math function.
            function = Regex.Replace(function, @"([=><+-/\(^*]) - (\d)", @"$1 -$2");

            // Fix negatives between two numbers.
            function = Regex.Replace(function, @"(\d)[ ]*-[ ]*(\d)", @"$1 - $2");

            return function;
        }

        private string replaceStrings(string expression)
        {
            foreach (var op in ExpressionKeywords.StringGroupOperators) {
                if (expression.Count(s => s == op[0]) % 2 != 0) {
                    throw new ExpressionException(
                        "String grouping error! \"" + op + "\" use incorrectly.");
                }
                var pattern = string.Format("{0}.*?{0}", op);
                var regex = new Regex(pattern);
                expression = regex.Replace(
                    expression, m => {
                        var name = Guid.NewGuid()
                            .ToString("N");
                        var value = m.Value.Substring(1, m.Value.Length - 2);
                        var newVar = new GenericVariable<string>(name, value);
                        AutoVariables.Add(name, newVar);
                        return " " + name + " ";
                    });
            }
            return expression;
        }
    }
}

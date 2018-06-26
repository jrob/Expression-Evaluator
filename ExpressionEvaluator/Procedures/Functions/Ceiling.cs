using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Ceiling : Function
    {
        public Ceiling(int precedance)
            : base("ceiling", precedance, 2, true)
        {
            _name2 = "Ceiling";
            DecimalDecimalOperandList = x => {
                if (x.Count > 2)
                    throw new ExpressionException("Ceiling only takes one or two paramters.");
                decimal op1 = x[0];
                decimal op2 = 0;
                if (x.Count == 2)
                    op2 = x[1];
                decimal offset = (decimal)Math.Pow(10, (int)op2);
                return Math.Ceiling(op1 * offset) / offset;
            };
        }
    }
}

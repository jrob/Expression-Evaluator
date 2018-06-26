using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Min : Function
    {
        public Min(int precedance)
            : base("min", precedance, 1, true)
        {
            _name2 = "Min";
            DecimalDecimalOperandList = x => x.Min();
        }
    }
}

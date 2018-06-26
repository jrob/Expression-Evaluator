using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Max : Function
    {
        public Max(int precedance)
            : base("max", precedance, 1, true)
        {
            _name2 = "Max";
            DecimalDecimalOperandList = x => x.Max();
        }
    }
}

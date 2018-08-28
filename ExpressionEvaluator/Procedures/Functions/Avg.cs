using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Avg : Function
    {
        public Avg(int precedance)
            : base("avg", precedance, 1, true)
        {
            _name2 = "Avg";
            DecimalDecimalOperandList = x => x.Average();
        }
    }
}

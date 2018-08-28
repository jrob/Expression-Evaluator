using System;
using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class StdDev : Function
    {
        public StdDev(int precedance)
            : base("stddev", precedance, 1, true)
        {
            _name2 = "StdDev";
            DecimalDecimalOperandList = x => {
                var avg = (double)x.Average();
                return (decimal)Math.Sqrt(x.Average(v => Math.Pow((double)v - avg, 2)));
            };
        }
    }
}

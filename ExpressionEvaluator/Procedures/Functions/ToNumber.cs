using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class ToNumber : Function
    {
        public ToNumber(int precedance)
            : base("tonumber", precedance, 1)
        {
            _name2 = "ToNumber";
            StringDouble = x => double.Parse(x);
        }
    }
}
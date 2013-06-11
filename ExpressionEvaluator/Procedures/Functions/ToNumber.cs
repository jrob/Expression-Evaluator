using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class ToNumber : Function
    {
        public ToNumber(int precedance)
            : base("tonumber", precedance, 1, false)
        {
            _name2 = "ToNumber";
            StringDouble = x =>
            {
                try
                {
                    return double.Parse(x);
                }
                catch (Exception e)
                {
                    return double.NaN;
                }
            };
        }
    }
}
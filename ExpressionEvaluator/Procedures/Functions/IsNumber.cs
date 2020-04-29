using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class IsNumber : Function
    {
        public IsNumber(int precedance)
            : base("isnumber", precedance, 1, false)
        {
            _name2 = "IsNumber";
            AnyBool = x => x != null && StringBool(x.ToString());
            StringBool = x => {
                try {
                    double.Parse(x);
                    return true;
                }
                catch (Exception) {
                    return false;
                }
            };
        }
    }
}

using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Substring : Function
    {
        public Substring(int precedance)
            : base("substring", precedance, 3, false)
        {
            _name2 = "Substring";
            StringDoubleDoubleString = (x, y, z) => x.Substring((int)y, (int)z);
        }
    }
}
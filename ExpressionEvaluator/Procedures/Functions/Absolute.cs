using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Absolute : Function
    {
        public Absolute(int precedance)
            : base("abs", precedance, 1, false)
        {
            _name2 = "Absolute";
            DoubleDouble = Math.Abs;
        }
    }
}
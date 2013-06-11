using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class Power : Operator
    {
        public Power(int precedance)
            : base("^", precedance, 2, false)
        {
            _name2 = "Power";
            DoubleDoubleDouble = (x, y) => Math.Pow(x,y);
        }
    }
}
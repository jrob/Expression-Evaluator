using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Minutes : Function
    {
        public Minutes(int precedance)
            : base("minutes", precedance, 1, false)
        {
            _name2 = "Minutes";
            DoubleTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerMinute));
        }
    }
}
using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Days : Function
    {
        public Days(int precedance)
            : base("days", precedance, 1, false)
        {
            _name2 = "Days";
            DoubleTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerDay));
        }
    }
}
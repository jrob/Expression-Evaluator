using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Hours : Function
    {
        public Hours(int precedance)
            : base("hours", precedance, 1, false)
        {
            _name2 = "Hours";
            DoubleTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerHour));
        }
    }
}
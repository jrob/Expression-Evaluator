using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Seconds : Function
    {
        public Seconds(int precedance)
            : base("seconds", precedance, 1, false)
        {
            _name2 = "Seconds";
            DoubleTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerSecond));
        }
    }
}
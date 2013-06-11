using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class TotalSeconds : Function
    {
        public TotalSeconds(int precedance)
            : base("totalseconds", precedance, 1, false)
        {
            _name2 = "TotalSeconds";
            TimespanDouble = x => x.TotalSeconds;
        }
    }
}
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class TotalDays : Function
    {
        public TotalDays(int precedance)
            : base("totaldays", precedance, 1, false)
        {
            _name2 = "TotalDays";
            TimespanDouble = x => x.TotalDays;
        }
    }
}
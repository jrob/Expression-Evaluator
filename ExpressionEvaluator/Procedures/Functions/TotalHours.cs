using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class TotalHours : Function
    {
        public TotalHours(int precedance)
            : base("totalhours", precedance, 1, false)
        {
            _name2 = "TotalHours";
            TimespanDouble = x => x.TotalHours;
        }
    }
}
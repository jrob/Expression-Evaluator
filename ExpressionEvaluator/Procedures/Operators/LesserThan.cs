using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class LesserThan : Operator
    {
        public LesserThan(int precedance)
            : base("<", precedance, 2, false)
        {
            _name2 = "LessThan";
            DoubleDoubleBool = (x, y) => x < y;
            TimespanTimespanBool = (x, y) => x < y;
            DatetimeDatetimeBool = (x, y) => x < y;
        }
    }
}
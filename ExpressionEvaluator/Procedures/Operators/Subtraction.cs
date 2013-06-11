using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class Subtraction : Operator
    {
        public Subtraction(int precedance)
            : base("-", precedance, 2, false)
        {
            _name2 = "Subtraction";
            DoubleDoubleDouble = (x, y) => x - y;
            TimespanTimespanTimespan = (x, y) => x - y;
            DatetimeTimespanDatetime = (x, y) => x - y;
            DatetimeDatetimeTimespan = (x, y) => x - y;
        }
    }
}

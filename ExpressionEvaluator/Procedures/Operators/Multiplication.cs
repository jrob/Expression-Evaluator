using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class Multiplication : Operator
    {
        public Multiplication(int precedance)
            : base("*", precedance, 2, false)
        {
            _name2 = "Multiplication";
            DoubleDoubleDouble = (x, y) => x * y;
        }
    }
}

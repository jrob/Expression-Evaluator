using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class Or : Operator
    {
        public Or(int precedance) : base("||", precedance, 2, false)
        {
            _name2 = "Or";
            BoolBoolBool = (x, y) => x || y;            
        }
    }
}
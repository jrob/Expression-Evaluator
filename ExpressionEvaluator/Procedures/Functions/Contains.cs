using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Contains : Function
    {
        public Contains(int precedance)
            : base("contains", precedance, 2, false)
        {
            _name2 = "Contains";
            StringStringBool = (x, y) => x.Contains(y);
        }
    }
}
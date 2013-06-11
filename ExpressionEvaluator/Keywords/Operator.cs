namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Operator : Procedure
    {
        public Operator(string name, int precedance, int numParams, bool variableOperandsCount)
            : base(name, precedance, numParams, variableOperandsCount)
        {
        }
    }
}
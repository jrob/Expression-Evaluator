namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Conditional : Procedure
    {
        public Conditional(string name, int precedance, int numParams, bool alwaysReturnsValue, bool variableOperandsCount)
            : base(name, precedance, numParams, alwaysReturnsValue, variableOperandsCount)
        {
        }
    }
}
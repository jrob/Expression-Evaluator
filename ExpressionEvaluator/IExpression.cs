using System;
using System.Collections.ObjectModel;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public interface IExpression
    {
        ReadOnlyCollection<string> FunctionVariables { get; }
        string InFix { get; }
        string PostFix { get; }
        string Function { get; set; }

        void AddSetVariable(string name, TimeSpan val);

        void AddSetVariable(string name, double val);

        void AddSetVariable(string name, DateTime val);

        void AddSetVariable(string name, bool val);

        void Clear();

        void ClearVariables();

        T Evaluate<T>();

        bool EvaluateBoolean();

        double EvaluateNumeric();

        T GetVariableValue<T>(string token);
    }
}

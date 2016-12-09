using System;
using System.Collections.ObjectModel;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public interface IExpression
    {
        string Function { get; set; }
        ReadOnlyCollection<string> FunctionVariables { get; }
        string InFix { get; }
        string PostFix { get; }

        void AddSetVariable(string name, TimeSpan val);

        void AddSetVariable(string name, double val);

        void AddSetVariable(string name, DateTime val);

        void AddSetVariable(string name, bool val);

        void AddSetVariable(string name, string val);

        void Clear();

        void ClearVariables();

        T Evaluate<T>();

        bool EvaluateBoolean();

        double EvaluateNumeric();

        double GetVariableValue(string token);
    }
}

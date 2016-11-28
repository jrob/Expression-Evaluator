/*****************************************************************************************
* Jeremy Roberts                                                           Expression.cs *
* 2004-07-23                                                                     Wfccm2 *
*****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    /// <summary>
    /// Evaluatable mathmatical function.
    /// </summary>
    /// <remarks><pre>
    /// 2004-07-19 - Jeremy Roberts
    /// Takes a string and allow a user to add variables. Evaluates the string as a mathmatical function.
    /// 2006-01-11 - Will Gray
    ///  - Added generic collection implementation.
    /// </pre></remarks>
    [Serializable()]
    public class Expression : MarshalByRefObject, IExpression
    {
        protected const double FALSE = 0;
        protected const double TRUE = 1;
        protected Dictionary<string, IVariable> _constants = new Dictionary<string, IVariable>();
        protected DynamicFunction _dynamicFunction;
        //protected AppDomain NewAppDomain;
        /// <summary>
        /// The function.
        /// </summary>
        protected InfixExpression _inFunction;
        protected PostFixExpression _postFunction;
        protected string[] _splitPostFunction;
        protected List<IToken> _tokens = new List<IToken>();
        protected Dictionary<string, IVariable> _variables = new Dictionary<string, IVariable>();

        /// <summary>
        /// Creation constructor.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        public Expression() {}

        /// <summary>
        /// Creation constructor.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="function">The function to be evaluated.</param>
        public Expression(string function)
        {
            Function = function;
        }

        /// <summary>
        /// InFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string Function
        {
            get { return _inFunction.Original; }
            set
            {
                _inFunction = new InfixExpression(value);
                _postFunction = new PostFixExpression(_inFunction);
                ClearVariables();
                foreach (var v in _inFunction.AutoVariables) {
                    _variables.Add(v.Key, v.Value);
                }
                BuildTokens();
            }
        }

        public ReadOnlyCollection<string> FunctionVariables
        {
            get
            {
                if (_inFunction == null) {
                    throw new ExpressionException("Function does not exist");
                }
                var retVal = _inFunction.Tokens.Where(IsVariable)
                    .Where(x => !_inFunction.AutoVariables.ContainsKey(x))
                    .ToList();
                return retVal.AsReadOnly();
            }
        }

        /// <summary>
        /// PostFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string InFix { get { return _inFunction.Expression; } }

        /// <summary>
        /// PostFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string PostFix { get { return _postFunction.Expression; } }

        public void AddSetVariable(string name, TimeSpan val)
        {
            AddSetVariable<TimeSpan>(name, val);
        }

        public void AddSetVariable(string name, double val)
        {
            AddSetVariable<decimal>(name, (decimal)val);
        }

        public void AddSetVariable(string name, DateTime val)
        {
            AddSetVariable<DateTime>(name, val);
        }

        public void AddSetVariable(string name, bool val) { AddSetVariable<bool>(name, val); }

        /// <summary>
        /// Clears all information.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public void Clear()
        {
            _inFunction = null;
            _postFunction = null;
            _variables.Clear();
        }

        /// <summary>
        /// Clears the variable information.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public void ClearVariables()
        {
            _variables.Clear();
        }

        public T Evaluate<T>()
        {
            var result = Evaluate();
            try {
                return ((GenericOperand<T>)result).Value;
            }
            catch (InvalidCastException) {
                throw new InvalidTypeExpressionException(
                    "Result was null because of an invalid type.");
            }
        }

        /// <summary>
        /// Evaluates the function given as a boolean expression.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        public bool EvaluateBoolean()
        {
            var result = Evaluate();
            return ((GenericOperand<bool>)result).Value;
        }

        /// <summary>
        /// Evaluates the function as a double.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <returns></returns>
        public double EvaluateNumeric()
        {
            try {
                var result = Evaluate();

                if (result.Type == typeof(Object)) {
                    return Double.NaN;
                }
                if (result is GenericOperand<decimal>) {
                    return (result as GenericOperand<decimal>).ToDouble()
                        .Value;
                }
                return ((GenericOperand<double>)result).Value;
            }
            catch (NotFiniteNumberException nf) {
                return double.NaN;
            }
            catch (DivideByZeroException nf) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Returns a variable's value.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">Variable to return.</param>
        /// <returns></returns>
        public T GetVariableValue<T>(string token)
        {
            return ((GenericVariable<T>)_variables[token]).Value;
        }

        public void AddSetVariable(string name, string val)
        {
            AddSetVariable<string>(name, val.ToLower());
        }

        /// <summary>
        /// Checks to see if a string is a variable.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// 2004-08-11 - Jeremy Roberts
        ///  Changed to check to see if it is a number.
        /// </pre></remarks>
        /// <param name="token">String to check.</param>
        /// <returns></returns>
        public bool IsVariable(string token)
        {
            token = token.ToLower();

            if (IsConstant(token)) {
                return false;
            }

            if (!ExpressionKeywords.IsOperand(token)) {
                return false;
            }

            if (IsNumber(token)) {
                return false;
            }

            if (IsString(token)) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Overloads the ToString method.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">The string to check.</param>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(_inFunction.Original);
            int count = 0;
            foreach (var keyval in _variables) {
                if (count++ == 0) {
                    ret.Append("; ");
                }
                else {
                    ret.Append(", ");
                }
                ret.Append(keyval.Value);
            }
            return ret.ToString();
        }

        /// <summary>
        /// Converts a string to its value representation.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">The string to check.</param>
        /// <returns></returns>
        protected IOperand ConvertToOperand(string token)
        {
            try {
                return _variables[token];
            }
            catch {
                //if (token == "true")
                //    return new GenericOperand<bool>(true);

                //if (token == "false")
                //    return new GenericOperand<bool>(false);

                if (IsConstant(token)) {
                    return ExpressionKeywords.Constants[token];
                }

                if (IsString(token)) {
                    return new GenericOperand<string>(token.Substring(1, token.Length - 2));
                }

                // Convert the operand
                return
                    new GenericOperand<decimal>(
                        decimal.Parse(token, System.Globalization.NumberStyles.Float));
            }
        }

        protected bool IsConstant(string token)
        {
            if (ExpressionKeywords.Constants.Keys.Contains(token)) {
                return true;
            }
            return false;
        }

        protected bool IsNumber(string token)
        {
            try {
                double.Parse(token);
                return true;
            }
            catch {
                return false;
            }
        }

        protected bool IsString(string token)
        {
            return (token.StartsWith("'") && token.EndsWith("'"));
        }

        private static bool IsParamTerminator(IToken current)
        {
            return current is GenericVariable<string>
                && ((GenericVariable<string>)current).Name == "param_terminator";
        }

        private void AddSetVariable<T>(string name, T val)
        {
            name = name.ToLower();
            if (_variables.ContainsKey(name)
                && _variables[name].Type == typeof(object)) {
                var oldVar = _variables[name];
                var newVar = new GenericVariable<T>(name);

                for (int i = 0; i < _tokens.Count; i++) {
                    if (_tokens[i] == oldVar) {
                        _tokens[i] = newVar;
                    }
                }
                _variables[name] = newVar;
            }
            else {
                if (!_variables.ContainsKey(name)) {
                    var v = new GenericVariable<T>(name);
                    _variables[name] = v;
                }
            }

            ((GenericVariable<T>)_variables[name]).Value = val;
        }

        private void BuildTokens()
        {
            _tokens = new List<IToken>();

            foreach (var t in _postFunction.Tokens) {
                if (IsVariable(t)) {
                    if (!_variables.ContainsKey(t)) {
                        GenericVariable<object> v;
                        v = new GenericVariable<object>(t, null);
                        _variables.Add(t, v);
                        _tokens.Add(v);
                    }
                    else {
                        var v = _variables[t];
                        _tokens.Add(v);
                    }
                    continue;
                }

                if (ExpressionKeywords.Keywords.Count(x => x.Name == t) == 1) {
                    var v = ExpressionKeywords.Keywords.Single(x => x.Name == t);
                    _tokens.Add(v);
                }

                if (IsNumber(t)) {
                    var v = (GenericOperand<decimal>)ConvertToOperand(t);
                    _tokens.Add(v);
                }

                if (IsString(t)) {
                    var v = (GenericOperand<string>)ConvertToOperand(t);
                    _tokens.Add(v);
                }

                if (IsConstant(t)) {
                    var v = ExpressionKeywords.Constants[t];
                    _tokens.Add(v);
                }
            }
        }

        private IOperand Evaluate()
        {
            var evalExceptions = new Dictionary<int, Exception>();

            var workstack = new Stack<IToken>();

            IOperand result = null;
            int currentConditionalDepth = 0;

            // loop through the postfix vector
            foreach (var token in _tokens) {
                if (!(token is Procedure)) {
                    // push the string on the workstack
                    workstack.Push(token);
                    continue;
                }

                var operands = new List<IOperand>();
                var op = token as Procedure;

                if (op.VariableOperandsCount) {
                    var current = workstack.Pop();
                    while (!IsParamTerminator(current)) {
                        operands.Insert(0, (IOperand)current);
                        current = workstack.Pop();
                    }
                }
                else {
                    for (int i = 0; i < op.NumParameters; i++) {
                        operands.Insert(0, (IOperand)workstack.Pop());
                    }
                }

                if (op.Name == "if"
                    || op.Name == "elseif"
                    || op.Name == "else") {
                    switch (op.Name) {
                        case "elseif":
                            if (currentConditionalDepth > 0) {
                                // Eat the result.
                                continue;
                            }
                            goto case "if";

                        case "if":
                            var dOp1 = operands[0] as GenericOperand<bool>;
                            if (dOp1 == null
                                || dOp1.Type != typeof(bool)) {
                                throw new ExpressionException("variable type error");
                            }
                            if (dOp1.Value) {
                                result = operands[1];
                                currentConditionalDepth++;
                            }
                            else {
                                // Eat the result.
                                continue;
                            }
                            break;

                        case "else":
                            if (currentConditionalDepth > 0) {
                                currentConditionalDepth--;
                                // Eat the result.
                                continue;
                            }
                            result = operands[0];
                            break;

                        default:
                            break;
                    }
                }
                else {
                    if (op.VariableOperandsCount) {
                        result = op.Evaluate(operands);
                    }
                    else {
                        try {
                            if (op.NumParameters == 0) {
                                result = op.Evaluate();
                            }
                            if (op.NumParameters == 1) {
                                result = op.Evaluate(operands[0]);
                            }
                            else {
                                if (op.NumParameters == 2) {
                                    result = op.Evaluate(operands[0], operands[1]);
                                }
                                else {
                                    if (op.NumParameters == 3) {
                                        result = op.Evaluate(operands[0], operands[1], operands[2]);
                                    }
                                }
                            }
                        }
                        catch (NotFiniteNumberException nf) {
                            result = new GenericOperand<double>(double.NaN);
                        }
                        catch (DivideByZeroException nf) {
                            result = new GenericOperand<double>(double.NaN);
                        }
                        catch (Exception exp) {
                            if (currentConditionalDepth <= 0) {
                                throw;
                            }

                            result = new GenericOperand<Exception>(exp);
                        }
                    }
                }

                // Push the result on the stack
                workstack.Push(result);
            }

            var val = workstack.Peek();

            if (val is GenericOperand<Exception>) {
                throw ((GenericOperand<Exception>)val).Value;
            }

            return (IOperand)val;
        }

        /// <summary>
        /// Dynaamic function type.
        /// </summary>
        /// <remarks><pre>
        /// 2005-12-20 - Jeremy Roberts
        /// </pre></remarks>
        [Serializable()]
        public abstract class DynamicFunction
        {
            public abstract bool EvaluateB(Dictionary<string, double> variables);

            public abstract double EvaluateD(Dictionary<string, double> variables);
        }

        //    ConstructorBuilder constructor = dynamicFunctionClass.DefineConstructor(
        //    Type[] constructorParams = { };
        //    ConstructorInfo objConstructor = objType.GetConstructor(new Type[0]);
        //    Type objType = Type.GetType("System.Object");
        //    //

        //    // Define class constructor
        //        typeof(DynamicFunction));
        //        TypeAttributes.Public,
        //        "DynamicFunction",
        //    TypeBuilder dynamicFunctionClass = module.DefineType(
        //    module = assembly.DefineDynamicModule("EmittedModule");
        //    ModuleBuilder module;
        //    //

        //    // Add Dynamic Module
        //        //AssemblyBuilderAccess.RunAndSave);
        //        AssemblyBuilderAccess.Run);
        //        //AssemblyBuilderAccess.Save);
        //        assemblyName,
        //    //AssemblyBuilder assembly = NewAppDomain.DefineDynamicAssembly(
        //    AssemblyBuilder assembly = Thread.GetDomain().DefineDynamicAssembly(
        //    assemblyName.Name = "EmittedAssembly";

        //    AssemblyName assemblyName = new AssemblyName();
        //    //NewAppDomain = appDomain;
        //    //NewAppDomain = System.AppDomain.CreateDomain("NewApplicationDomain");
        //    //
        //    // Set up assembly.

        //    // Create a new AppDomain.
        //    // Code to set up the object.
        //{
        //protected void compile()
        ///// </pre></remarks>
        ///// 2005-12-20 - Jeremy Roberts
        ///// <remarks><pre>
        ///// </summary>
        ///// Compiles the functions.

        ///// <summary>
        //        MethodAttributes.Public,
        //        CallingConventions.Standard,
        //        constructorParams);

        //    // Emit the class constructor.
        //    //
        //    ILGenerator constructorIL = constructor.GetILGenerator();
        //    constructorIL.Emit(OpCodes.Ldarg_0);
        //    constructorIL.Emit(OpCodes.Call, objConstructor);
        //    constructorIL.Emit(OpCodes.Ret);

        //    // Define "EvaluateD" function.
        //    //
        //    Type[] args = { typeof(Dictionary<string, double>) };
        //    MethodBuilder evalMethodD = dynamicFunctionClass.DefineMethod(
        //        "EvaluateD",
        //        MethodAttributes.Public | MethodAttributes.Virtual,
        //        typeof(double),
        //        args);
        //    ILGenerator methodILD;
        //    methodILD = evalMethodD.GetILGenerator();
        //    emitFunction(this.PostFix, methodILD);

        //    // Define "EvaluateB" function.
        //    //
        //    MethodBuilder evalMethodB = dynamicFunctionClass.DefineMethod(
        //        "EvaluateB",
        //        MethodAttributes.Public | MethodAttributes.Virtual,
        //        typeof(bool),
        //        args);
        //    ILGenerator methodILB;
        //    methodILB = evalMethodB.GetILGenerator();
        //    emitFunction(this.PostFix, methodILB);

        //    // Create an object to use.
        //    //
        //    Type dt = dynamicFunctionClass.CreateType();
        //    //assembly.Save("assem.dll");
        //    //assembly.Save("x.exe");
        //    //return (function)Activator.CreateInstance(dt, new Object[] { });
        //    this.dynamicFunction = (DynamicFunction)Activator.CreateInstance(dt, new Object[] { });
        //}

        //protected void emitFunction(string function, ILGenerator ilGen)
        //{
        //    string[] splitFunction = function.Split(new char[] { ' ' });

        //    // Set up two double variables.
        //    ilGen.DeclareLocal(typeof(System.Double));
        //    ilGen.DeclareLocal(typeof(System.Double));

        //    foreach (string token in splitFunction)
        //    {
        //        // If the current string is an operator
        //        if (this.IsOperator(token))
        //        {
        //            // call the operator
        //            switch (token)
        //            {
        //            case "+":
        //                {
        //                    // Add the operands
        //                    ilGen.Emit(OpCodes.Add);
        //                    break;
        //                }

        //            case "-":
        //                {
        //                    // Subtract the operands
        //                    ilGen.Emit(OpCodes.Sub);
        //                    break;
        //                }

        //            case "*":
        //                {
        //                    // Multiply the operands
        //                    ilGen.Emit(OpCodes.Mul);
        //                    break;
        //                }

        //            case "/":
        //                {
        //                    // Divide the operands
        //                    System.Reflection.Emit.Label pushNaN = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Store the two variables.
        //                    ilGen.Emit(OpCodes.Stloc_0); // store b in 0
        //                    ilGen.Emit(OpCodes.Stloc_1); // store a in 1

        //                    // Load the denominator and see if its 0.
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Ldc_R8, 0.0);
        //                    ilGen.Emit(OpCodes.Ceq);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushNaN);

        //                    // It is not zero, do the division.
        //                    ilGen.Emit(OpCodes.Ldloc_1);
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Div);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushNaN);
        //                    ilGen.Emit(OpCodes.Ldc_R8, double.NaN);

        //                    ilGen.MarkLabel(exit);

        //                    break;
        //                }

        //            case "^":
        //                {
        //                    // Raise the number to the power.
        //                    ilGen.EmitCall(OpCodes.Callvirt,
        //                        typeof(System.Math).GetMethod("Pow"),
        //                        null);
        //                    break;
        //                }

        //            case "sign":
        //                {
        //                    // Get the sign.
        //                    System.Reflection.Emit.Label pushNeg = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare to see if the value is less then 0
        //                    ilGen.Emit(OpCodes.Stloc_0); // store
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Ldc_R8, 0.0);
        //                    ilGen.Emit(OpCodes.Clt);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushNeg);

        //                    // Push 1
        //                    ilGen.Emit(OpCodes.Ldc_R8, 1.0);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push Neg
        //                    ilGen.MarkLabel(pushNeg);
        //                    ilGen.Emit(OpCodes.Ldc_R8, -1.0);

        //                    ilGen.MarkLabel(exit);

        //                    break;
        //                }

        //            case "abs":
        //                {
        //                    // Convert to postive.
        //                    Type[] absArgs = { typeof(System.Double) };
        //                    ilGen.EmitCall(OpCodes.Callvirt,
        //                        typeof(System.Math).GetMethod("Abs", absArgs),
        //                        null);
        //                    break;
        //                }

        //            case "neg":
        //                {
        //                    // Change the sign.
        //                    ilGen.Emit(OpCodes.Ldc_R8, -1.0);
        //                    ilGen.Emit(OpCodes.Mul);
        //                    break;
        //                }

        //            case "<=":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Cgt);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }

        //            case "<":
        //                {
        //                    // Make the comparison.
        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Clt);
        //                    break;
        //                }

        //            case ">=":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Clt);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }

        //            case ">":
        //                {
        //                    // Make the comparison.
        //                    ilGen.Emit(OpCodes.Cgt);
        //                    break;
        //                }

        //            case "==":
        //                {
        //                    // Make the comparison.
        //                    ilGen.Emit(OpCodes.Ceq);
        //                    break;
        //                }

        //            case "!=":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Ceq);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);

        //                    break;
        //                }

        //            case "||":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushTrue = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Store the two variables.
        //                    ilGen.Emit(OpCodes.Stloc_0);
        //                    ilGen.Emit(OpCodes.Stloc_1);

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushTrue);
        //                    ilGen.Emit(OpCodes.Ldloc_1);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushTrue);

        //                    // Otherwise its false
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushTrue);
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }

        //            case "&&":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Store the two variables.
        //                    ilGen.Emit(OpCodes.Stloc_0);
        //                    ilGen.Emit(OpCodes.Stloc_1);

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Brfalse_S, pushFalse);
        //                    ilGen.Emit(OpCodes.Ldloc_1);
        //                    ilGen.Emit(OpCodes.Brfalse_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }
        //            }

        //        }
        //        else if (IsVariable(token))
        //        {
        //            // push the string on the workstack
        //            ilGen.Emit(OpCodes.Ldarg_1);
        //            ilGen.Emit(OpCodes.Ldstr, token);
        //            ilGen.EmitCall(OpCodes.Callvirt,
        //                typeof(System.Collections.Generic.Dictionary<string, double>).GetMethod("get_Item"),
        //                null);
        //            //ilGen.Emit(OpCodes.Unbox_Any, typeof(System.Double));
        //        }
        //        else if (token.Equals("true"))
        //        {
        //            ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //        }
        //        else if (token.Equals("false"))
        //        {
        //            ilGen.Emit(OpCodes.Ldc_R8, FALSE);
        //        }
        //        else
        //        {
        //            // Parse the number.
        //            ilGen.Emit(OpCodes.Ldc_R8, double.Parse(token));
        //        }
        //    }
        //    ilGen.Emit(OpCodes.Ret);
        //}
    }
}

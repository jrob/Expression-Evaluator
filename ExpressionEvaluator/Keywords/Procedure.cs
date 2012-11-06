using System;
using ExpressionEvaluator.Procedures;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Procedure : Keyword
    {
        protected Func<double> Double;
        protected Func<double, double> DoubleDouble;
        protected Func<DateTime> Datetime;
        protected Func<DateTime, double> DatetimeDouble;
        protected Func<double, TimeSpan> DoubleTimespan;
        protected Func<TimeSpan, double> TimespanDouble;
        protected Func<DateTime, TimeSpan, DateTime> DatetimeTimespanDatetime;
        protected Func<TimeSpan, DateTime, DateTime> TimespanDatetimeDatetime;
        protected Func<DateTime, DateTime, TimeSpan> DatetimeDatetimeTimespan;
        protected Func<TimeSpan, TimeSpan, TimeSpan> TimespanTimespanTimespan;
        protected Func<TimeSpan, TimeSpan, bool> TimespanTimespanBool;
        protected Func<double, double, double> DoubleDoubleDouble;
        protected Func<Object, Object, bool> AnyAnyBool;
        protected Func<bool, bool, bool> BoolBoolBool;
        protected Func<string, string, bool> StringStringBool;
        protected Func<double, double, bool> DoubleDoubleBool;
        protected Func<DateTime, DateTime, bool> DatetimeDatetimeBool;
        protected Func<Object, Object, bool> ObjectObjectBool;
        protected Func<String, double> StringDouble; 
        protected string _name2;

        public Procedure(string name, int precedance, int numParams)
            : base(name, precedance)
        {
            NumParameters = numParams;
            AlwaysReturnsValue = true;
        }

        public Procedure(string name, int precedance, int numParams, bool alwaysReturnsValue)
            : base(name, precedance)
        {
            NumParameters = numParams;
            AlwaysReturnsValue = alwaysReturnsValue;
        }

        public int NumParameters { get; private set; }
        public bool AlwaysReturnsValue { get; private set; }

        public IOperand Evaluate()
        {
            if (Datetime != null)
            {
                return new GenericOperand<DateTime>(Datetime());
            }

            throw new ExpressionException(_name2 + " operator used incorrectly.");
        }

        public IOperand Evaluate(IOperand op1)
        {
            if (DoubleDouble != null)
            {
                if (op1.Type == typeof(double))
                {
                    var dOp1 = op1 as GenericOperand<double>;
                    return new GenericOperand<double>(DoubleDouble(dOp1.Value));
                }
            }

            if (StringDouble != null)
            {
                if (op1.Type == typeof(string))
                {
                    var dOp1 = op1 as GenericOperand<string>;
                    return new GenericOperand<double>(StringDouble(dOp1.Value));
                }
            }

            if (DoubleTimespan != null)
            {
                if (op1.Type == typeof(double))
                {
                    var dOp1 = op1 as GenericOperand<double>;
                    return new GenericOperand<TimeSpan>(DoubleTimespan(dOp1.Value));
                }
            }

            if (TimespanDouble != null)
            {
                if (op1.Type == typeof(TimeSpan))
                {
                    var dOp1 = op1 as GenericOperand<TimeSpan>;
                    return new GenericOperand<double>(TimespanDouble(dOp1.Value));
                }
            }

            throw new ExpressionException(_name2 + " operator used incorrectly.");
        }

        public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            try
            {
                if (DoubleDoubleDouble != null)
                {
                    if (op1.Type == typeof(double) && op2.Type == typeof(double))
                    {
                        var dOp1 = op1 as GenericOperand<double>;
                        var dOp2 = op2 as GenericOperand<double>;
                        return new GenericOperand<double>(DoubleDoubleDouble(dOp1.Value, dOp2.Value));
                    }
                }

                if (BoolBoolBool != null)
                {
                    if (op1.Type == typeof(bool) && op2.Type == typeof(bool))
                    {
                        var bOp1 = op1 as GenericOperand<bool>;
                        var bOp2 = op2 as GenericOperand<bool>;
                        return new GenericOperand<bool>(BoolBoolBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (TimespanTimespanBool != null)
                {
                    if (op1.Type == typeof(TimeSpan) && op2.Type == typeof(TimeSpan))
                    {
                        var bOp1 = op1 as GenericOperand<TimeSpan>;
                        var bOp2 = op2 as GenericOperand<TimeSpan>;
                        return new GenericOperand<bool>(TimespanTimespanBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (DoubleDoubleBool != null)
                {
                    if (op1.Type == typeof(double) && op2.Type == typeof(double))
                    {
                        var bOp1 = op1 as GenericOperand<double>;
                        var bOp2 = op2 as GenericOperand<double>;
                        return new GenericOperand<bool>(DoubleDoubleBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (StringStringBool != null)
                {
                    if (op1.Type == typeof(string) && op2.Type == typeof(string))
                    {
                        var bOp1 = op1 as GenericOperand<string>;
                        var bOp2 = op2 as GenericOperand<string>;
                        return new GenericOperand<bool>(StringStringBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (TimespanTimespanTimespan != null)
                {
                    if (op1.Type == typeof(TimeSpan) && op2.Type == typeof(TimeSpan))
                    {
                        var bOp1 = op1 as GenericOperand<TimeSpan>;
                        var bOp2 = op2 as GenericOperand<TimeSpan>;
                        return new GenericOperand<TimeSpan>(TimespanTimespanTimespan(bOp1.Value, bOp2.Value));
                    }
                }

                if (DatetimeTimespanDatetime != null)
                {
                    if (op1.Type == typeof(DateTime) && op2.Type == typeof(TimeSpan))
                    {
                        var bOp1 = op1 as GenericOperand<DateTime>;
                        var bOp2 = op2 as GenericOperand<TimeSpan>;
                        return new GenericOperand<DateTime>(DatetimeTimespanDatetime(bOp1.Value, bOp2.Value));
                    }
                }

                if (TimespanDatetimeDatetime != null)
                {
                    if (op1.Type == typeof(TimeSpan) && op2.Type == typeof(DateTime))
                    {
                        var bOp1 = op1 as GenericOperand<TimeSpan>;
                        var bOp2 = op2 as GenericOperand<DateTime>;
                        return new GenericOperand<DateTime>(TimespanDatetimeDatetime(bOp1.Value, bOp2.Value));
                    }
                }

                if (DatetimeDatetimeTimespan != null)
                {
                    if (op1.Type == typeof(DateTime) && op2.Type == typeof(DateTime))
                    {
                        var bOp1 = op1 as GenericOperand<DateTime>;
                        var bOp2 = op2 as GenericOperand<DateTime>;
                        return new GenericOperand<TimeSpan>(DatetimeDatetimeTimespan(bOp1.Value, bOp2.Value));
                    }
                }

                if (DatetimeDatetimeBool != null)
                {
                    if (op1.Type == typeof(DateTime) && op2.Type == typeof(DateTime))
                    {
                        var bOp1 = op1 as GenericOperand<DateTime>;
                        var bOp2 = op2 as GenericOperand<DateTime>;
                        return new GenericOperand<bool>(DatetimeDatetimeBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (ObjectObjectBool != null)
                {
                    if (op1.Type == typeof(Object) && op2.Type == typeof(Object))
                    {
                        var bOp1 = op1 as GenericOperand<Object>;
                        var bOp2 = op2 as GenericOperand<Object>;
                        return new GenericOperand<bool>(ObjectObjectBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (AnyAnyBool != null)
                {
                    return new GenericOperand<bool>(AnyAnyBool(op1, op2));
                }

                if (op1.Type == typeof(Object) || op2.Type == typeof(Object))
                {
                    return new GenericOperand<object>();
                }
            }
            catch(Exception e)
            {
                throw new ExpressionException(_name2 + " operator threw an exception. Operand types: " + op1.Type.Name + ", " + op2.Type.Name + "." + Environment.NewLine + e.Message);
            }
            throw new ExpressionException(_name2 + " operator used incorrectly. Operand types: " + op1.Type.Name + ", " + op2.Type.Name + ".");
        }

    }
}
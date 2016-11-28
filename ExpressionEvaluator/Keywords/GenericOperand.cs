using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class GenericOperand<T> : IOperand
    {
        public GenericOperand(T value) { Value = value; }

        public GenericOperand() { }

        public T Value { get; set; }
        public Type Type { get { return typeof(T); } }

        public override string ToString() { return Value == null ? "null" : Value.ToString(); }

        public GenericOperand<double> ToDouble()
        {
            try {
                return new GenericOperand<double>(Convert.ToDouble(Value.ToString()));
            }
            catch {
                return new GenericOperand<double>(Double.NaN);
            }
        }
    }
}

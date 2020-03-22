using System;

namespace Quantities.Measures.Normalisation
{
    internal abstract class Operator
    {
        public abstract Double Execute(in Double value);
    }
    internal sealed class NoOp : Operator
    {
        public override Double Execute(in Double value) => value;
    }
    internal sealed class Multiply : Operator
    {
        private readonly Double _factor;
        internal Multiply(in Double factor) => _factor = factor;
        public override Double Execute(in Double value) => value * _factor;
    }
    internal sealed class Divide : Operator
    {
        private readonly Double _divisor;
        internal Divide(in Double divisor) => _divisor = divisor;
        public override Double Execute(in Double value) => value / _divisor;
    }
}
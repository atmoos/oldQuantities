using System;

namespace Quantities.Measures.Core
{
    public abstract class Dimension
    {
        private protected Dimension() { }
        internal Double Factor(Int32 exponent) => Math.Pow(10d, Raise(exponent));
        private protected abstract Int32 Raise(Int32 exponent);
    }
    public sealed class Linear : Dimension
    {
        private protected override Int32 Raise(Int32 exponent) => exponent;

        public override String ToString() => String.Empty;
    }
    public sealed class Square : Dimension
    {
        private protected override Int32 Raise(Int32 exponent) => 2 * exponent;

        public override String ToString() => "²";
    }
    public sealed class Cube : Dimension
    {
        private protected override Int32 Raise(Int32 exponent) => 3 * exponent;

        public override String ToString() => "³";
    }
}
using System;

namespace Quantities.Prefixes.Dimensions
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
    }
    public sealed class Square : Dimension
    {
        private protected override Int32 Raise(Int32 exponent) => 2 * exponent;
    }
    public sealed class Cube : Dimension
    {
        private protected override Int32 Raise(Int32 exponent) => 3 * exponent;
    }
}
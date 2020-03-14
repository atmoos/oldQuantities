using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Chain : Convertible, IImperial, ILength
    {
        public Chain() : base(20.1168 /* m */) { }
        public override String ToString() => "ch";
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial
{
    public sealed class Yard : Convertible, IImperial, ILength
    {
        public Yard() : base(0.9144 /* m */) { }
        public override String ToString() => "yd";
    }
}
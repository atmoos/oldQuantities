using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Yard : Transform, IImperial, ILength
    {
        public Yard() : base(0.9144 /* m */) { }
        public override String ToString() => "yd";
    }
}
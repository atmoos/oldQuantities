using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Foot : Transform, IImperial, ILength
    {
        public Foot() : base(0.3048 /* m */) { }
        public override String ToString() => "ft";
    }
}
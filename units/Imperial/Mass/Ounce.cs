using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Ounce : Transform, IImperial, IMass
    {
        public Ounce() : base(28.349523125e-3 /* kg */) { }
        public override String ToString() => "oz";
    }
}
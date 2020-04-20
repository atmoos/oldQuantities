using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Pound : Transform, IImperial, IMass
    {
        public Pound() : base(0.45359237 /* kg */) { }
        public override String ToString() => "lb";
    }
}
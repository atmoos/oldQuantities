using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Hundredweight : Transform, IImperial, IMass
    {
        public Hundredweight() : base(50.80234544 /* kg */) { }
        public override String ToString() => "cwt";
    }
}
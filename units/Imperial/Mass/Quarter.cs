using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Quarter : Transform, IImperial, IMass
    {
        public Quarter() : base(12.70058636 /* kg */) { }
        public override String ToString() => "qr";
    }
}
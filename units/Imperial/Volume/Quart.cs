using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Quart : Transform, IImperial, IVolume
    {
        public Quart() : base(1.1365225e-3 /* m³ */) { }
        public override String ToString() => "qt";
    }
}
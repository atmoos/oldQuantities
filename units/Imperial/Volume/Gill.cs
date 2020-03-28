using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Gill : Transform, IImperial, IVolume
    {
        public Gill() : base(0.1420653125e-3 /* m³ */) { }
        public override String ToString() => "gi";
    }
}
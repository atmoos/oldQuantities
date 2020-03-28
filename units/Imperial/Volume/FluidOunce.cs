using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class FluidOunce : Transform, IImperial, IVolume
    {
        public FluidOunce() : base(0.0284130625e-3 /* m³ */) { }
        public override String ToString() => "fl oz";
    }
}
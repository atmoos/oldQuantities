using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class FluidOunce : Convertible, IImperial, IVolume
    {
        public FluidOunce() : base(28.4130625e-9 /* m³ */) { }
        public override String ToString() => "fl oz";
    }
}
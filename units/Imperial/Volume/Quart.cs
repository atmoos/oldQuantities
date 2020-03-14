using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Quart : Convertible, IImperial, IVolume
    {
        public Quart() : base(1136.5225e-9 /* m³ */) { }
        public override String ToString() => "qt";
    }
}
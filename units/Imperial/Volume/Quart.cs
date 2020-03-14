using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Quart : Convertible, IImperial, IVolume
    {
        public Quart() : base(1.1365225e-3 /* m³ */) { }
        public override String ToString() => "qt";
    }
}
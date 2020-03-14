using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Gill : Convertible, IImperial, IVolume
    {
        public Gill() : base(142.0653125e-9 /* m³ */) { }
        public override String ToString() => "gi";
    }
}
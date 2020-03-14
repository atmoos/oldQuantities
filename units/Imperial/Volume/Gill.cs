using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Gill : Convertible, IImperial, IVolume
    {
        public Gill() : base(0.1420653125e-3 /* m³ */) { }
        public override String ToString() => "gi";
    }
}
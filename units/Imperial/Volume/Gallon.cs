using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Gallon : Convertible, IImperial, IVolume
    {
        public Gallon() : base(4.54609e-3 /* m³ */) { }
        public override String ToString() => "gal";
    }
}
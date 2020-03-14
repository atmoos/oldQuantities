using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Gallon : Convertible, IImperial, IVolume
    {
        public Gallon() : base(4546.09e-9 /* m³ */) { }
        public override String ToString() => "gal";
    }
}
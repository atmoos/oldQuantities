using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Volume
{
    public sealed class Pint : Convertible, IImperial, IVolume
    {
        public Pint() : base(0.56826125e-3 /* m³ */) { }
        public override String ToString() => "pt";
    }
}
using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Kilogram : SiBaseUnit, IMass
    {
        public override String ToString() => "kg";
    }
}
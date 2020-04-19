using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Kelvin : SiBaseUnit, ITemperature
    {
        public override String ToString() => "K";
    }
}
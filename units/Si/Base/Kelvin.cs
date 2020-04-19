using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Kelvin : ISiBaseUnit, ITemperature
    {
        public override String ToString() => "K";
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Other.Temperature
{
    // [K] = [°Ré] × ​5⁄4 + 273.15
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class Réaumur : LinearTransform, IOther, ITemperature
    {
        public Réaumur() : base(5, 4m, 273.15m) { }

        public override String ToString() => "°Ré";
    }
}
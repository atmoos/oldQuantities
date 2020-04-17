using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Other.Temperature
{
    // [K] = [°N] × ​100⁄33 + 273.15
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class Newton : LinearTransform, IOther, ITemperature
    {
        public Newton() : base(100m, 33m, 273.15m) { }

        public override String ToString() => "°N";
    }
}
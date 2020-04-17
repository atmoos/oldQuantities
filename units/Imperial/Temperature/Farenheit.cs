using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Imperial.Temperature
{
    // [K] ≡ ([°F] + 459.67) × ​5⁄9
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class Fahrenheit : IImperial, ITemperature
    {
        private const Decimal KELVIN_OFFSET = 459.67m;
        private const Decimal SCALE_FROM_KELVIN = 9m / 5m;
        public Double ToSi(in Double nonSiValue) => (Double)((5m * ((Decimal)nonSiValue + KELVIN_OFFSET)) / 9m);
        public Double FromSi(in Double siValue) => (Double)((SCALE_FROM_KELVIN * (Decimal)siValue) - KELVIN_OFFSET);

        public override String ToString() => "°F";
    }
}
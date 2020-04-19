using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si.Derived
{
    // [K] ≡ [°C] + 273.15
    // Celsius is officially an SI derived unit.
    public sealed class Celsius : ISiDerivedUnit, ITransform, ITemperature
    {
        private const Decimal KELVIN_OFFSET = 273.15m;
        public Double ToSi(in Double nonSiValue) => (Double)((Decimal)nonSiValue + KELVIN_OFFSET);
        public Double FromSi(in Double siValue) => (Double)((Decimal)siValue - KELVIN_OFFSET);

        public override String ToString() => "°C";
    }
}
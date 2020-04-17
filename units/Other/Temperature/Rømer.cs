using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Other.Temperature
{
    // [K] = ([°Rø] − 7.5) × ​40⁄21 + 273.15
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class Rømer : IOther, ITemperature
    {
        const Decimal SCALE_FROM_SI = 21m / 40m;
        Double ITransform.ToSi(in Double nonSiValue) => (Double)((40m * ((Decimal)nonSiValue - 7.5m) / 21m) + 273.15m);
        Double ITransform.FromSi(in Double siValue) => (Double)(SCALE_FROM_SI * ((Decimal)siValue - 273.15m) + 7.5m);

        public override String ToString() => "°Rø";
    }
}
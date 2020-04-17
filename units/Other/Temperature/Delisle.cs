using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Other.Temperature
{
    // [K] = 373.15 − [°De] × ​2⁄3
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class Delisle : ITransform, IOther, ITemperature
    {
        Double ITransform.ToSi(in Double nonSiValue) => (Double)(373.15m - (2m * (Decimal)nonSiValue) / 3m);
        Double ITransform.FromSi(in Double siValue) => (Double)(-1.5m * ((Decimal)siValue - 373.15m));

        public override String ToString() => "°De";
    }
}
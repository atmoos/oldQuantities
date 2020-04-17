using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Temperature
{
    // [K] ≡ [°R] × 5/9
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class Rankine : IImperial, ITemperature
    {
        Double ITransform.ToSi(in Double nonSiValue) => (Double)((5m * (Decimal)nonSiValue) / 9m);
        Double ITransform.FromSi(in Double siValue) => (Double)((9m * (Decimal)siValue) / 5m);

        public override String ToString() => "°R";
    }
}
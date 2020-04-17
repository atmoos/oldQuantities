using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Temperature
{
    // [K] ≡ [GM] × ​125⁄9 + 394.261 
    // See: https://en.wikipedia.org/wiki/Conversion_of_units#Temperature
    public sealed class GasMark : LinearTransform, IImperial, ITemperature
    {
        private const Decimal OFFSET = (5m * 218m) / 9m + 273.15m;
        public GasMark() : base(125m, 9m, OFFSET) { }

        public override String ToString() => "GM";
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial
{
    public sealed class Mile : Convertible, IImperial, ILength
    {
        public Mile() : base(1609.334) { }
        public override String ToString() => "mi";
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial
{
    public sealed class Acre : Convertible, IImperial, IArea
    {
        public Acre() : base(4046.9 /* m² */) { }
        public override String ToString() => "ac";
    }
}
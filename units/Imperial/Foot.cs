using System;
using Quantities.Dimensions;
using Quantities.Unit.Si;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial
{
    public sealed class Foot : Convertible<Metre, Foot>, IImperial, ILength
    {
        public Foot() : base(0.3048) { }
        public override String ToString() => "ft";
    }
}
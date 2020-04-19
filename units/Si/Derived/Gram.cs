using System;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Unit.Si.Derived
{
    public sealed class Gram : SiAlias<Milli, Kilogram>, IMass
    {
        public override String ToString() => "g";
    }
}
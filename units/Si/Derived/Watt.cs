using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si.Derived
{
    public sealed class Watt : SiDerived, IPower
    {
        public override String ToString() => "W";
    }
}
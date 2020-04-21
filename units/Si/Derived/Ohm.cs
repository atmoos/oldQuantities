using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si.Derived
{
    public sealed class Ohm : SiDerived, IElectricalResistance
    {
        public override String ToString() => "Ω";
    }
}
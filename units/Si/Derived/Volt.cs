using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si.Derived
{
    public sealed class Volt : SiDerived, IElectricPotential
    {
        public override String ToString() => "V";
    }
}
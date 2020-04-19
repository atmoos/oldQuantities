using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Ampere : SiBaseUnit, IElectricCurrent
    {
        public override String ToString() => "A";
    }
}
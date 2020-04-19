using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Ampere : ISiBaseUnit, IElectricCurrent
    {
        public override String ToString() => "A";
    }
}
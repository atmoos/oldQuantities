using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Mole : SiBaseUnit, IAmountOfSubstance
    {
        public override String ToString() => "mol";
    }
}
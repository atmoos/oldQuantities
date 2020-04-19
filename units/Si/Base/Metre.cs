using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Metre : SiBaseUnit, ILength
    {
        public override String ToString() => "m";
    }
}
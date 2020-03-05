using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Metre : SiUnit, ILength
    {
        public override String ToString() => "m";
    }
}
using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Candela : SiBaseUnit, ILuminousIntensity
    {
        public override String ToString() => "cd";
    }
}
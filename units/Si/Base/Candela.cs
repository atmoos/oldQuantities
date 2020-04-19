using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Si
{
    public sealed class Candela : ISiBaseUnit, ILuminousIntensity
    {
        public override String ToString() => "cd";
    }
}
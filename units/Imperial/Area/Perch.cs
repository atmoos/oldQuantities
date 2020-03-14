using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Area
{
    public sealed class Perch : Convertible, IImperial, IArea
    {
        public Perch() : base(25.29285264 /* m² */) { }
        public override String ToString() => "perch";
    }
}
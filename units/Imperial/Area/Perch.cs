using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Area
{
    public sealed class Perch : Transform, IImperial, IArea
    {
        public Perch() : base(25.29285264 /* m² */) { }
        public override String ToString() => "perch";
    }
}
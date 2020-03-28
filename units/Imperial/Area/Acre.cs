using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Area
{
    public sealed class Acre : Transform, IImperial, IArea
    {
        public Acre() : base(4046.8564224 /* m² */) { }
        public override String ToString() => "ac";
    }
}
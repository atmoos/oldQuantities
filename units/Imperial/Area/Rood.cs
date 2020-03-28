using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Area
{
    public sealed class Rood : Transform, IImperial, IArea
    {
        public Rood() : base(1011.7141056 /* m² */) { }
        public override String ToString() => "rōd";
    }
}
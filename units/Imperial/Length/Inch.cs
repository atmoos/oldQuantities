using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Inch : Transform, IImperial, ILength
    {
        public Inch() : base(0.0254 /* m */) { }
        public override String ToString() => "in";
    }
}
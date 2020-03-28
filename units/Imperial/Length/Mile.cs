using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Mile : Transform, IImperial, ILength
    {
        public Mile() : base(1609.334 /* m */) { }
        public override String ToString() => "mi";
    }
}
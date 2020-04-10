using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Mile : Transform, IImperial, ILength
    {
        public Mile() : base(1609.344 /* m */) { }
        public override String ToString() => "mi";
    }
}
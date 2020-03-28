using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Furlong : Transform, IImperial, ILength
    {
        public Furlong() : base(201.168 /* m */) { }
        public override String ToString() => "fur";
    }
}
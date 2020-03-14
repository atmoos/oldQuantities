using System;
using Quantities.Dimensions;
using Quantities.Unit.Conversion;

namespace Quantities.Unit.Imperial.Length
{
    public sealed class Furlong : Convertible, IImperial, ILength
    {
        public Furlong() : base(201.168 /* m */) { }
        public override String ToString() => "fur";
    }
}
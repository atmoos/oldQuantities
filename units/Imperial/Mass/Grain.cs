using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Grain : Transform, IImperial, IMass
    {
        public Grain() : base(64.79891e-6 /* kg */) { }
        public override String ToString() => "gr";
    }
}
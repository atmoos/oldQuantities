using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Stone : Transform, IImperial, IMass
    {
        public Stone() : base(6.35029318 /* kg */) { }
        public override String ToString() => "st";
    }
}
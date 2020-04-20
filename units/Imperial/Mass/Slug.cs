using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Slug : Transform, IImperial, IMass
    {
        public Slug() : base(14.59390294 /* kg */) { }
        public override String ToString() => "slug";
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Ton : Transform, IImperial, IMass
    {
        public Ton() : base(1016.0469088 /* kg */) { }
        public override String ToString() => "t";
    }
}
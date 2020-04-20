using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Imperial.Mass
{
    public sealed class Drachm : Transform, IImperial, IMass
    {
        public Drachm() : base(1.7718451953125e-3 /* kg */) { }
        public override String ToString() => "dr";
    }
}
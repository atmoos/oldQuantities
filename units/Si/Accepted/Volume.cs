using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Si.Accepted
{
    public sealed class Litre : Transform, ISiAcceptedUnit, IVolume
    {
        public Litre() : base(1e-3  /* m³ */) { }
        public override String ToString() => "ℓ";
    }
}
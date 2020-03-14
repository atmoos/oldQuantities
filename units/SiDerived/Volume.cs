using System;
using Quantities.Dimensions;

namespace Quantities.Unit.SiDerived
{
    public sealed class Litre : SiDerivedUnit, IVolume
    {
        public Litre() : base(1e-3  /* m³ */) { }
        public override String ToString() => "ℓ";
    }
}
using System;

namespace Quantities.Unit.SiDerived
{
    public sealed class Newton : SiDerivedUnit
    {
        // ToDo: This is rather ugly...
        public Newton() : base(1d) { }

        public override String ToString() => "N";
    }
}
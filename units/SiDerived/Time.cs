using System;
using Quantities.Dimensions;

namespace Quantities.Unit.SiDerived
{
    public sealed class Minute : SiDerivedUnit, ITime
    {
        public Minute() : base(60) { }
        public override String ToString() => "m";
    }
    public sealed class Hour : SiDerivedUnit, ITime
    {
        public Hour() : base(3600) { } // 60*60
        public override String ToString() => "h";
    }
    public sealed class Day : SiDerivedUnit, ITime
    {
        public Day() : base(86400) { } // 60*60*24
        public override String ToString() => "d";
    }
    public sealed class Week : SiDerivedUnit, ITime
    {
        public Week() : base(604800) { } // 60*60*24*7
        public override String ToString() => "w";
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Unit.Transformation;

namespace Quantities.Unit.Si.Accepted
{
    public sealed class Minute : Transform, ISiAcceptedUnit, ITime
    {
        public Minute() : base(60 /* s */) { }
        public override String ToString() => "m";
    }
    public sealed class Hour : Transform, ISiAcceptedUnit, ITime
    {
        public Hour() : base(3600 /* s */) { } // 60*60
        public override String ToString() => "h";
    }
    public sealed class Day : Transform, ISiAcceptedUnit, ITime
    {
        public Day() : base(86400 /* s */) { } // 60*60*24
        public override String ToString() => "d";
    }
    public sealed class Week : Transform, ISiAcceptedUnit, ITime
    {
        public Week() : base(604800 /* s */) { } // 60*60*24*7
        public override String ToString() => "w";
    }
}
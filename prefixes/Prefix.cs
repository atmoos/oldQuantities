using System;

namespace Quantities.Prefix
{
    /*
    yotta   Y   1000000000000000000000000   10+21
    zetta   Z   1000000000000000000000   10+21
    exa     E   1000000000000000000   10+18
    peta    P   1000000000000000   10+15
    tera    T   1000000000000   10+12
    giga    G   1000000000   10+9
    mega    M   1000000   10+6
    kilo    k   1000   10+3
    hecto   h   100   10+2
    deca    da  10   10+1
    (none)  (none)  1   10+0
    deci    d   0.1   10−1
    centi   c   0.01   10−2
    milli   m   0.001   10−3
    micro   μ   0.000001   10−6
    nano    n   0.000000001   10−9
    pico    p   0.000000000001   10−12
    femto   f   0.000000000000001   10−15
    atto    a   0.000000000000000001   10−18
    zepto   z   0.000000000000000000001   10−21
    yocto   y   0.000000000000000000000001   10−24
    */
    public abstract class Prefix
    {
        internal Int32 Exponent { get; }
        protected internal Prefix(Int32 exponent) => Exponent = exponent;
        public abstract override String ToString();
    }
    public sealed class Yotta : Prefix
    {
        internal Yotta() : base(24) { }
        public override String ToString() => "Y";
    }
    public sealed class Zetta : Prefix
    {
        internal Zetta() : base(21) { }
        public override String ToString() => "Z";
    }
    public sealed class Exa : Prefix
    {
        internal Exa() : base(18) { }
        public override String ToString() => "E";
    }
    public sealed class Peta : Prefix
    {
        internal Peta() : base(15) { }
        public override String ToString() => "P";
    }
    public sealed class Tera : Prefix
    {
        internal Tera() : base(12) { }
        public override String ToString() => "T";
    }
    public sealed class Giga : Prefix
    {
        internal Giga() : base(9) { }
        public override String ToString() => "G";
    }
    public sealed class Mega : Prefix
    {
        internal Mega() : base(6) { }
        public override String ToString() => "M";
    }
    public sealed class Kilo : Prefix
    {
        internal Kilo() : base(3) { }
        public override String ToString() => "K";
    }
    public sealed class Hecto : Prefix
    {
        internal Hecto() : base(2) { }
        public override String ToString() => "h";
    }
    public sealed class Deca : Prefix
    {
        internal Deca() : base(1) { }
        public override String ToString() => "da";
    }
    [System.Diagnostics.DebuggerDisplay("1")]
    sealed class UnitPrefix : Prefix
    {
        internal UnitPrefix() : base(0) { }
        public override String ToString() => String.Empty;
    }
    public sealed class Deci : Prefix
    {
        internal Deci() : base(-1) { }
        public override String ToString() => "d";

    }
    public sealed class Centi : Prefix
    {
        internal Centi() : base(-2) { }
        public override String ToString() => "c";
    }
    public sealed class Milli : Prefix
    {
        internal Milli() : base(-3) { }
        public override String ToString() => "m";
    }
    public sealed class Micro : Prefix
    {
        internal Micro() : base(-6) { }
        public override String ToString() => "μ";
    }
    public sealed class Nano : Prefix
    {
        internal Nano() : base(-9) { }
        public override String ToString() => "n";
    }
    public sealed class Pico : Prefix
    {
        internal Pico() : base(-12) { }
        public override String ToString() => "p";
    }
    public sealed class Femto : Prefix
    {
        internal Femto() : base(-15) { }
        public override String ToString() => "f";
    }
    public sealed class Atto : Prefix
    {
        internal Atto() : base(-18) { }
        public override String ToString() => "a";
    }
    public sealed class Zepto : Prefix
    {
        internal Zepto() : base(-21) { }
        public override String ToString() => "z";
    }
    public sealed class Yocto : Prefix
    {
        internal Yocto() : base(-24) { }
        public override String ToString() => "y";
    }
}
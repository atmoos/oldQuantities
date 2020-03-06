using System;

namespace Quantities.Prefixes
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
        internal abstract Prefix Multiply<TRight>()
            where TRight : Prefix, new();
        internal abstract Prefix Divide<TDenominator>()
            where TDenominator : Prefix, new();
        public abstract override String ToString();
    }
    public sealed class Yotta : Prefix
    {
        public Yotta() : base(24) { }
        public override String ToString() => "Y";
        internal override Prefix Multiply<TRight>() => Multiply<Yotta, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Yotta, TDenominator>.Result;
    }
    public sealed class Zetta : Prefix
    {
        public Zetta() : base(21) { }
        public override String ToString() => "Z";
        internal override Prefix Multiply<TRight>() => Multiply<Zetta, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Zetta, TDenominator>.Result;
    }
    public sealed class Exa : Prefix
    {
        public Exa() : base(18) { }
        public override String ToString() => "E";
        internal override Prefix Multiply<TRight>() => Multiply<Exa, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Exa, TDenominator>.Result;
    }
    public sealed class Peta : Prefix
    {
        public Peta() : base(15) { }
        public override String ToString() => "P";
        internal override Prefix Multiply<TRight>() => Multiply<Peta, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Peta, TDenominator>.Result;
    }
    public sealed class Tera : Prefix
    {
        public Tera() : base(12) { }
        public override String ToString() => "T";
        internal override Prefix Multiply<TRight>() => Multiply<Tera, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Tera, TDenominator>.Result;
    }
    public sealed class Giga : Prefix
    {
        public Giga() : base(9) { }
        public override String ToString() => "G";
        internal override Prefix Multiply<TRight>() => Multiply<Giga, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Giga, TDenominator>.Result;
    }
    public sealed class Mega : Prefix
    {
        public Mega() : base(6) { }
        public override String ToString() => "M";
        internal override Prefix Multiply<TRight>() => Multiply<Mega, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Mega, TDenominator>.Result;
    }
    public sealed class Kilo : Prefix
    {
        public Kilo() : base(3) { }
        public override String ToString() => "K";
        internal override Prefix Multiply<TRight>() => Multiply<Kilo, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Kilo, TDenominator>.Result;
    }
    public sealed class Hecto : Prefix
    {
        public Hecto() : base(2) { }
        public override String ToString() => "h";
        internal override Prefix Multiply<TRight>() => Multiply<Hecto, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Hecto, TDenominator>.Result;
    }
    public sealed class Deca : Prefix
    {
        public Deca() : base(1) { }
        public override String ToString() => "da";
        internal override Prefix Multiply<TRight>() => Multiply<Deca, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Deca, TDenominator>.Result;
    }
    [System.Diagnostics.DebuggerDisplay("1")]
    sealed class UnitPrefix : Prefix
    {
        public UnitPrefix() : base(0) { }
        public override String ToString() => String.Empty;
        internal override Prefix Multiply<TRight>() => Multiply<UnitPrefix, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<UnitPrefix, TDenominator>.Result;
    }
    public sealed class Deci : Prefix
    {
        public Deci() : base(-1) { }
        public override String ToString() => "d";
        internal override Prefix Multiply<TRight>() => Multiply<Deci, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Deci, TDenominator>.Result;

    }
    public sealed class Centi : Prefix
    {
        public Centi() : base(-2) { }
        public override String ToString() => "c";
        internal override Prefix Multiply<TRight>() => Multiply<Centi, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Centi, TDenominator>.Result;
    }
    public sealed class Milli : Prefix
    {
        public Milli() : base(-3) { }
        public override String ToString() => "m";
        internal override Prefix Multiply<TRight>() => Multiply<Milli, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Milli, TDenominator>.Result;
    }
    public sealed class Micro : Prefix
    {
        public Micro() : base(-6) { }
        public override String ToString() => "μ";
        internal override Prefix Multiply<TRight>() => Multiply<Micro, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Micro, TDenominator>.Result;
    }
    public sealed class Nano : Prefix
    {
        public Nano() : base(-9) { }
        public override String ToString() => "n";
        internal override Prefix Multiply<TRight>() => Multiply<Nano, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Nano, TDenominator>.Result;
    }
    public sealed class Pico : Prefix
    {
        public Pico() : base(-12) { }
        public override String ToString() => "p";
        internal override Prefix Multiply<TRight>() => Multiply<Pico, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Pico, TDenominator>.Result;
    }
    public sealed class Femto : Prefix
    {
        public Femto() : base(-15) { }
        public override String ToString() => "f";
        internal override Prefix Multiply<TRight>() => Multiply<Femto, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Femto, TDenominator>.Result;
    }
    public sealed class Atto : Prefix
    {
        public Atto() : base(-18) { }
        public override String ToString() => "a";
        internal override Prefix Multiply<TRight>() => Multiply<Atto, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Atto, TDenominator>.Result;
    }
    public sealed class Zepto : Prefix
    {
        public Zepto() : base(-21) { }
        public override String ToString() => "z";
        internal override Prefix Multiply<TRight>() => Multiply<Zepto, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Zepto, TDenominator>.Result;
    }
    public sealed class Yocto : Prefix
    {
        public Yocto() : base(-24) { }
        public override String ToString() => "y";
        internal override Prefix Multiply<TRight>() => Multiply<Yocto, TRight>.Result;
        internal override Prefix Divide<TDenominator>() => Divide<Yocto, TDenominator>.Result;
    }
}
using System;
using Quantities.Prefixes;

namespace Quantities.Unit.Si.Derived
{
    public class SiAlias<TPrefixOffset, TBaseUnit> : SiDerivedUnit
        where TPrefixOffset : Prefix, new()
        where TBaseUnit : SiBaseUnit, new()
    {
        private static readonly TPrefixOffset PREFIX = Pool<TPrefixOffset>.Item;
        private static readonly TBaseUnit UNIT = Pool<TBaseUnit>.Item;
        internal override Int32 Offset => PREFIX.Exponent;
        private protected SiAlias() { }
    }
}
using System;
using Quantities.Unit.Si;
using Quantities.Prefixes;

namespace Quantities.Measures.Si.Core
{
    internal sealed class PrefixedUnit<TPrefix, TUnit> : SiUnit
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        internal override Int32 Offset => PREFIX.Exponent + UNIT.Offset;

        public override String ToString() => $"{PREFIX}{UNIT}";
    }
}
using System;
using Quantities.Unit;
using Quantities.Prefixes;

namespace Quantities.Measures
{
    public abstract class UnitSiMeasure : SiMeasure
    {
        private protected static readonly UnitPrefix UNIT_PREFIX = Pool<UnitPrefix>.Item;
    }
    public abstract class UnitSiMeasure<TPrefix, TUnit> : UnitSiMeasure
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly String REPRESENTATION = $"{PREFIX}{UNIT}";
        public TPrefix Prefix => PREFIX;
        public TUnit Unit => UNIT;
        internal override Prefix Anchor => PREFIX;
        public override Double Normalize(in Double value) => PREFIX.Scale<UnitPrefix>(in value);
        public override Double DeNormalize(in Double value) => UNIT_PREFIX.Scale<TPrefix>(in value);
        public override Double Scale<TOther>(in Double other)
        {
            return Pool<TOther>.Item.Anchor.Scale<TPrefix>(in other);
        }

        public override String ToString() => REPRESENTATION;
    }
}
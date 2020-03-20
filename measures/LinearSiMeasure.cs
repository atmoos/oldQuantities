using System;
using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class LinearSiMeasure<TPrefix, TUnit> : SiMeasure<Linear>, IUnitSiMeasure<TPrefix, TUnit>
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly String REPRESENTATION = $"{PREFIX}{UNIT}";
        public TPrefix Prefix => PREFIX;
        public TUnit Unit => UNIT;

        public override String ToString() => REPRESENTATION;
        internal override Prefix Anchor => PREFIX;
        internal override Double Normalize<TDim>(in Double value) => PREFIX.Scale<UnitPrefix, TDim>(in value);
        internal override Double DeNormalize<TDim>(in Double value) => UNIT_PREFIX.Scale<TPrefix, TDim>(in value);
        internal override Double Scale<TOther, TDim>(in Double value) => Pool<TOther>.Item.Anchor.Scale<TPrefix, TDim>(in value);
        internal override void InjectPrefix(IPrefixInjectable injectable) => injectable.Inject<TPrefix>();
    }
}
using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SiMeasure : IMeasure
    {
        private protected static readonly UnitPrefix UNIT_PREFIX = Pool<UnitPrefix>.Item;
        internal abstract Prefix Anchor { get; }
    }
    public abstract class SiMeasure<TPrefix, TDimension> : SiMeasure, IScaler<SiMeasure>, INormalize
        where TDimension : Dimension, new()
        where TPrefix : Prefix, new()
    {
        private protected static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        internal override Prefix Anchor => PREFIX;
        public Double Normalize(in Double value) => PREFIX.Scale<UnitPrefix, TDimension>(in value);
        public Double DeNormalize(in Double value) => UNIT_PREFIX.Scale<TPrefix, TDimension>(in value);
        public Double Scale<TOther>(in Double other)
            where TOther : SiMeasure, new()
        {
            return Pool<TOther>.Item.Anchor.Scale<TPrefix, TDimension>(in other);
        }
    }
}
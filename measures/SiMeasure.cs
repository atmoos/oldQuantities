using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SiMeasure
    {
        private protected static readonly UnitPrefix UNIT_PREFIX = Pool<UnitPrefix>.Item;
        internal abstract Prefix Anchor { get; }
        internal abstract Double Normalize<TDim>(in Double value) where TDim : Dimension, new();
        internal abstract Double DeNormalize<TDim>(in Double value) where TDim : Dimension, new();
        internal abstract Double Scale<TOther, TDim>(in Double value)
            where TOther : SiMeasure, new()
            where TDim : Dimension, new();
    }

    public abstract class SiMeasure<TDimension> : SiMeasure, IScaler<SiMeasure>, INormalize
        where TDimension : Dimension, new()
    {
        public Double Normalize(in Double value) => Normalize<TDimension>(in value);
        public Double DeNormalize(in Double value) => DeNormalize<TDimension>(in value);
        public Double Scale<TOther>(in Double other)
            where TOther : SiMeasure, new() => Scale<TOther, TDimension>(in other);
    }
}
using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SquareSiMeasure<TLinearMeasure> : SiMeasure<Square>
        where TLinearMeasure : SiMeasure, new()
    {
        private static readonly TLinearMeasure LINEAR_MEASURE = Pool<TLinearMeasure>.Item;
        private static readonly String REPRESENTATION = $"{LINEAR_MEASURE}²";
        internal override Prefix Anchor => LINEAR_MEASURE.Anchor;
        public TLinearMeasure LinearMeasure => LINEAR_MEASURE;

        public override String ToString() => REPRESENTATION;
        internal override Double Normalize<TDim>(in Double value) => LINEAR_MEASURE.Normalize<TDim>(in value);
        internal override Double DeNormalize<TDim>(in Double value) => LINEAR_MEASURE.DeNormalize<TDim>(in value);
        internal override Double Scale<TOther, TDim>(in Double value) => LINEAR_MEASURE.Scale<TOther, TDim>(in value);
    }
}
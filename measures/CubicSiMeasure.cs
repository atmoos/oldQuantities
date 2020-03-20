using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public abstract class CubicSiMeasure<TLinearMeasure> : SiMeasure<Cube>, ICubic<TLinearMeasure>
        where TLinearMeasure : SiMeasure, ILinear, new()
    {
        private static readonly TLinearMeasure LINEAR_MEASURE = Pool<TLinearMeasure>.Item;
        private static readonly String REPRESENTATION = $"{LINEAR_MEASURE}³";
        internal override Prefix Anchor => LINEAR_MEASURE.Anchor;
        public TLinearMeasure LinearDimension => LINEAR_MEASURE;

        public override String ToString() => REPRESENTATION;
        internal override Double Normalize<TDim>(in Double value) => LINEAR_MEASURE.Normalize<TDim>(in value);
        internal override Double DeNormalize<TDim>(in Double value) => LINEAR_MEASURE.DeNormalize<TDim>(in value);
        internal override Double Scale<TOther, TDim>(in Double value) => LINEAR_MEASURE.Scale<TOther, TDim>(in value);
        internal override void InjectPrefix(IPrefixInjectable injectable) => LINEAR_MEASURE.InjectPrefix(injectable);
    }
}
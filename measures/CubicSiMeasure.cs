using System;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public abstract class CubicSiMeasure<TLinearMeasure> : SiMeasure, ICubic<TLinearMeasure>
        where TLinearMeasure : SiMeasure, ILinear, new()
    {
        private static readonly TLinearMeasure LINEAR_MEASURE = Pool<TLinearMeasure>.Item;
        private static readonly String REPRESENTATION = $"{LINEAR_MEASURE}³";
        private static readonly Normaliser NORMALISER = Normalisers<Cube>.Get(LINEAR_MEASURE.Anchor.Exponent);
        internal override Normaliser Anchor => NORMALISER;
        public TLinearMeasure LinearDimension => LINEAR_MEASURE;

        public override String ToString() => REPRESENTATION;
    }
}
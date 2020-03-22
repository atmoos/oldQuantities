using System;
using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal abstract class CubicSiMeasure<TLinearMeasure> : SiMeasure, ICubic<TLinearMeasure>
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
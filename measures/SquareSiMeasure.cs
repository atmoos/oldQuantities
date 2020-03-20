using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public abstract class SquareSiMeasure<TLinearMeasure> : SiMeasure, ISquare<TLinearMeasure>
        where TLinearMeasure : SiMeasure, ILinear, new()
    {
        private static readonly TLinearMeasure LINEAR_MEASURE = Pool<TLinearMeasure>.Item;
        private static readonly String REPRESENTATION = $"{LINEAR_MEASURE}²";
        private static readonly Normaliser NORMALISER = Normalisers<Square>.Get(LINEAR_MEASURE.Anchor.Exponent);
        internal override Normaliser Anchor => NORMALISER;
        public TLinearMeasure LinearDimension => LINEAR_MEASURE;

        public override String ToString() => REPRESENTATION;
    }
}
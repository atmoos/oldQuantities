using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SiDivide<TNominator, TDimension, TDenominator> : SiMeasure
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{Nominator}/{Denominator}";
        private static readonly Normaliser<TDimension> NORMALISER = OperatorPool<TDimension>.Get(Nominator.Anchor.Prefix.Exponent - Denominator.Anchor.Prefix.Exponent);
        internal override Normaliser Anchor => NORMALISER;

        public override String ToString() => REPRESENTATION;
    }
}
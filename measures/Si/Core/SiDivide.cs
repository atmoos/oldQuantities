using System;
using Quantities.Unit.Si;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal abstract class SiDivide<TNominator, TDimension, TDenominator> : SiMeasure
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{Nominator}/{Denominator}";
        private static readonly Normaliser<TDimension> NORMALISER = Normalisers<TDimension>.Get(Nominator.Anchor.Exponent - Denominator.Anchor.Exponent);
        internal override Normaliser Anchor => NORMALISER;

        public override String ToString() => REPRESENTATION;
    }

    internal class SiDivide<TNominator, TDimension, TDenominator, TUnit> : SiMeasure
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly Normaliser<TDimension> NORMALISER = Normalisers<TDimension>.Get(Pool<TNominator>.Item.Anchor.Exponent - Pool<TDenominator>.Item.Anchor.Exponent);
        private static readonly String REPRESENTATION = $"{NORMALISER.Prefix}{UNIT}";
        internal override Normaliser Anchor => NORMALISER;

        public override String ToString() => REPRESENTATION;
    }
}
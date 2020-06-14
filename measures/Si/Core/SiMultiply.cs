using System;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal abstract class SiMultiply<TNominator, TDimension, TDenominator> : SiMeasure
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{Nominator}\u2009{Denominator}"; // U+2009 is thin space.
        private static readonly Normaliser<TDimension> NORMALISER = Normalisers<TDimension>.Get(Nominator.Anchor.Exponent + Denominator.Anchor.Exponent);
        internal override Normaliser Anchor => NORMALISER;

        public override String ToString() => REPRESENTATION;
        internal static void Inject(IPrefixInjectable injectable) => NORMALISER.InjectPrefix(injectable);
    }
}
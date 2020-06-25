using System;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal sealed class Div<TNominator, TDenominator> : ISiMeasure
        where TNominator : ISiMeasure, new()
        where TDenominator : ISiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly Normaliser NORMALISER = Normalisers.Get(Nominator.Normaliser.Exponent - Denominator.Normaliser.Exponent);
        Normaliser ISiMeasure.Normaliser => NORMALISER;

        public override String ToString() => $"{Nominator}/{Denominator}";
    }
}
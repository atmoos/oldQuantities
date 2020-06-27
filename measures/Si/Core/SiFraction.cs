using System;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal sealed class SiFraction<TNominator, TDenominator> : ISiMeasure
        where TNominator : ISiMeasure, new()
        where TDenominator : ISiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly Normaliser NORMALISER = Normalisers.Get(Nominator.Normaliser.Exponent - Denominator.Normaliser.Exponent);
        public Normaliser Normaliser => NORMALISER;

        public override String ToString() => $"{Nominator}/{Denominator}";
        internal static void Inject(IPrefixInjectable injectable) => NORMALISER.InjectPrefix(injectable);
    }
}
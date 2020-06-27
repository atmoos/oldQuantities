using System;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal sealed class SiProduct<TLeft, TRight> : ISiMeasure
        where TLeft : ISiMeasure, new()
        where TRight : ISiMeasure, new()
    {
        private static readonly TLeft Left = Pool<TLeft>.Item;
        private static readonly TRight Right = Pool<TRight>.Item;
        private static readonly Normaliser NORMALISER = Normalisers.Get(Left.Normaliser.Exponent + Right.Normaliser.Exponent);
        public Normaliser Normaliser => NORMALISER;

        public override String ToString() => $"{Left}\u2009{Right}"; // U+2009 is thin space.
        internal static void Inject(IPrefixInjectable injectable) => NORMALISER.InjectPrefix(injectable);
    }
}
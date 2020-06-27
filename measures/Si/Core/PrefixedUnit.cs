using System;
using Quantities.Unit.Si;
using Quantities.Prefixes;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal sealed class Si<TPrefix, TUnit> : ISiMeasure
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly Normaliser NORMALISER = Normalisers.Get(PREFIX.Exponent + UNIT.Offset);
        public Normaliser Normaliser => NORMALISER;

        public override String ToString() => $"{PREFIX}{UNIT}";
    }
}
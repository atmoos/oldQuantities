using System;
using Quantities.Unit.Si;
using Quantities.Prefixes;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal abstract class LinearSiMeasure<TPrefix, TUnit> : SiMeasure, IUnitSiMeasure<TPrefix, TUnit>
        where TPrefix : Prefix, new()
        where TUnit : ISiUnit, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly Normaliser<Linear> NORMALISER = Normalisers<Linear>.Get(PREFIX.Exponent);
        private static readonly String REPRESENTATION = $"{PREFIX}{UNIT}";
        public TPrefix Prefix => PREFIX;
        public TUnit Unit => UNIT;

        public override String ToString() => REPRESENTATION;
        internal override Normaliser Anchor => NORMALISER;
    }
}
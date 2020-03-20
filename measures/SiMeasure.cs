using System;
using Quantities.Prefixes;

namespace Quantities.Measures
{
    public abstract class SiMeasure : INormalise
    {
        internal abstract Normaliser Anchor { get; }
        public Double Renormalise(in Double value) => Anchor.Renormalise(in value);
        public Double Normalise(in Double value) => Anchor.Normalise(in value);
        public Double Scale<TOther>(in Double other) where TOther : SiMeasure, new() => Anchor.Scale(Pool<TOther>.Item.Anchor, in other);
    }
}
using System;
using Quantities.Prefixes;

namespace Quantities.Measures
{
    public abstract class SiMeasure : IMeasure, IScaler<SiMeasure>, INormalize
    {
        internal abstract Prefix Anchor { get; }
        public abstract Double Normalize(in Double value);
        public abstract Double DeNormalize(in Double value);
        public abstract Double Scale<TOther>(in Double other) where TOther : SiMeasure, new();
    }
}
using System;
using Quantities.Prefixes;

namespace Quantities.Measures
{
    public interface ISiMeasure : INormalize
    {
        Double Scale<TOther>(in Double other) where TOther : SiMeasure, new();
    }
    public abstract class SiMeasure : ISiMeasure
    {
        private protected static readonly UnitPrefix UNIT_PREFIX = Pool<UnitPrefix>.Item;
        internal abstract Normaliser Anchor { get; }
        public Double DeNormalize(in Double value) => Anchor.DeNormalize(in value);
        public Double Normalize(in Double value) => Anchor.Normalize(in value);
        public Double Scale<TOther>(in Double other) where TOther : SiMeasure, new() => Anchor.Scale(Pool<TOther>.Item.Anchor, in other);
    }
}
using System;
using Quantities.Unit.Si;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Core
{
    public abstract class SiMeasure : SiUnit, INormalise
    {
        internal abstract Normaliser Anchor { get; }
        public Double Renormalise(in Double value) => Anchor.Renormalise(in value);
        public Double Normalise(in Double value) => Anchor.Normalise(in value);
        public Double Scale<TOther>(in Double other) where TOther : SiMeasure, new() => Anchor.Scale(Pool<TOther>.Item.Anchor, in other);
    }
    internal abstract class SiMeasure<TDim, TSiUnit> : SiMeasure
        where TDim : Dimension, new()
        where TSiUnit : SiUnit, new()
    {
        private static readonly TSiUnit UNIT = Pool<TSiUnit>.Item;
        private static readonly Normaliser<TDim> NORMALIZER = Normalisers<TDim>.Get(UNIT.Offset);
        private static readonly String REPRESENTATION = $"{UNIT}{Pool<TDim>.Item}";
        internal override Int32 Offset => UNIT.Offset;
        internal override Normaliser Anchor => NORMALIZER;

        public override String ToString() => REPRESENTATION;
        internal static void Inject(IPrefixInjectable injectable) => NORMALIZER.InjectPrefix(injectable);
    }
}
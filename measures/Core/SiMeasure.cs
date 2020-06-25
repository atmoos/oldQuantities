using System;
using Quantities.Unit.Si;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Core
{
    public abstract class SiMeasure : SiUnit, INormalise
    {
        internal abstract Normaliser Anchor { get; }
        public abstract Double Renormalise(in Double value);
        public abstract Double Normalise(in Double value);
        internal abstract Double Scale(SiMeasure measure, in Double other);
    }
    internal class SiMeasure<TDim, TSiUnit> : SiMeasure
        where TDim : Dimension, new()
        where TSiUnit : SiUnit, new()
    {
        private static readonly TSiUnit UNIT = Pool<TSiUnit>.Item;
        private static readonly Normaliser NORMALIZER = Normalisers.Get(UNIT.Offset);
        private static readonly String REPRESENTATION = $"{UNIT}{Pool<TDim>.Item}";
        internal override Int32 Offset => UNIT.Offset;
        internal override Normaliser Anchor => NORMALIZER;

        public override String ToString() => REPRESENTATION;
        internal static void Inject(IPrefixInjectable injectable) => NORMALIZER.InjectPrefix(injectable);
        public override Double Renormalise(in Double value)
        {
            return NORMALIZER.Renormalise<TDim>(in value);
        }
        public override Double Normalise(in Double value)
        {
            return NORMALIZER.Normalise<TDim>(in value);
        }
        internal override Double Scale(SiMeasure measure, in Double other)
        {
            return measure.Anchor.Scale<TDim>(NORMALIZER, in other);
        }
    }
}
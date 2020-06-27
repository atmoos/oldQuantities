using System;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Core
{
    internal interface ISiMeasure
    {
        Normaliser Normaliser { get; }
    }
    public abstract class SiMeasure : INormalise, ISiMeasure
    {
        Normaliser ISiMeasure.Normaliser => Normaliser;
        private protected abstract Normaliser Normaliser { get; }
        public abstract Double Renormalise(in Double value);
        public abstract Double Normalise(in Double value);
        internal abstract Double Scale<TSiMeasure>(TSiMeasure measure, in Double other) where TSiMeasure : ISiMeasure;
    }
    internal class SiMeasure<TDim, TMeasure> : SiMeasure
        where TDim : Dimension, new()
        where TMeasure : ISiMeasure, new()
    {
        private static readonly TMeasure MEASURE = Pool<TMeasure>.Item;
        private static readonly String REPRESENTATION = $"{MEASURE}{Pool<TDim>.Item}";
        private protected override Normaliser Normaliser => MEASURE.Normaliser;

        public override String ToString() => REPRESENTATION;
        public override Double Renormalise(in Double value)
        {
            return MEASURE.Normaliser.Renormalise<TDim>(in value);
        }
        public override Double Normalise(in Double value)
        {
            return MEASURE.Normaliser.Normalise<TDim>(in value);
        }
        internal override Double Scale<TSiMeasure>(TSiMeasure measure, in Double other)
        {
            return measure.Normaliser.Scale<TDim>(MEASURE.Normaliser, in other);
        }
    }
}
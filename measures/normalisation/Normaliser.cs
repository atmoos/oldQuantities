using System;
using Quantities.Prefixes;
using Quantities.Measures.Core;

namespace Quantities.Measures.Normalisation
{
    internal abstract class Normaliser
    {
        private protected static NoOp NO_OP = new NoOp();
        public Int32 Exponent => Prefix.Exponent;
        public abstract Prefix Prefix { get; }
        private protected Normaliser() { }
        public abstract Double Normalise<TDimension>(in Double value) where TDimension : Dimension, new();
        public abstract Double Renormalise<TDimension>(in Double value) where TDimension : Dimension, new();
        public abstract Double Scale<TDimension>(Normaliser normalizer, in Double other) where TDimension : Dimension, new();
        protected abstract Double Scale<TOtherDimension, TOtherPrefix>(in Double other)
            where TOtherDimension : Dimension, new()
            where TOtherPrefix : Prefix, new();
        internal abstract Normaliser With(Operator normalise, Operator renormalise);
        internal abstract void InjectPrefix(IPrefixInjectable injectable);

        public static Normaliser Create<TPrefix>()
            where TPrefix : Prefix, new()
        {
            return Pool<NormaliserImpl<TPrefix>>.Item;
        }

        private sealed class NormaliserImpl<TPrefix> : Normaliser
            where TPrefix : Prefix, new()
        {
            private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
            private readonly Operator _normalise;
            private readonly Operator _renormalise;
            public override Prefix Prefix => PREFIX;
            public NormaliserImpl()
            {
                _normalise = NO_OP;
                _renormalise = NO_OP;
            }
            public NormaliserImpl(Operator normalise, Operator renormalise)
            {
                _normalise = normalise;
                _renormalise = renormalise;
            }
            protected override Double Scale<TOtherDimension, TOtherPrefix>(in Double other) => Scale<TPrefix, TOtherPrefix, TOtherDimension>.Lift(other);
            public override Double Scale<TOtherDimension>(Normaliser normalizer, in Double other) => normalizer.Scale<TOtherDimension, TPrefix>(in other);
            public override Double Normalise<TDimension>(in Double value) => Scale<TPrefix, UnitPrefix, TDimension>.Lift(_normalise.Execute(in value));
            public override Double Renormalise<TDimension>(in Double value) => Scale<UnitPrefix, TPrefix, TDimension>.Lift(_renormalise.Execute(in value));
            internal override Normaliser With(Operator normalise, Operator renormalise)
            {
                return new NormaliserImpl<TPrefix>(normalise, renormalise);
            }
            internal override void InjectPrefix(IPrefixInjectable injectable) => injectable.Inject<TPrefix>();
        }
    }
}
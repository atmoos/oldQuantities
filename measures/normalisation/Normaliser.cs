using System;
using Quantities.Prefixes;

namespace Quantities.Measures.Normalisation
{
    internal abstract class Normaliser : INormalise
    {
        private protected static NoOp NO_OP = new NoOp();
        public abstract Int32 Exponent { get; }
        private protected Normaliser() { }
        public abstract Double Normalise(in Double value);
        public abstract Double Renormalise(in Double value);
        public abstract Double Scale(Normaliser normalizer, in Double other);
        internal abstract Double Scale<TOther>(in Double other) where TOther : Prefix, new();
    }
    internal abstract class Normaliser<TDimension> : Normaliser, INormalise
        where TDimension : Dimension, new()
    {
        internal abstract Normaliser<TDimension> With(Operator normalise, Operator renormalise);
        public static Normaliser<TDimension> Create<TPrefix>()
            where TPrefix : Prefix, new()
        {
            var noOp = new NoOp();
            return new NormaliserImpl<TPrefix>(noOp, noOp);
        }
        private sealed class NormaliserImpl<TPrefix> : Normaliser<TDimension>
            where TPrefix : Prefix, new()
        {
            private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
            private readonly Operator _normalise;
            private readonly Operator _renormalise;
            public override Int32 Exponent => PREFIX.Exponent;
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
            internal override Double Scale<TOther>(in Double other) => Scale<TPrefix, TOther, TDimension>.Lift(other);
            public override Double Scale(Normaliser normalizer, in Double other) => normalizer.Scale<TPrefix>(in other);
            public override Double Normalise(in Double value) => Scale<TPrefix, UnitPrefix, TDimension>.Lift(_normalise.Execute(in value));
            public override Double Renormalise(in Double value) => Scale<UnitPrefix, TPrefix, TDimension>.Lift(_renormalise.Execute(in value));
            internal override Normaliser<TDimension> With(Operator normalise, Operator renormalise)
            {
                return new NormaliserImpl<TPrefix>(normalise, renormalise);
            }
        }
    }
}
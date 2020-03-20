using System;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Prefixes
{
    internal static class Scale<TLeft, TRight, TDimension>
        where TLeft : Prefix, new()
        where TRight : Prefix, new()
        where TDimension : Dimension, new()
    {
        private static readonly Double _scaleFactor = Pool<TDimension>.Item.Factor(Pool<TLeft>.Item.Exponent - Pool<TRight>.Item.Exponent);
        public static Double Lift(in Double value) => _scaleFactor * value;
    }

    public abstract class Operator
    {
        public abstract Double Execute(in Double value);
    }

    public sealed class NoOp : Operator
    {
        public override Double Execute(in Double value) => value;
    }
    public sealed class Multiply : Operator
    {
        private readonly Double _factor;
        internal Multiply(in Double factor) => _factor = factor;
        public override Double Execute(in Double value) => value * _factor;
    }
    internal abstract class Normaliser : INormalize
    {
        private protected static NoOp NO_OP = new NoOp();
        public abstract Prefix Prefix { get; }
        private protected Normaliser() { }
        public abstract Double Normalize(in Double value);
        public abstract Double DeNormalize(in Double value);
        public abstract Double Scale(Normaliser normalizer, in Double other);
        internal abstract Double Scale<TOther>(in Double other) where TOther : Prefix, new();
    }
    internal abstract class Normaliser<TDimension> : Normaliser, INormalize
        where TDimension : Dimension, new()
    {
        internal abstract void Inject(IPrefixInjectable injectable);
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
            internal override Double Scale<TOther>(in Double other) => Scale<TPrefix, TOther, TDimension>.Lift(other);
            public override Double Scale(Normaliser normalizer, in Double other) => normalizer.Scale<TPrefix>(in other);
            public override Double Normalize(in Double value) => Scale<TPrefix, UnitPrefix, TDimension>.Lift(_normalise.Execute(in value));
            public override Double DeNormalize(in Double value) => Scale<UnitPrefix, TPrefix, TDimension>.Lift(_renormalise.Execute(in value));
            internal override void Inject(IPrefixInjectable injectable) => injectable.Inject<TPrefix>();
            internal override Normaliser<TDimension> With(Operator normalise, Operator renormalise)
            {
                return new NormaliserImpl<TPrefix>(normalise, renormalise);
            }
        }

    }
    public sealed class Divide : Operator
    {
        private readonly Double _divisor;
        internal Divide(in Double divisor) => _divisor = divisor;
        public override Double Execute(in Double value) => value / _divisor;
    }

    internal static class Multiply<TLeft, TRight>
        where TLeft : Prefix, new()
        where TRight : Prefix, new()
    {
        public static Prefix Result { get; }
        static Multiply()
        {
            var left = Pool<TLeft>.Item;
            var right = Pool<TRight>.Item;
            Result = PrefixPool.Get(left.Exponent + right.Exponent);
        }
    }
    internal static class Divide<TNominator, TDenominator>
        where TNominator : Prefix, new()
        where TDenominator : Prefix, new()
    {
        public static Prefix Result { get; }
        static Divide()
        {
            var nominator = Pool<TNominator>.Item;
            var denominator = Pool<TDenominator>.Item;
            Result = PrefixPool.Get(nominator.Exponent - denominator.Exponent);
        }
    }
}
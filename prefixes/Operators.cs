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
    internal class Normaliser
    {
        private protected static readonly UnitPrefix UNIT_PREFIX = Pool<UnitPrefix>.Item;
        private protected Normaliser() { }
    }
    internal abstract class Normaliser<TDimension> : Normaliser, INormalize
        where TDimension : Dimension, new()
    {
        private readonly Operator _normalise;
        private readonly Operator _renormalise;
        public abstract Prefix Prefix { get; }
        private Normaliser(Operator normalise, Operator renormalise)
        {
            _normalise = normalise;
            _renormalise = renormalise;
        }
        public Double Normalize(in Double value) => Prefix.Scale<UnitPrefix, TDimension>(_normalise.Execute(in value));
        public abstract Double DeNormalize(in Double value);
        public abstract Double Scale<TOther>(in Double other) where TOther : Prefix, new();
        // ToDo: delete!
        public abstract Double Scale<TOther, TDim>(in Double other) where TOther : Prefix, new() where TDim : Dimension, new();
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
            public override Prefix Prefix => PREFIX;
            public NormaliserImpl(Operator normalise, Operator renormalise) : base(normalise, renormalise)
            {
            }

            public override Double Scale<TOther>(in Double other) => Scale<TPrefix, TOther, TDimension>.Lift(other);
            public override Double Scale<TOther, TDim>(in Double other) => Scale<TPrefix, TOther, TDim>.Lift(other);
            public override Double DeNormalize(in Double value) => UNIT_PREFIX.Scale<TPrefix, TDimension>(_renormalise.Execute(in value));
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
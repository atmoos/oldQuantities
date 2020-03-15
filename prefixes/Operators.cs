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
    public sealed class Operation
    {
        public Operator Op { get; }
        public Prefix Prefix { get; }

        public Operation(Operator op, Prefix prefix) => (Op, Prefix) = (op, prefix);
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
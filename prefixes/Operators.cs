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
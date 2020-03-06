using System;

namespace Quantities.Prefixes
{
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
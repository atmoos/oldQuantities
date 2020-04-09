using System;
using Xunit;
using Quantities.Dimensions;

namespace Quantities.Test
{
    internal static class Metrics
    {
        public static Int32 SiPrecision => 15;
        public static Int32 ImperialPrecision => 9;

        // ToDo: Figure out how to fix tests that require this catastrophic level of precision.
        public static Int32 CatastrophicPrecision => 4;

        public static void Matches<TDimension>(this IQuantity<TDimension> actual, IQuantity<TDimension> expected)
            where TDimension : class, IDimension
        {
            actual.Matches(expected, SiPrecision);
        }
        public static void Matches<TDimension>(this IQuantity<TDimension> actual, IQuantity<TDimension> expected, Int32 precision)
            where TDimension : class, IDimension
        {
            Assert.Same(expected.Dimension, actual.Dimension);
            Assert.Equal(expected.Value, actual.Value, precision);
        }

        public static void MatchesOther<TDimension>(this IQuantity<TDimension> actual, IQuantity<TDimension> expected)
            where TDimension : class, IDimension
        {
            actual.Matches(expected, ImperialPrecision);
        }
    }
}
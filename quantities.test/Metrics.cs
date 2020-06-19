using System;
using System.Globalization;
using Xunit;
using Quantities.Dimensions;

namespace Quantities.Test
{
    internal static class Metrics
    {
        public static Int32 SiPrecision => 15;
        public static Int32 ImperialPrecision => 14;
        public static void Matches<TDimension>(this IQuantity<TDimension> actual, IQuantity<TDimension> expected)
            where TDimension : class, IDimension
        {
            actual.Matches(expected, SiPrecision);
        }
        public static void Matches<TDimension>(this IQuantity<TDimension> actual, IQuantity<TDimension> expected, Int32 precision)
            where TDimension : class, IDimension
        {
            Assert.NotNull(actual);
            Assert.Same(expected.Dimension, actual.Dimension);
            Assert.Equal(expected.Value, actual.Value, precision);
        }

        public static void MatchesOther<TDimension>(this IQuantity<TDimension> actual, IQuantity<TDimension> expected)
            where TDimension : class, IDimension
        {
            actual.Matches(expected, ImperialPrecision);
        }
        public static void FormattingMatches(Func<Double, IFormattable> formatterFactory, String unit)
        {
            const String format = "f8";
            const Double value = Math.PI;
            var formattable = formatterFactory(value);
            var formatProvider = CultureInfo.CurrentCulture;
            Assert.Equal($"{value.ToString(format, formatProvider)} {unit}", formattable.ToString(format, formatProvider));
        }
    }
}
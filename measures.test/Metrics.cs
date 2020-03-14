using System;
using Xunit;
using Quantities.Dimensions;

namespace Quantities.Measures.Test
{
    internal static class Metrics
    {
        public static Int32 NonSiPrecision => 15;

        public static void AssertDimensionsAreSame<TDimension>(Quantity<TDimension> expected, Quantity<TDimension> actual)
            where TDimension : class, IDimension
        {
            Assert.Same(expected.Dimension, actual.Dimension);
        }
    }
}
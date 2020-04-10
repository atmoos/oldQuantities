using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial.Length;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class AreaTest
    {
        private const Double SQUARE_MILE_IN_SQUARE_KILOMETRES = (Double)(1.609344m * 1.609344m);
        [Fact]
        public void AddSquareMetres()
        {
            var left = Area.Square<Metre>(20);
            var right = Area.Square<Metre>(10);
            var result = left + right;
            Assert.Equal(30d, result.Value, SiPrecision);
        }
        [Fact]
        public void AddSquareHectoMetresToSquareKiloMetres()
        {
            var left = Area.Square<Kilo, Metre>(2);
            var right = Area.Square<Hecto, Metre>(50);
            var result = left + right;
            Assert.Equal(2.5d, result.Value, SiPrecision);
        }
        [Fact]
        public void SquareMetresToSquareKilometers()
        {
            var squareMetres = Area.Square<Metre>(1000);
            var squarekilometres = squareMetres.ToSquare<Kilo, Metre>();
            Assert.Equal(1e-3d, squarekilometres.Value, SiPrecision);
        }
        [Fact]
        public void SquareMilesToSquareKilometers()
        {
            var squareMiles = Area.SquareImperial<Mile>(2);
            var expected = Area.Square<Kilo, Metre>(2 * SQUARE_MILE_IN_SQUARE_KILOMETRES);

            var actual = squareMiles.ToSquare<Kilo, Metre>();

            actual.Matches(expected);
        }

        [Fact]
        public void SquareYardToSquareFeet()
        {
            var squareYards = Area.SquareImperial<Yard>(3);
            var expected = Area.SquareImperial<Foot>(27);

            var actual = squareYards.ToSquareImperial<Foot>();

            actual.Matches(expected, ImperialPrecision);
        }
    }
}
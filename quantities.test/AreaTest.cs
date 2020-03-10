using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.SiDerived;
using Quantities.Unit.Imperial;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class AreaTest
    {
        [Fact]
        public void AddSquareMetres()
        {
            var left = Area.Square<Metre>(20);
            var right = Area.Square<Metre>(10);
            var result = left + right;
            Assert.Equal(30d, result.Value, SiPrecision);
        }

        [Fact]
        public void SquareMetresToSquareKilometers()
        {
            var squareMetres = Area.Square<Metre>(1000);
            var squarekilometres = squareMetres.ToSquare<Kilo, Metre>();
            Assert.Equal(1e-3d, squarekilometres.Value, SiPrecision);
        }
    }
}
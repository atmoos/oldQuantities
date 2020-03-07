using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Prefixes;

namespace Quantities.Test
{
    public sealed class LengthTest
    {
        private const Int32 PRECISION = 12;

        [Fact]
        public void MetreToKilometre()
        {
            var metres = Length.Create<Metre>(1000);
            var kilometres = metres.To<Kilo, Metre>();
            Assert.Equal(1d, kilometres.Value, PRECISION);
        }

        [Fact]
        public void MetreToMillimetre()
        {
            var metres = Length.Create<Metre>(1);
            var millimetres = metres.To<Milli, Metre>();
            Assert.Equal(1000d, millimetres.Value, PRECISION);
        }

        [Fact]
        public void MillimetreToKilometre()
        {
            var millimetres = Length.Create<Milli, Metre>(2e6);
            var kilometres = millimetres.To<Kilo, Metre>();
            Assert.Equal(2, kilometres.Value, PRECISION);
        }
    }
}

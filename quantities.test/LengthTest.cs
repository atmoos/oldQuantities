using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial;
using Quantities.Prefixes;

namespace Quantities.Test
{
    public sealed class LengthTest
    {
        private const Int32 SI_PRECISION = 15;
        private const Int32 IMPERIAL_PRECISION = 9;

        [Fact]
        public void MetreToKilometre()
        {
            var metres = Length.Create<Metre>(1000);
            var kilometres = metres.To<Kilo, Metre>();
            Assert.Equal(1d, kilometres.Value, SI_PRECISION);
        }

        [Fact]
        public void MetreToMillimetre()
        {
            var metres = Length.Create<Metre>(1);
            var millimetres = metres.To<Milli, Metre>();
            Assert.Equal(1000d, millimetres.Value, SI_PRECISION);
        }

        [Fact]
        public void MillimetreToKilometre()
        {
            var millimetres = Length.Create<Milli, Metre>(2e6);
            var kilometres = millimetres.To<Kilo, Metre>();
            Assert.Equal(2, kilometres.Value, SI_PRECISION);
        }

        [Fact]
        public void MileToKilometre()
        {
            var miles = Length.CreateNonSi<Mile>(1);
            var kilometres = miles.To<Kilo, Metre>();
            Assert.Equal(1609.334, kilometres.Value, SI_PRECISION);
        }

        [Fact]
        public void KilometreToMile()
        {
            var kilometres = Length.Create<Kilo, Metre>(1.609334);
            var miles = kilometres.ToNonSi<Mile>();
            Assert.Equal(1, miles.Value, SI_PRECISION);
        }
        [Fact]
        public void FootToMile()
        {
            var feet = Length.CreateNonSi<Foot>(5279.967192);
            var miles = feet.ToNonSi<Mile>();
            Assert.Equal(1, miles.Value, IMPERIAL_PRECISION);
        }
    }
}

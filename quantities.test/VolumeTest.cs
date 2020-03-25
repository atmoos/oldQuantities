using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.SiDerived;
using Quantities.Unit.Imperial.Volume;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class VolumeTest
    {
        [Fact]
        public void AddCubicMetres()
        {
            var left = Volume.Cubic<Metre>(20);
            var right = Volume.Cubic<Metre>(10);
            var result = left + right;
            Assert.Equal(30d, result.Value, SiPrecision);
        }

        [Fact]
        public void FromSiToLitre()
        {
            var si = Volume.Cubic<Metre>(1);
            var expected = Volume.Si<Litre>(1000);

            var actual = si.ToSi<Litre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromLitreToSi()
        {
            var litre = Volume.Si<Litre>(600);
            var expected = Volume.Cubic<Metre>(0.6);

            var actual = litre.ToCubic<Metre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromCubicDeciMetreToLitre()
        {
            var si = Volume.Cubic<Deci, Metre>(1);
            var expected = Volume.Si<Litre>(1);

            var actual = si.ToSi<Litre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromGallonToLitre()
        {
            var si = Volume.Create<Gallon>(1);
            var expected = Volume.Si<Litre>(4.54609);

            var actual = si.ToSi<Litre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromLitreToPint()
        {
            var si = Volume.Si<Litre>(0.56826125);
            var expected = Volume.Create<Pint>(1);

            var actual = si.ToNonSi<Pint>();
            Assert.Equal(expected, actual);
        }
    }
}
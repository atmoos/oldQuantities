using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.SiDerived;
using Quantities.Unit.Imperial.Length;
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
        public void FromSiToHectoLitre()
        {
            var si = Volume.Cubic<Metre>(1);
            var expected = Volume.Si<Hecto, Litre>(10);

            var actual = si.ToSi<Hecto, Litre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromMilliLitreToCubicCentimetre()
        {
            var litre = Volume.Si<Milli, Litre>(1);
            var expected = Volume.Cubic<Centi, Metre>(1);

            var actual = litre.ToCubic<Centi, Metre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromCubicMillimetreToMicroLitre()
        {
            var si = Volume.Cubic<Milli, Metre>(5);
            var expected = Volume.Si<Micro, Litre>(5);

            var actual = si.ToSi<Micro, Litre>();
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
            var si = Volume.Imperial<Gallon>(1);
            var expected = Volume.Si<Litre>(4.54609);

            var actual = si.ToSi<Litre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromLitreToPint()
        {
            var si = Volume.Si<Litre>(0.56826125);
            var expected = Volume.Imperial<Pint>(1);

            var actual = si.ToImperial<Pint>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromCubicFootToLitre()
        {
            var imperial = Volume.CubicImperial<Foot>(1);
            var expected = Volume.Si<Litre>(28.316846592);

            var actual = imperial.ToSi<Litre>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FromMillilitreToImperialFluidOunce()
        {
            var si = Volume.Si<Milli, Litre>(2 * 28.4130625);
            var expected = Volume.Imperial<FluidOunce>(2);

            var actual = si.ToImperial<FluidOunce>();
            Assert.Equal(expected, actual);
        }
    }
}
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial.Length;
using Quantities.Unit.SiDerived;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class LengthTest
    {
        [Fact]
        public void MetreToKilometre()
        {
            var metres = Length.Si<Metre>(1000);
            var kilometres = metres.To<Kilo, Metre>();
            Assert.Equal(1d, kilometres.Value, SiPrecision);
        }

        [Fact]
        public void MetreToMillimetre()
        {
            var metres = Length.Si<Metre>(1);
            var millimetres = metres.To<Milli, Metre>();
            Assert.Equal(1000d, millimetres.Value, SiPrecision);
        }

        [Fact]
        public void MillimetreToKilometre()
        {
            var millimetres = Length.Si<Milli, Metre>(2e6);
            var kilometres = millimetres.To<Kilo, Metre>();
            Assert.Equal(2, kilometres.Value, SiPrecision);
        }

        [Fact]
        public void MileToKilometre()
        {
            var miles = Length.Imperial<Mile>(1);
            var kilometres = miles.To<Kilo, Metre>();
            Assert.Equal(1.609334, kilometres.Value, SiPrecision);
        }

        [Fact]
        public void KilometreToMile()
        {
            var kilometres = Length.Si<Kilo, Metre>(1.609334);
            var miles = kilometres.ToImperial<Mile>();
            Assert.Equal(1, miles.Value, SiPrecision);
        }
        [Fact]
        public void FootToMile()
        {
            var feet = Length.Imperial<Foot>(5279.967192);
            var miles = feet.ToImperial<Mile>();
            Assert.Equal(1, miles.Value, ImperialPrecision);
        }

        [Fact]
        public void AddMetresToKiloMetres()
        {
            var kilometres = Length.Si<Kilo, Metre>(10);
            var metres = Length.Si<Metre>(20);
            var result = kilometres + metres;
            Assert.Equal(10.02, result.Value, SiPrecision);
        }
        [Fact]
        public void AddKilometresToMiles()
        {
            Length kilometres = Length.Si<Kilo, Metre>(1);
            var miles = Length.Imperial<Mile>(1);
            var result = miles + kilometres;
            Assert.Equal(1.62137505328, result.Value, ImperialPrecision);
        }
        [Fact]
        public void AddMilesToKilometres()
        {
            var kilometres = Length.Si<Kilo, Metre>(1);
            var miles = Length.Imperial<Mile>(1);
            var result = kilometres + miles;
            Assert.Equal(2.609334, result.Value, SiPrecision);
        }
        [Fact]
        public void SubtractKilometresFromMetres()
        {
            var metres = Length.Si<Metre>(2000);
            var kilometres = Length.Si<Kilo, Metre>(0.5);
            var result = metres - kilometres;
            Assert.Equal(1500, result.Value, SiPrecision);
        }

        [Fact]
        public void SubtractMilesFromKilometres()
        {
            var kilometres = Length.Si<Kilo, Metre>(2.609334);
            var miles = Length.Imperial<Mile>(1);
            var result = kilometres - miles;
            Assert.Equal(1, result.Value, SiPrecision);
        }
        [Fact]
        public void SiLengthBySiTimeIsVelocity()
        {
            var distance = Length.Si<Milli, Metre>(100);
            var duration = Time.Seconds(20);
            var expected = Velocity.Si<Milli, Metre>(5).PerSecond();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void SiLengthByOtherTimeIsVelocity()
        {
            var distance = Length.Si<Kilo, Metre>(120);
            var duration = Time.SiDerived<Hour>(10);
            var expected = Velocity.Si<Kilo, Metre>(12).Per<Hour>();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void OtherLengthByTimeIsVelocity()
        {
            var distance = Length.Imperial<Mile>(70);
            var duration = Time.SiDerived<Hour>(2);
            var expected = Velocity.Imperial<Mile>(35).Per<Hour>();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void OtherLengthBySiTimeIsVelocity()
        {
            var distance = Length.Imperial<Mile>(4);
            var duration = Time.Seconds(2);
            var expected = Velocity.Imperial<Mile>(2).PerSecond();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void SiLengthBySiLengthIsSiArea()
        {
            var length = Length.Si<Kilo, Metre>(2);
            var width = Length.Si<Hecto, Metre>(1);
            var expected = Area.Square<Kilo, Metre>(0.2);

            var actual = length * width;

            actual.Matches(expected);
        }

        [Fact]
        public void OtherLengthByOtherLengthIsOtherArea()
        {
            var length = Length.Imperial<Mile>(2);
            var width = Length.Imperial<Yard>(1760 / 2);
            var expected = Area.SquareImperial<Mile>(1);

            var actual = length * width;

            actual.Matches(expected, CatastrophicPrecision);
        }
    }
}

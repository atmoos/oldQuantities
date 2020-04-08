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
            var metres = Length.Create<Metre>(1000);
            var kilometres = metres.To<Kilo, Metre>();
            Assert.Equal(1d, kilometres.Value, SiPrecision);
        }

        [Fact]
        public void MetreToMillimetre()
        {
            var metres = Length.Create<Metre>(1);
            var millimetres = metres.To<Milli, Metre>();
            Assert.Equal(1000d, millimetres.Value, SiPrecision);
        }

        [Fact]
        public void MillimetreToKilometre()
        {
            var millimetres = Length.Create<Milli, Metre>(2e6);
            var kilometres = millimetres.To<Kilo, Metre>();
            Assert.Equal(2, kilometres.Value, SiPrecision);
        }

        [Fact]
        public void MileToKilometre()
        {
            var miles = Length.CreateNonSi<Mile>(1);
            var kilometres = miles.To<Kilo, Metre>();
            Assert.Equal(1.609334, kilometres.Value, SiPrecision);
        }

        [Fact]
        public void KilometreToMile()
        {
            var kilometres = Length.Create<Kilo, Metre>(1.609334);
            var miles = kilometres.ToNonSi<Mile>();
            Assert.Equal(1, miles.Value, SiPrecision);
        }
        [Fact]
        public void FootToMile()
        {
            var feet = Length.CreateNonSi<Foot>(5279.967192);
            var miles = feet.ToNonSi<Mile>();
            Assert.Equal(1, miles.Value, ImperialPrecision);
        }

        [Fact]
        public void AddMetresToKiloMetres()
        {
            var kilometres = Length.Create<Kilo, Metre>(10);
            var metres = Length.Create<Metre>(20);
            var result = kilometres + metres;
            Assert.Equal(10.02, result.Value, SiPrecision);
        }
        [Fact]
        public void AddKilometresToMiles()
        {
            Length kilometres = Length.Create<Kilo, Metre>(1);
            var miles = Length.CreateNonSi<Mile>(1);
            var result = miles + kilometres;
            Assert.Equal(1.62137505328, result.Value, ImperialPrecision);
        }
        [Fact]
        public void AddMilesToKilometres()
        {
            var kilometres = Length.Create<Kilo, Metre>(1);
            var miles = Length.CreateNonSi<Mile>(1);
            var result = kilometres + miles;
            Assert.Equal(2.609334, result.Value, SiPrecision);
        }
        [Fact]
        public void SubtractKilometresFromMetres()
        {
            var metres = Length.Create<Metre>(2000);
            var kilometres = Length.Create<Kilo, Metre>(0.5);
            var result = metres - kilometres;
            Assert.Equal(1500, result.Value, SiPrecision);
        }

        [Fact]
        public void SubtractMilesFromKilometres()
        {
            var kilometres = Length.Create<Kilo, Metre>(2.609334);
            var miles = Length.CreateNonSi<Mile>(1);
            var result = kilometres - miles;
            Assert.Equal(1, result.Value, SiPrecision);
        }
        [Fact]
        public void SiLengthBySiTimeIsVelocity()
        {
            var distance = Length.Create<Milli, Metre>(100);
            var duration = Time.Seconds(20);
            var expected = Velocity.Si<Milli, Metre>(5).PerSecond();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void SiLengthByOtherTimeIsVelocity()
        {
            var distance = Length.Create<Kilo, Metre>(120);
            var duration = Time.CreateSiDerived<Hour>(10);
            var expected = Velocity.Si<Kilo, Metre>(12).Per<Hour>();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void OtherLengthByTimeIsVelocity()
        {
            var distance = Length.CreateNonSi<Mile>(70);
            var duration = Time.CreateSiDerived<Hour>(2);
            var expected = Velocity.Imperial<Mile>(35).Per<Hour>();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void OtherLengthBySiTimeIsVelocity()
        {
            var distance = Length.CreateNonSi<Mile>(4);
            var duration = Time.Seconds(2);
            var expected = Velocity.Imperial<Mile>(2).PerSecond();

            var actual = distance / duration;

            actual.Matches(expected);
        }
        [Fact]
        public void LengthByLengthIsArea()
        {
            var length = Length.Create<Kilo, Metre>(2);
            var width = Length.Create<Hecto, Metre>(1);
            var area = length * width;
            Assert.Equal(0.2, area.Value, SiPrecision);
        }
    }
}

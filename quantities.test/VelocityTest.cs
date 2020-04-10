using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.SiDerived;
using Quantities.Unit.Imperial.Length;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class VelocityTest
    {
        [Fact]
        public void Create()
        {
            var speed = Velocity.Si<Metre>(5).PerSecond();
            Assert.Equal("5 m/s", speed.ToString());
        }
        [Fact]
        public void KilometrePerHourToMetrePerSecond()
        {
            var speed = Velocity.Si<Kilo, Metre>(36).Per<Hour>();
            var expected = Velocity.Si<Metre>(10).PerSecond();

            var actual = speed.To<Metre>().PerSecond();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MetrePerSecondToKilometrePerHour()
        {
            var speed = Velocity.Si<Metre>(2).PerSecond();
            var expected = Velocity.Si<Kilo, Metre>(7.2).Per<Hour>();

            var actual = speed.To<Kilo, Metre>().Per<Hour>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TrivialTransform()
        {
            var speed = Velocity.Si<Metre>(200).PerSecond();
            var expected = Velocity.Si<Metre>(0.2).Per<Milli, Second>();

            var actual = speed.To<Metre>().Per<Milli, Second>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Transform()
        {
            var speed = Velocity.Si<Centi, Metre>(4).PerSecond();
            var expected = Velocity.Si<Milli, Metre>(40).PerSecond();

            var actual = speed.To<Milli, Metre>().PerSecond();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MilesPerHourToKilometresPerHour()
        {
            var speed = Velocity.Imperial<Mile>(4).Per<Hour>();
            var expected = Velocity.Si<Kilo, Metre>(4 * 1.609344).Per<Hour>();

            var actual = speed.To<Kilo, Metre>().Per<Hour>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MetresPerSecondToMilesPerHourTo()
        {
            var speed = Velocity.Si<Metre>(0.44704).PerSecond();
            var expected = Velocity.Imperial<Mile>(1).Per<Hour>();

            var actual = speed.ToImperial<Mile>().Per<Hour>();

            actual.Matches(expected);
        }
    }
}
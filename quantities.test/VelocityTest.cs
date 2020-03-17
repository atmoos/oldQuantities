using Xunit;
using Quantities.Unit.Si;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class VelocityTest
    {
        [Fact]
        public void Create()
        {
            var speed = Velocity.Create<Metre>(5).Per<Second>();
            Assert.Equal("5 m/s", speed.ToString());
        }
        [Fact]
        public void TrivialTransform()
        {
            var speed = Velocity.Create<Metre>(200).Per<Second>();
            var expected = Velocity.Create<Metre>(0.2).Per<Milli, Second>();

            var actual = speed.To<Metre>().Per<Milli, Second>();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Transform()
        {
            var speed = Velocity.Create<Centi, Metre>(4).Per<Second>();
            var expected = Velocity.Create<Milli, Metre>(40).Per<Second>();

            var actual = speed.To<Milli, Metre>().Per<Second>();
            Assert.Equal(expected, actual);
        }
    }
}
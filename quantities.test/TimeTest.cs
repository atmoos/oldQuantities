using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.SiDerived;
using Quantities.Unit.Imperial;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class TimeTest
    {
        [Fact]
        public void SecondsToMinutes()
        {
            var seconds = Time.Seconds(12);
            var minutes = seconds.ToSiDerived<Minute>();
            Assert.Equal(12d / 60, minutes.Value, SiPrecision);
        }
        [Fact]
        public void MinutesToHours()
        {
            var seconds = Time.CreateSiDerived<Minute>(12);
            var hours = seconds.ToSeconds();
            Assert.Equal(12d * 60, hours.Value, SiPrecision);
        }

        [Fact]
        public void SecondsToMicroSeconds()
        {
            var seconds = Time.Seconds(12);
            var microSeconds = seconds.To<Micro, Second>();
            Assert.Equal(12d * 1e6, microSeconds.Value, SiPrecision);
        }

        [Fact]
        public void WeekToHours()
        {
            var seconds = Time.CreateSiDerived<Week>(2);
            var microSeconds = seconds.ToSiDerived<Hour>();
            Assert.Equal(2 * 7 * 24, microSeconds.Value, SiPrecision);
        }
        [Fact]
        public void MinuteToMilliSecond()
        {
            var seconds = Time.CreateSiDerived<Minute>(4);
            var microSeconds = seconds.To<Milli, Second>();
            Assert.Equal(4 * 60 * 1e3, microSeconds.Value, SiPrecision);
        }
    }
}
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class ElectricCurrentTest
    {
        [Fact]
        public void AmpereToString() => FormattingMatches(v => ElectricCurrent.Si<Ampere>(v), "A");
        [Fact]
        public void KiloAmpereToString() => FormattingMatches(v => ElectricCurrent.Si<Kilo, Ampere>(v), "KA");
        [Fact]
        public void MicroAmpereToString() => FormattingMatches(v => ElectricCurrent.Si<Micro, Ampere>(v), "μA");
        [Fact]
        public void OhmsLawInBaseUnits()
        {
            var volts = ElectricPotential.Si<Volt>(12);
            var ohm = ElectricalResistance.Si<Ohm>(3);
            var expected = ElectricCurrent.Si<Ampere>(4);

            var current = volts / ohm;

            current.Matches(expected);
        }
        [Fact]
        public void OhmsLawInPrefixedUnits()
        {
            var volts = ElectricPotential.Si<Kilo, Volt>(12);
            var ohm = ElectricalResistance.Si<Mega, Ohm>(3);
            var expected = ElectricCurrent.Si<Milli, Ampere>(4);

            var current = volts / ohm;

            current.Matches(expected);
        }
        [Fact]
        public void PowerLawInBaseUnits()
        {
            var watts = Power.Si<Watt>(1380);
            var volts = ElectricPotential.Si<Volt>(230);
            var expected = ElectricCurrent.Si<Ampere>(6);

            var current = watts / volts;

            current.Matches(expected);
        }
        [Fact]
        public void PowerLawInPrefixedUnits()
        {
            var watts = Power.Si<Mega, Watt>(9);
            var volts = ElectricPotential.Si<Kilo, Volt>(15);
            var expected = ElectricCurrent.Si<Kilo, Ampere>(0.6);

            var current = watts / volts;

            current.Matches(expected);
        }
    }
}
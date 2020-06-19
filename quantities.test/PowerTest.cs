using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class PowerTest
    {
        [Fact]
        public void WattToString() => FormattingMatches(v => Power.Si<Watt>(v), "W");
        [Fact]
        public void KiloWattToString() => FormattingMatches(v => Power.Si<Kilo, Watt>(v), "KW");
        [Fact]
        public void PowerLawInBaseUnits()
        {
            var volts = ElectricPotential.Si<Volt>(12);
            var ampere = ElectricCurrent.Si<Ampere>(3);
            var expected = Power.Si<Watt>(36);

            var power = volts * ampere;

            power.Matches(expected);
        }
        [Fact]
        public void OhmsLawInPrefixedUnits()
        {
            var volts = ElectricPotential.Si<Kilo, Volt>(70);
            var ampere = ElectricCurrent.Si<Milli, Ampere>(300);
            var expected = Power.Si<Kilo, Watt>(2.1);

            var power = ampere * volts;

            power.Matches(expected);
        }
        [Fact]
        public void OhmsLaw_SquarePotentialPerResistance()
        {
            var volts = ElectricPotential.Si<Kilo, Volt>(0.6);
            var ohm = ElectricalResistance.Si<Kilo, Ohm>(3);
            var expected = Power.Si<Kilo, Watt>(120);

            var power = volts * (volts / ohm);

            power.Matches(expected);
        }
        [Fact]
        public void OhmsLaw_SquareCurrentTimesResistance()
        {
            var ampere = ElectricCurrent.Si<Kilo, Ampere>(8);
            var ohm = ElectricalResistance.Si<Milli, Ohm>(2);
            var expected = Power.Si<Watt>(128);

            var power = ohm * ampere * ampere;

            power.Matches(expected);
        }
    }
}
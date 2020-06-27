using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class ElectricPotentialTest
    {
        [Fact]
        public void VoltToString() => FormattingMatches(v => ElectricPotential.Si<Volt>(v), "V");
        [Fact]
        public void MegaVoltToString() => FormattingMatches(v => ElectricPotential.Si<Mega, Volt>(v), "MV");
        [Fact]
        public void MilliVoltToString() => FormattingMatches(v => ElectricPotential.Si<Milli, Volt>(v), "mV");
        [Fact]
        public void OhmsLawInBaseUnits()
        {
            var ohm = ElectricalResistance.Si<Ohm>(7);
            var ampere = ElectricCurrent.Si<Ampere>(3);
            var expected = ElectricPotential.Si<Volt>(21);

            var potential = ohm * ampere;

            potential.Matches(expected);
        }
        [Fact]
        public void OhmsLawInPrefixedUnits()
        {
            var ohm = ElectricalResistance.Si<Kilo, Ohm>(7);
            var ampere = ElectricCurrent.Si<Micro, Ampere>(3);
            var expected = ElectricPotential.Si<Milli, Volt>(21);

            var potential = ohm * ampere;

            potential.Matches(expected);
        }
        [Fact]
        public void PowerLawInBaseUnits()
        {
            var watts = Power.Si<Watt>(1380);
            var ampere = ElectricCurrent.Si<Ampere>(6);
            var expected = ElectricPotential.Si<Volt>(230);

            var potential = watts / ampere;

            potential.Matches(expected);
        }
        [Fact]
        public void PowerLawInPrefixedUnits()
        {
            var watts = Power.Si<Mega, Watt>(9);
            var volts = ElectricPotential.Si<Kilo, Volt>(15);
            var ampere = ElectricCurrent.Si<Ampere>(600);

            // ToDo: Implement rounding based on value!
            var expected = ElectricPotential.Si<Mega, Volt>(0.015);

            var potential = watts / ampere;

            potential.Matches(expected);
        }
    }
}
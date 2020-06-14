using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Prefixes;

namespace Quantities.Test
{
    public sealed class ElectricCurrentTest
    {
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
    }
}
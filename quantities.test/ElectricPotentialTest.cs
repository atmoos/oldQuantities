using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Prefixes;

namespace Quantities.Test
{
    public sealed class ElectricPotentialTest
    {
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
            var ohm = ElectricalResistance.Si<Mega, Ohm>(7);
            var ampere = ElectricCurrent.Si<Milli, Ampere>(3);
            var expected = ElectricPotential.Si<Kilo, Volt>(21);

            var potential = ohm * ampere;

            potential.Matches(expected);
        }
    }
}
using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Unit.Si.Accepted;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class MassTest
    {
        [Fact]
        public void GramToKilogram()
        {
            var mass = Mass.Si<Gram>(1600);
            var expected = Mass.Si<Kilogram>(1.6);

            var actual = mass.To<Kilogram>();

            actual.Matches(expected);
        }
        [Fact]
        public void KilogramToGram()
        {
            var mass = Mass.Si<Kilogram>(0.8);
            var expected = Mass.Si<Gram>(800);

            var actual = mass.To<Gram>();

            actual.Matches(expected);
        }
    }
}
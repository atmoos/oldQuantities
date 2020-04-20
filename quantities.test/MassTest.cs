using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Unit.Imperial.Mass;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class MassTest
    {
        private const Double GramsInPound = 453.59237;
        private static readonly Mass OnePound = Mass.Imperial<Pound>(1);
        [Fact]
        public void KilogramToString() => FormattingMatches(v => Mass.Si<Kilogram>(v), "kg");
        [Fact]
        public void GramToString() => FormattingMatches(v => Mass.Si<Gram>(v), "g");
        [Fact]
        public void TonneToString() => FormattingMatches(v => Mass.Si<Tonne>(v), "t");
        [Fact]
        public void KiloGramToString() => FormattingMatches(v => Mass.Si<Kilo, Gram>(v), "Kg");
        [Fact]
        public void MicroGramToString() => FormattingMatches(v => Mass.Si<Micro, Gram>(v), "μg");
        [Fact]
        public void KiloTonneToString() => FormattingMatches(v => Mass.Si<Kilo, Tonne>(v), "Kt");
        [Fact]
        public void MegaTonneToString() => FormattingMatches(v => Mass.Si<Mega, Tonne>(v), "Mt");
        [Fact]
        public void KilogramKiloGramEquivalence()
        {
            var siKilogram = Mass.Si<Kilogram>(0.3251);
            var pseudoKiloGram = Mass.Si<Kilo, Gram>(0.3251);

            Assert.Equal(siKilogram, pseudoKiloGram);
        }
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
        [Fact]
        public void TonneToKilogram()
        {
            var mass = Mass.Si<Tonne>(0.2);
            var expected = Mass.Si<Kilogram>(200);

            var actual = mass.To<Kilogram>();

            actual.Matches(expected);
        }
        [Fact]
        public void KilogramToTonne()
        {
            var mass = Mass.Si<Kilogram>(1200);
            var expected = Mass.Si<Tonne>(1.2);

            var actual = mass.To<Tonne>();

            actual.Matches(expected);
        }
        [Fact]
        public void GramToTonne()
        {
            var mass = Mass.Si<Kilo, Gram>(1500);
            var expected = Mass.Si<Tonne>(1.5);

            var actual = mass.To<Tonne>();

            actual.Matches(expected);
        }
        [Fact]
        public void TonneToGram()
        {
            var mass = Mass.Si<Tonne>(0.003);
            var expected = Mass.Si<Gram>(3000);

            var actual = mass.To<Gram>();

            actual.Matches(expected);
        }
        [Fact]
        public void GramToPound()
        {
            var mass = Mass.Si<Gram>(3d * GramsInPound);
            var expected = Mass.Imperial<Pound>(3);

            var actual = mass.ToImperial<Pound>();

            actual.Matches(expected);
        }
        [Fact]
        public void PoundToGram()
        {
            var mass = Mass.Imperial<Pound>(2);
            var expected = Mass.Si<Gram>(2d * GramsInPound);

            var actual = mass.To<Gram>();

            actual.Matches(expected);
        }
        [Fact]
        public void PoundToStone()
        {
            var mass = Mass.Imperial<Pound>(28);
            var expected = Mass.Imperial<Stone>(2);

            var actual = mass.ToImperial<Stone>();

            actual.Matches(expected);
        }
        [Fact]
        public void StoneToPound()
        {
            var mass = Mass.Imperial<Stone>(0.5);
            var expected = Mass.Imperial<Pound>(7);

            var actual = mass.ToImperial<Pound>();

            actual.Matches(expected);
        }
        [Fact]
        public void PoundToOunce()
        {
            var mass = Mass.Imperial<Pound>(4);
            var expected = Mass.Imperial<Ounce>(64);

            var actual = mass.ToImperial<Ounce>();

            actual.Matches(expected);
        }
        [Fact]
        public void OunceToPound()
        {
            var mass = Mass.Imperial<Ounce>(4);
            var expected = Mass.Imperial<Pound>(0.25);

            var actual = mass.ToImperial<Pound>();

            actual.Matches(expected);
        }
        [Fact]
        public void DefinitionOfGrainHolds()
        {
            Assert.Equal(OnePound, Mass.Imperial<Grain>(7000));
        }
        [Fact]
        public void DefinitionOfDrachmHolds()
        {
            Assert.Equal(OnePound, Mass.Imperial<Drachm>(256));
        }
        [Fact]
        public void DefinitionOfOunceHolds()
        {
            Assert.Equal(OnePound, Mass.Imperial<Ounce>(16));
        }
        [Fact]
        public void DefinitionOfPoundHolds()
        {
            Assert.Equal(Mass.Si<Kilogram>(1), Mass.Imperial<Pound>(1000d / GramsInPound));
        }
        [Fact]
        public void DefinitionOfStoneHolds()
        {
            Assert.Equal(Mass.Imperial<Pound>(14), Mass.Imperial<Stone>(1));
        }
        [Fact]
        public void DefinitionOfQuarterHolds()
        {
            Assert.Equal(Mass.Imperial<Pound>(28), Mass.Imperial<Quarter>(1));
        }
        [Fact]
        public void DefinitionOfHundredweightHolds()
        {
            Assert.Equal(Mass.Imperial<Pound>(112), Mass.Imperial<Hundredweight>(1));
        }
        [Fact]
        public void DefinitionOfTonHolds()
        {
            Assert.Equal(Mass.Imperial<Pound>(2240), Mass.Imperial<Ton>(1));
        }
        [Fact]
        public void DefinitionOfSlugHolds()
        {
            Assert.Equal(Mass.Si<Kilogram>(14.59390294), Mass.Imperial<Slug>(1));
        }
    }
}
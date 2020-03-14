using System;
using System.Globalization;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures.Test
{
    public class QuantitiesTest
    {
        [Fact]
        public void ToStringProducesTruncatedRepresentation()
        {
            var q = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(Math.E);
            Assert.Equal("2.7183 m", q.ToString());
        }

        [Fact]
        public void FormattedToStringProducesExpectedRepresentation()
        {
            var q = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(Math.E * 1e-4);
            Assert.Equal("0.0002718 m", q.ToString("f7", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TwoSiQuantitiesOfSameMeasureAreEqual()
        {
            var qa = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(1);
            var qb = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(1);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfAlmostSameValueAreEqual()
        {
            var qa = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(1);
            var qb = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(1 - 2e-15);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfDifferentMeasureAreEqual()
        {
            var qa = Quantity<ILength>.Si<Length<Kilo, Metre>>(1);
            var qb = Quantity<ILength>.Si<Length<Deca, Metre>>(100);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfSlightlyDifferentValueAreNotEqual()
        {
            var qa = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(1);
            var qb = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(1 - 2.056e-15);
            Assert.NotEqual(qa, qb);
        }
    }
}

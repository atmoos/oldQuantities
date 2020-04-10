using System;
using System.Globalization;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial.Length;
using Quantities.Prefixes;
using Quantities.Measures.Si;
using Quantities.Dimensions;

using static Quantities.Measures.Test.Metrics;

namespace Quantities.Measures.Test
{
    public interface ILinearQuantitiesTest : IQuantitiesTest
    {
        void OtherQuantityToOtherQuantityScalesLinearly();
        void OtherQuantityToSiQuantityScalesLinearly();
        void SiQuantityToOtherQuantityScalesLinearly();
        void SiQuantityToSiQuantityScalesLinearly();
    }
    public sealed class LinearQuantitiesTest : ILinearQuantitiesTest
    {
        private const Double ANY_NUMBER = 42;
        private const Double ONE_FOOT_IN_METRES = 0.3048;
        private const Double ONE_MILE_IN_METRES = 1609.344;
        private const Double ONE_MILE_IN_KILOMETRES = 1.609344;
        private const Double ONE_MILE_IN_FEET = ONE_MILE_IN_METRES / ONE_FOOT_IN_METRES;

        [Fact]
        public void ToStringProducesTruncatedRepresentation()
        {
            var q = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(Math.E);
            Assert.Equal($"{Math.E:g5} m", q.ToString());
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
        [Fact]
        public void SiQuantityToSiQuantityScalesLinearly()
        {
            var baseSi = Quantity<ILength>.Si<Length<Micro, Metre>>(1e9);

            Assert.Equal(1d, baseSi.To<Length<Kilo, Metre>>().Value);
        }
        [Fact]
        public void SiQuantityToOtherQuantityScalesLinearly()
        {
            var baseSi = Quantity<ILength>.Si<Length<Kilo, Metre>>(ONE_MILE_IN_KILOMETRES);

            Assert.Equal(1d, baseSi.ToOther<Mile>().Value);
        }
        [Fact]
        public void OtherQuantityToSiQuantityScalesLinearly()
        {
            var baseOther = Quantity<ILength>.Other<Foot>(1);

            Assert.Equal(ONE_FOOT_IN_METRES, baseOther.To<Length<UnitPrefix, Metre>>().Value);
        }
        [Fact]
        public void OtherQuantityToOtherQuantityScalesLinearly()
        {
            var baseOther = Quantity<ILength>.Other<Foot>(ONE_MILE_IN_FEET);

            Assert.Equal(1d, baseOther.ToOther<Mile>().Value, NonSiPrecision);
        }
        [Fact]
        public void SiAdditionIsLeftAssociative()
        {
            CheckSiAssociativity((left, right) => left.Add(right));
        }
        [Fact]
        public void OtherAdditionIsLeftAssociative()
        {
            CheckOtherAssociativity((left, right) => left.Add(right));
        }
        [Fact]
        public void SiSubtractionIsLeftAssociative()
        {
            CheckSiAssociativity((left, right) => left.Subtract(right));
        }
        [Fact]
        public void OthSubtractionIsLeftAssociative()
        {
            CheckOtherAssociativity((left, right) => left.Subtract(right));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithSameMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Kilo, Metre>>(2);
            var qb = Quantity<ILength>.Si<Length<Kilo, Metre>>(3);
            var expected = Quantity<ILength>.Si<Length<Kilo, Metre>>(5);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Deci, Metre>>(2);
            var qb = Quantity<ILength>.Si<Length<Hecto, Metre>>(3);
            var expected = Quantity<ILength>.Si<Length<Deci, Metre>>(3002);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithOtherMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Kilo, Metre>>(2);
            var qb = Quantity<ILength>.Other<Mile>(1);
            var expected = Quantity<ILength>.Si<Length<Kilo, Metre>>(2 + ONE_MILE_IN_KILOMETRES);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfOtherMeasureWithSiMeasure()
        {
            var qa = Quantity<ILength>.Other<Mile>(1);
            var qb = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(ONE_MILE_IN_METRES);
            var expected = Quantity<ILength>.Other<Mile>(2);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfOtherMeasureWithOtherMeasure()
        {
            var qa = Quantity<ILength>.Other<Foot>(3);
            var qb = Quantity<ILength>.Other<Foot>(7);
            var expected = Quantity<ILength>.Other<Foot>(10);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void SubtractionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Mega, Metre>>(5);
            var qb = Quantity<ILength>.Si<Length<Deca, Metre>>(300);
            var expected = Quantity<ILength>.Si<Length<Mega, Metre>>(4.997);

            Assert.Equal(expected, qa.Subtract(qb));
        }

        [Fact]
        public void SubtractionOfSiQuantitiesWithOtherMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Kilo, Metre>>(2);
            var qb = Quantity<ILength>.Other<Mile>(1);
            var expected = Quantity<ILength>.Si<Length<Kilo, Metre>>(2 - ONE_MILE_IN_KILOMETRES);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void SubtractionOfOtherMeasureWithSiMeasure()
        {
            var qa = Quantity<ILength>.Other<Mile>(3);
            var qb = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(ONE_MILE_IN_METRES);
            var expected = Quantity<ILength>.Other<Mile>(2);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void SubtractionOfOtherMeasureWithOtherMeasure()
        {
            var qa = Quantity<ILength>.Other<Foot>(3);
            var qb = Quantity<ILength>.Other<Foot>(7);
            var expected = Quantity<ILength>.Other<Foot>(-4);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithSameMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Deci, Metre>>(50);
            var qb = Quantity<ILength>.Si<Length<Deci, Metre>>(10);
            var expected = 50 / 10;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<ILength>.Si<Length<Hecto, Metre>>(5);
            var qb = Quantity<ILength>.Si<Length<Deci, Metre>>(5);
            var expected = 500 / 0.5;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithOtherQuantity()
        {
            var qa = Quantity<ILength>.Si<Length<Kilo, Metre>>(2 * ONE_MILE_IN_KILOMETRES);
            var qb = Quantity<ILength>.Other<Mile>(0.5);
            var expected = 2 / 0.5;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfOtherQuantityWithSameOtherQuantity()
        {
            var qa = Quantity<ILength>.Other<Mile>(8);
            var qb = Quantity<ILength>.Other<Mile>(0.25);
            var expected = 8 / 0.25;

            Assert.Equal(expected, qa.Divide(qb));
        }

        [Fact]
        public void DivisionOfOtherQuantityWithOtherOtherQuantity()
        {
            var qa = Quantity<ILength>.Other<Foot>(5280);
            var qb = Quantity<ILength>.Other<Mile>(1);
            var expected = 5280d * ONE_FOOT_IN_METRES / ONE_MILE_IN_METRES;

            Assert.Equal(expected, qa.Divide(qb), NonSiPrecision);
        }
        void CheckSiAssociativity(Func<Quantity<ITime>, Quantity<ITime>, Quantity<ITime>> operation)
        {
            var left = Quantity<ITime>.Si<Time<Micro, Second>>(2);
            var right = Quantity<ITime>.Si<Time<Atto, Second>>(3);
            var expectedDimension = Quantity<ITime>.Si<Time<Micro, Second>>(ANY_NUMBER);

            AssertDimensionsAreSame(expectedDimension, operation(left, right));
        }
        void CheckOtherAssociativity(Func<Quantity<ILength>, Quantity<ILength>, Quantity<ILength>> operation)
        {
            var left = Quantity<ILength>.Other<Mile>(2);
            var right = Quantity<ILength>.Si<Length<Atto, Metre>>(3);
            var expectedDimension = Quantity<ILength>.Other<Mile>(ANY_NUMBER);

            AssertDimensionsAreSame(expectedDimension, operation(left, right));
        }
    }
}

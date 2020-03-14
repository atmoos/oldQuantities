using System;
using System.Globalization;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures.Test
{
    public sealed class QuantitiesTest
    {
        private const Double ANY_NUMBER = 42;
        private const Double ONE_MILE_IN_METRES = 1609.334;
        private const Double ONE_MILE_IN_KILOMETRES = 1.609334;
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
        public void AdditionOfOthMeasureWithSiMeasure()
        {
            var qa = Quantity<ILength>.Other<Mile>(1);
            var qb = Quantity<ILength>.Si<Length<UnitPrefix, Metre>>(ONE_MILE_IN_METRES);
            var expected = Quantity<ILength>.Other<Mile>(2);

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
        void AssertDimensionsAreSame<TDimension>(Quantity<TDimension> expected, Quantity<TDimension> actual)
            where TDimension : IDimension
        {
            Assert.Same(expected.Dimension, actual.Dimension);
        }
    }
}

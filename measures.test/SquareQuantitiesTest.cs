using System;
using System.Globalization;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial.Area;
using Quantities.Unit.Imperial.Length;
using Quantities.Prefixes;
using Quantities.Dimensions;

using static Quantities.Measures.Test.Metrics;

namespace Quantities.Measures.Test
{
    public interface ISquareQuantitiesTest : IQuantitiesTest
    {
        void OtherQuantityToOtherQuantityScalesSquarely();
        void OtherQuantityToSiQuantityScalesSquarely();
        void SiQuantityToOtherQuantityScalesSquarely();
        void SiQuantityToSiQuantityScalesSquarely();
    }
    public sealed class SquareQuantitiesTest : ISquareQuantitiesTest
    {
        private const Double ANY_NUMBER = 42;
        private const Double ONE_ACRE_IN_SQUARE_METRES = 4046.8564224;
        private const Double ONE_ACRE_IN_SQUARE_KILOMETRES = 0.0040468564224;
        private const Double ONE_ACRE_IN_SQUARE_MILES = ONE_ACRE_IN_SQUARE_KILOMETRES / (1.609334 * 1.609334);


        [Fact]
        public void ToStringProducesTruncatedRepresentation()
        {
            var q = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(Math.E);
            Assert.Equal($"{Math.E:g5} m²", q.ToString());
        }

        [Fact]
        public void FormattedToStringProducesExpectedRepresentation()
        {
            var q = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(Math.E * 1e-4);
            Assert.Equal("0.0002718 m²", q.ToString("f7", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TwoSiQuantitiesOfSameMeasureAreEqual()
        {
            var qa = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(1);
            var qb = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(1);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfAlmostSameValueAreEqual()
        {
            var qa = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(1);
            var qb = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(1 - 2e-15);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfDifferentMeasureAreEqual()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2);
            var qb = Quantity<IArea>.Si<Area<Length<Deca, Metre>>>(20000);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfSlightlyDifferentValueAreNotEqual()
        {
            var qa = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(1);
            var qb = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(1 - 2.056e-15);
            Assert.NotEqual(qa, qb);
        }
        [Fact]
        public void SiQuantityToSiQuantityScalesSquarely()
        {
            var baseSi = Quantity<IArea>.Si<Area<Length<Centi, Metre>>>(1e6);

            Assert.Equal(1d, baseSi.To<Area<Length<Deca, Metre>>>().Value);
        }
        [Fact]
        public void SiQuantityToOtherQuantityScalesSquarely()
        {
            var baseSi = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(ONE_ACRE_IN_SQUARE_KILOMETRES);

            Assert.Equal(1d, baseSi.ToOther<Acre>().Value);
        }
        [Fact]
        public void OtherQuantityToSiQuantityScalesSquarely()
        {
            var baseOther = Quantity<IArea>.Other<Acre>(1);

            Assert.Equal(ONE_ACRE_IN_SQUARE_METRES, baseOther.To<Area<Length<UnitPrefix, Metre>>>().Value);
        }
        [Fact]
        public void OtherQuantityToOtherQuantityScalesSquarely()
        {
            var baseOther = Quantity<IArea>.Other<Square<Foot>>(9);

            Assert.Equal(1d, baseOther.ToOther<Square<Yard>>().Value, NonSiPrecision);
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
            var qa = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2);
            var qb = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(3);
            var expected = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(5);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Deca, Metre>>>(2);
            var qb = Quantity<IArea>.Si<Area<Length<Hecto, Metre>>>(3);
            var expected = Quantity<IArea>.Si<Area<Length<Deca, Metre>>>(302);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithOtherMeasure()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2);
            var qb = Quantity<IArea>.Other<Acre>(1);
            var expected = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2 + ONE_ACRE_IN_SQUARE_KILOMETRES);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfOtherMeasureWithSiMeasure()
        {
            var qa = Quantity<IArea>.Other<Acre>(1);
            var qb = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(ONE_ACRE_IN_SQUARE_METRES);
            var expected = Quantity<IArea>.Other<Acre>(2);

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
            var qa = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(0.5);
            var qb = Quantity<IArea>.Si<Area<Length<Deca, Metre>>>(300);
            var expected = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(0.47);

            Assert.Equal(expected, qa.Subtract(qb));
        }

        [Fact]
        public void SubtractionOfSiQuantitiesWithOtherMeasure()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2);
            var qb = Quantity<IArea>.Other<Acre>(1);
            var expected = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2 - ONE_ACRE_IN_SQUARE_KILOMETRES);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void SubtractionOfOtherMeasureWithSiMeasure()
        {
            var qa = Quantity<IArea>.Other<Acre>(3);
            var qb = Quantity<IArea>.Si<Area<Length<UnitPrefix, Metre>>>(ONE_ACRE_IN_SQUARE_METRES);
            var expected = Quantity<IArea>.Other<Acre>(2);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void SubtractionOfOtherMeasureWithOtherMeasure()
        {
            var qa = Quantity<IArea>.Other<Acre>(3);
            var qb = Quantity<IArea>.Other<Acre>(7);
            var expected = Quantity<IArea>.Other<Acre>(-4);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithSameMeasure()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Deci, Metre>>>(50);
            var qb = Quantity<IArea>.Si<Area<Length<Deci, Metre>>>(10);
            var expected = 50 / 10;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Hecto, Metre>>>(8);
            var qb = Quantity<IArea>.Si<Area<Length<Deci, Metre>>>(4);
            var expected = 80000 / 0.04;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithOtherQuantity()
        {
            var qa = Quantity<IArea>.Si<Area<Length<Kilo, Metre>>>(2 * ONE_ACRE_IN_SQUARE_KILOMETRES);
            var qb = Quantity<IArea>.Other<Acre>(0.5);
            var expected = 2 / 0.5;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfOtherQuantityWithSameOtherQuantity()
        {
            var qa = Quantity<IArea>.Other<Acre>(8);
            var qb = Quantity<IArea>.Other<Acre>(0.25);
            var expected = 8 / 0.25;

            Assert.Equal(expected, qa.Divide(qb));
        }

        [Fact]
        public void DivisionOfOtherQuantityWithOtherOtherQuantity()
        {
            var qa = Quantity<IArea>.Other<Square<Mile>>(ONE_ACRE_IN_SQUARE_MILES);
            var qb = Quantity<IArea>.Other<Acre>(1);

            Assert.Equal(1d, qa.Divide(qb), NonSiPrecision);
        }
        void CheckSiAssociativity(Func<Quantity<IArea>, Quantity<IArea>, Quantity<IArea>> operation)
        {
            var left = Quantity<IArea>.Si<Area<Length<Micro, Metre>>>(2);
            var right = Quantity<IArea>.Si<Area<Length<Atto, Metre>>>(3);
            var expectedDimension = Quantity<IArea>.Si<Area<Length<Micro, Metre>>>(ANY_NUMBER);

            AssertDimensionsAreSame(expectedDimension, operation(left, right));
        }
        void CheckOtherAssociativity(Func<Quantity<IArea>, Quantity<IArea>, Quantity<IArea>> operation)
        {
            var left = Quantity<IArea>.Other<Acre>(2);
            var right = Quantity<IArea>.Si<Area<Length<Atto, Metre>>>(3);
            var expectedDimension = Quantity<IArea>.Other<Acre>(ANY_NUMBER);

            AssertDimensionsAreSame(expectedDimension, operation(left, right));
        }
    }
}

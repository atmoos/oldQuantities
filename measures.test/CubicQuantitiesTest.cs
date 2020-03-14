using System;
using System.Globalization;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial.Volume;
using Quantities.Prefixes;
using Quantities.Measures.Si;
using Quantities.Dimensions;

using static Quantities.Measures.Test.Metrics;

namespace Quantities.Measures.Test
{
    public interface ICubicQuantitiesTest : IQuantitiesTest
    {
        void OtherQuantityToOtherQuantityScalesCubic();
        void OtherQuantityToSiQuantityScalesCubic();
        void SiQuantityToOtherQuantityScalesCubic();
        void SiQuantityToSiQuantityScalesCubic();
    }
    public sealed class CubicQuantitiesTest : ICubicQuantitiesTest
    {
        private const Double ANY_NUMBER = 42;
        private const Double ONE_PINT_IN_LITRES = 0.56826125;
        private const Double ONE_QUART_IN_LITRES = 1.1365225;
        private const Double ONE_GALLON_IN_LITRES = 4.54609;

        [Fact]
        public void ToStringProducesTruncatedRepresentation()
        {
            var q = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(Math.E);
            Assert.Equal($"{Math.E:g5} m³", q.ToString());
        }

        [Fact]
        public void FormattedToStringProducesExpectedRepresentation()
        {
            var q = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(Math.E * 1e-4);
            Assert.Equal("0.0002718 m³", q.ToString("f7", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TwoSiQuantitiesOfSameMeasureAreEqual()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(1);
            var qb = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(1);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfAlmostSameValueAreEqual()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(1);
            var qb = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(1 - 2e-15);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfDifferentMeasureAreEqual()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Kilo, Metre>>>(1);
            var qb = Quantity<IVolume>.Si<Volume<Length<Hecto, Metre>>>(1e3);
            Assert.Equal(qa, qb);
        }
        [Fact]
        public void TwoSiQuantitiesOfSlightlyDifferentValueAreNotEqual()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(1);
            var qb = Quantity<IVolume>.Si<Volume<Length<UnitPrefix, Metre>>>(1 - 2.056e-15);
            Assert.NotEqual(qa, qb);
        }
        [Fact]
        public void SiQuantityToSiQuantityScalesCubic()
        {
            var baseSi = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(1e6);

            Assert.Equal(1d, baseSi.To<Volume<Length<Deca, Metre>>>().Value);
        }
        [Fact]
        public void SiQuantityToOtherQuantityScalesCubic()
        {
            var baseSi = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(ONE_GALLON_IN_LITRES);

            Assert.Equal(1d, baseSi.ToOther<Gallon>().Value, NonSiPrecision);
        }
        [Fact]
        public void OtherQuantityToSiQuantityScalesCubic()
        {
            var baseOther = Quantity<IVolume>.Other<Gallon>(1);

            Assert.Equal(ONE_GALLON_IN_LITRES, baseOther.To<Volume<Length<Deci, Metre>>>().Value);
        }
        [Fact]
        public void OtherQuantityToOtherQuantityScalesCubic()
        {
            var baseOther = Quantity<IVolume>.Other<Pint>(8);

            Assert.Equal(1d, baseOther.ToOther<Gallon>().Value, NonSiPrecision);
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
            var qa = Quantity<IVolume>.Si<Volume<Length<Kilo, Metre>>>(2);
            var qb = Quantity<IVolume>.Si<Volume<Length<Kilo, Metre>>>(3);
            var expected = Quantity<IVolume>.Si<Volume<Length<Kilo, Metre>>>(5);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2);
            var qb = Quantity<IVolume>.Si<Volume<Length<Centi, Metre>>>(3);
            var expected = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2.003);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfSiQuantitiesWithOtherMeasure()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2);
            var qb = Quantity<IVolume>.Other<Gallon>(1);
            var expected = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2 + ONE_GALLON_IN_LITRES);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfOtherMeasureWithSiMeasure()
        {
            var qa = Quantity<IVolume>.Other<Pint>(1);
            var qb = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(ONE_PINT_IN_LITRES);
            var expected = Quantity<IVolume>.Other<Pint>(2);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void AdditionOfOtherMeasureWithOtherMeasure()
        {
            var qa = Quantity<IVolume>.Other<Pint>(3);
            var qb = Quantity<IVolume>.Other<Pint>(7);
            var expected = Quantity<IVolume>.Other<Pint>(10);

            Assert.Equal(expected, qa.Add(qb));
        }
        [Fact]
        public void SubtractionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(5);
            var qb = Quantity<IVolume>.Si<Volume<Length<Centi, Metre>>>(300);
            var expected = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(4.7);

            Assert.Equal(expected, qa.Subtract(qb));
        }

        [Fact]
        public void SubtractionOfSiQuantitiesWithOtherMeasure()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2);
            var qb = Quantity<IVolume>.Other<Quart>(1);
            var expected = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2 - ONE_QUART_IN_LITRES);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void SubtractionOfOtherMeasureWithSiMeasure()
        {
            var qa = Quantity<IVolume>.Other<Pint>(3);
            var qb = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(ONE_PINT_IN_LITRES);
            var expected = Quantity<IVolume>.Other<Pint>(2);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void SubtractionOfOtherMeasureWithOtherMeasure()
        {
            var qa = Quantity<IVolume>.Other<FluidOunce>(3);
            var qb = Quantity<IVolume>.Other<FluidOunce>(7);
            var expected = Quantity<IVolume>.Other<FluidOunce>(-4);

            Assert.Equal(expected, qa.Subtract(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithSameMeasure()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(50);
            var qb = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(10);
            var expected = 50 / 10;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithDifferentMeasure()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deca, Metre>>>(4);
            var qb = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(4);
            var expected = 4000 / 0.004;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfSiQuantitiesWithOtherQuantity()
        {
            var qa = Quantity<IVolume>.Si<Volume<Length<Deci, Metre>>>(2 * ONE_GALLON_IN_LITRES);
            var qb = Quantity<IVolume>.Other<Gallon>(0.5);
            var expected = 2 / 0.5;

            Assert.Equal(expected, qa.Divide(qb));
        }
        [Fact]
        public void DivisionOfOtherQuantityWithSameOtherQuantity()
        {
            var qa = Quantity<IVolume>.Other<Gill>(8);
            var qb = Quantity<IVolume>.Other<Gill>(0.25);
            var expected = 8 / 0.25;

            Assert.Equal(expected, qa.Divide(qb));
        }

        [Fact]
        public void DivisionOfOtherQuantityWithOtherOtherQuantity()
        {
            var qa = Quantity<IVolume>.Other<Pint>(8);
            var qb = Quantity<IVolume>.Other<Gallon>(1);

            Assert.Equal(1d, qa.Divide(qb), NonSiPrecision);
        }

        void CheckSiAssociativity(Func<Quantity<IVolume>, Quantity<IVolume>, Quantity<IVolume>> operation)
        {
            var left = Quantity<IVolume>.Si<Volume<Length<Micro, Metre>>>(2);
            var right = Quantity<IVolume>.Si<Volume<Length<Atto, Metre>>>(3);
            var expectedDimension = Quantity<IVolume>.Si<Volume<Length<Micro, Metre>>>(ANY_NUMBER);

            AssertDimensionsAreSame(expectedDimension, operation(left, right));
        }
        void CheckOtherAssociativity(Func<Quantity<IVolume>, Quantity<IVolume>, Quantity<IVolume>> operation)
        {
            var left = Quantity<IVolume>.Other<Pint>(2);
            var right = Quantity<IVolume>.Si<Volume<Length<Atto, Metre>>>(3);
            var expectedDimension = Quantity<IVolume>.Other<Pint>(ANY_NUMBER);

            AssertDimensionsAreSame(expectedDimension, operation(left, right));
        }
    }
}

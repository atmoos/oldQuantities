namespace Quantities.Measures.Test
{
    public interface IQuantitiesTest
    {
        void AdditionOfOtherMeasureWithOtherMeasure();
        void AdditionOfOtherMeasureWithSiMeasure();
        void AdditionOfSiQuantitiesWithDifferentMeasure();
        void AdditionOfSiQuantitiesWithOtherMeasure();
        void AdditionOfSiQuantitiesWithSameMeasure();
        void DivisionOfOtherQuantityWithOtherOtherQuantity();
        void DivisionOfOtherQuantityWithSameOtherQuantity();
        void DivisionOfSiQuantitiesWithDifferentMeasure();
        void DivisionOfSiQuantitiesWithOtherQuantity();
        void DivisionOfSiQuantitiesWithSameMeasure();
        void FormattedToStringProducesExpectedRepresentation();
        void OtherAdditionIsLeftAssociative();
        void OthSubtractionIsLeftAssociative();
        void SiAdditionIsLeftAssociative();
        void SiSubtractionIsLeftAssociative();
        void SubtractionOfOtherMeasureWithOtherMeasure();
        void SubtractionOfOtherMeasureWithSiMeasure();
        void SubtractionOfSiQuantitiesWithDifferentMeasure();
        void SubtractionOfSiQuantitiesWithOtherMeasure();
        void ToStringProducesTruncatedRepresentation();
        void TwoSiQuantitiesOfAlmostSameValueAreEqual();
        void TwoSiQuantitiesOfDifferentMeasureAreEqual();
        void TwoSiQuantitiesOfSameMeasureAreEqual();
        void TwoSiQuantitiesOfSlightlyDifferentValueAreNotEqual();
    }
}

using System;

namespace Quantities.Unit.Transformation
{
    public class LinearTransform : ITransform
    {
        private readonly Decimal _offset;
        private readonly Decimal _nominator;
        private readonly Decimal _denominator;
        private protected LinearTransform(Decimal nominator, Decimal denominator, Decimal offset)
        {
            _nominator = nominator;
            _denominator = denominator;
            _offset = offset;
        }
        public Double ToSi(in Double nonSiValue) => (Double)(((_nominator * (Decimal)(nonSiValue)) / _denominator) + _offset);
        public Double FromSi(in Double siValue) => (Double)((_denominator * ((Decimal)(siValue) - _offset)) / _nominator);
    }
}
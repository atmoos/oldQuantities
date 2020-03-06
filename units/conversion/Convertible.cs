using System;

namespace Quantities.Unit.Conversion
{
    public abstract class Convertible : IConvertible
    {
        private readonly Double _asSiUnit;
        private readonly Double _fromSiUnit;

        internal Convertible(Double asSiUnit)
        {
            _asSiUnit = asSiUnit;
            _fromSiUnit = 1d / asSiUnit;
        }

        public Double ToSi(Double nonSiValue) => nonSiValue * _asSiUnit;
        public Double FromSi(Double siValue) => siValue * _fromSiUnit;
    }
}
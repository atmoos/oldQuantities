using System;

namespace Quantities.Unit.Conversion
{
    public abstract class Convertible<TSi, TNonSi> : IToSiConverter<TNonSi, TSi>, IFromSiConverter<TSi, TNonSi>
        where TSi : SiUnit, new()
        where TNonSi : INonSiUnit, new()
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
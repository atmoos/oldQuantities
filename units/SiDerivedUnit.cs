using System;
using Quantities.Unit.Transformation;

namespace Quantities.Unit
{
    public abstract class SiDerivedUnit : SiUnit, ITransform
    {
        private readonly Double _asSiUnit;
        private readonly Double _fromSiUnit;
        internal SiDerivedUnit(Double asSiUnit)
        {
            _asSiUnit = asSiUnit;
            _fromSiUnit = 1d / asSiUnit;
        }
        public Double ToSi(in Double nonSiValue) => nonSiValue * _asSiUnit;
        public Double FromSi(in Double siValue) => siValue * _fromSiUnit;
    }
}
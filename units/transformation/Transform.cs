using System;

namespace Quantities.Unit.Transformation
{
    public class Transform : ITransform
    {
        private readonly Double _asSiUnit;
        private readonly Double _fromSiUnit;
        private protected Transform(Double asSiUnit)
        {
            _asSiUnit = asSiUnit;
            _fromSiUnit = 1d / asSiUnit;
        }
        public Double ToSi(in Double nonSiValue) => nonSiValue * _asSiUnit;
        public Double FromSi(in Double siValue) => siValue * _fromSiUnit;
    }
}
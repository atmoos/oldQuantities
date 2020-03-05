using System;

namespace Quantities.Unit.Conversion
{
    public interface IToSiConverter<in TNonSiUnit, out TSiUnit>
        where TSiUnit : SiUnit
        where TNonSiUnit : INonSiUnit
    {
        Double ToSi(Double nonSiValue);
    }
}
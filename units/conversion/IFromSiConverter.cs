using System;

namespace Quantities.Unit.Conversion
{
    public interface IFromSiConverter<out TSiUnit, in TNonSiUnit>
        where TSiUnit : SiUnit
        where TNonSiUnit : INonSiUnit
    {
        Double FromSi(Double siValue);
    }
}
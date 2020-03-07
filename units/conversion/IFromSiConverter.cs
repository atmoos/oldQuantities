using System;

namespace Quantities.Unit.Conversion
{
    public interface IFromSiConverter
    {
        Double FromSi(in Double siValue);
    }
}
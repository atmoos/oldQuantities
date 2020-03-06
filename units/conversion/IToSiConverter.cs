using System;

namespace Quantities.Unit.Conversion
{
    public interface IToSiConverter
    {
        Double ToSi(Double nonSiValue);
    }
}
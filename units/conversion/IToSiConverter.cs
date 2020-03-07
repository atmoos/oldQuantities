using System;

namespace Quantities.Unit.Conversion
{
    public interface IToSiConverter
    {
        Double ToSi(in Double nonSiValue);
    }
}
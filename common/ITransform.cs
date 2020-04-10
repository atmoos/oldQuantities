using System;

namespace Quantities
{
    public interface ITransform
    {
        Double ToSi(in Double nonSiValue);
        Double FromSi(in Double siValue);
    }
}
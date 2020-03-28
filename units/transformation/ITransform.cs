using System;

namespace Quantities.Unit.Transformation
{
    public interface ITransform
    {
        Double ToSi(in Double nonSiValue);
        Double FromSi(in Double siValue);
    }
}
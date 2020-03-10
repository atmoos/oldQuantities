using System;

namespace Quantities
{
    public interface INormalize
    {
        Double Normalize(in Double value);
        Double DeNormalize(in Double value);
    }
}
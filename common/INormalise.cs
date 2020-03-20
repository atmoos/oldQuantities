using System;

namespace Quantities
{
    public interface INormalise
    {
        Double Normalise(in Double value);
        Double Renormalise(in Double value);
    }
}
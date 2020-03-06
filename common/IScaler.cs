using System;

namespace Quantities
{
    public interface IScaler<in TBase>
    {
        Double Scale<TOther>(in Double other) where TOther : TBase, new();
    }
}
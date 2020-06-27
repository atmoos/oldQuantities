using System;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures.Core
{
    public interface IBuilder<TDimension>
        where TDimension : IDimension
    {
        Quantity<TDimension> Build();
    }
    internal interface ISiQuantityBuilder<TDimension>
    where TDimension : IDimension
    {
        Quantity<TDimension> Create<TPrefix>(in Double value)
            where TPrefix : Prefix, new();
    }
}
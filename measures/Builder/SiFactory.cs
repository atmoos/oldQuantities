using System;
using Quantities.Prefixes;
using Quantities.Dimensions;
using Quantities.Measures;
using Quantities.Measures.Core;

internal abstract class SiFactory<TInLeft, TInRight, TOut> : ICompoundFactory<TInLeft, TInRight, TOut>, ISiQuantityBuilder<TOut>
    where TInLeft : IDimension
    where TInRight : IDimension
    where TOut : IDimension
{
    public abstract Quantity<TOut> Create<TPrefix>(in Double value) where TPrefix : Prefix, new();
    public abstract Quantity<TOut> CreateSi<TSiA, TSiB>(in Double a, in Double b)
            where TSiA : SiMeasure, TInLeft, new()
            where TSiB : SiMeasure, TInRight, new();
    Quantity<TOut> ICompoundFactory<TInLeft, TInRight, TOut>.CreateOther<TOtherA, TOtherB>(in double a, in double b)
    {
        throw new NotImplementedException();
    }
    Quantity<TOut> ICompoundFactory<TInLeft, TInRight, TOut>.CreateOtherSi<TOtherA, TSiB>(in double a, in double b)
    {
        throw new NotImplementedException();
    }
    Quantity<TOut> ICompoundFactory<TInLeft, TInRight, TOut>.CreateSiOther<TSiA, TOtherB>(in double a, in double b)
    {
        throw new NotImplementedException();
    }
}
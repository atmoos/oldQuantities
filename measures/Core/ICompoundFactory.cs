using System;
using Quantities.Unit;
using Quantities.Dimensions;

namespace Quantities.Measures.Core
{
    interface ICompoundFactory<in TA, in TB, TResult>
        where TA : IDimension
        where TB : IDimension
        where TResult : IDimension
    {
        Quantity<TResult> CreateSi<TSiA, TSiB>(in Double a, in Double b)
            where TSiA : SiMeasure, TA, new()
            where TSiB : SiMeasure, TB, new();
        Quantity<TResult> CreateSiOther<TSiA, TOtherB>(in Double a, in Double b)
            where TSiA : SiMeasure, TA, new()
            where TOtherB : TB, IUnit, ITransform, new();
        Quantity<TResult> CreateOtherSi<TOtherA, TSiB>(in Double a, in Double b)
            where TOtherA : TA, IUnit, ITransform, new()
            where TSiB : SiMeasure, TB, new();
        Quantity<TResult> CreateOther<TOtherA, TOtherB>(in Double a, in Double b)
            where TOtherA : TA, IUnit, ITransform, new()
            where TOtherB : TB, IUnit, ITransform, new();
    }
}
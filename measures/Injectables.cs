using System;
using Quantities.Unit;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    internal interface ISiInjectable<in TDimension>
        where TDimension : IDimension
    {
        void Inject<TInjectedDimension>(in Double value)
            where TInjectedDimension : SiMeasure, TDimension, new();
    }

    internal interface INonSiInjectable
    {
        void Inject<TUnit>(in Double value) where TUnit : IUnit, new();
    }
}
using System;
using Quantities.Unit;
using Quantities.Unit.Transformation;
using Quantities.Dimensions;

namespace Quantities.Measures.Core
{
    internal interface ISiInjectable<in TDimension>
        where TDimension : IDimension
    {
        void Inject<TInjectedDimension>(in Double value)
            where TInjectedDimension : SiMeasure, TDimension, new();
    }
    internal interface INonSiInjectable<in TDimension>
        where TDimension : IDimension
    {
        void Inject<TUnit>(in Double value) where TUnit : TDimension, IUnit, ITransform, new();
    }
    internal interface IInjectable<in TDimension> : ISiInjectable<TDimension>, INonSiInjectable<TDimension>
        where TDimension : IDimension
    { }
}
using Quantities.Unit;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    internal interface ISiInjectable<in TDimension>
        where TDimension : IDimension
    {
        void Inject<TInjectedDimension>()
            where TInjectedDimension : SiMeasure, TDimension, new();
    }

    internal interface INonSiInjectable
    {
        void Inject<TUnit>() where TUnit : IUnit, new();
    }
}
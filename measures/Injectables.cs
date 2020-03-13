using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    internal interface ISiInjectable<in TDimension>
        where TDimension : IDimension
    {
        void Inject<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, TDimension, new();
    }

    internal interface INonSiInjectable
    {
        void Inject<TUnit>() where TUnit : IUnit, new();
    }
}
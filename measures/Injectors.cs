using Quantities.Dimensions;

namespace Quantities.Measures
{
    internal interface ISiInjector<out TDimension>
        where TDimension : IDimension
    {
        void InjectInto(ISiInjectable<TDimension> injectable);
    }
    internal interface INonSiInjector
    {
        void InjectInto(INonSiInjectable injectable);
    }
}
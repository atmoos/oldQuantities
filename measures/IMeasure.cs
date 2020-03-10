using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public interface IMeasure : IDimension { }
    public interface IUnitMeasure<out TUnit>
    {
        TUnit Unit { get; }
    }
    public interface IUnitSiMeasure<out TPrefix, out TUnit> : IUnitMeasure<TUnit>, IMeasure
        where TPrefix : Prefix
        where TUnit : SiUnit
    {
        TPrefix Prefix { get; }
    }
    public interface INonSiUnitMeasure<out TUnit> : IUnitMeasure<TUnit>, IMeasure
        where TUnit : INonSiUnit
    {
    }
}
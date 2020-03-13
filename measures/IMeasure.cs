using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public interface IMeasure : IDimension { }
    public interface ILinearMeasure : IMeasure { }
    public interface ISquareMeasure<out TMeasure> : IMeasure, ISquare<TMeasure>
        where TMeasure : ILinearMeasure
    {
        TMeasure LinearMeasure { get; }
    }
    public interface IUnitMeasure<out TUnit> : ILinearMeasure
    {
        TUnit Unit { get; }
    }
    public interface IUnitSiMeasure<out TPrefix, out TUnit> : IUnitMeasure<TUnit>
        where TPrefix : Prefix
        where TUnit : SiUnit
    {
        TPrefix Prefix { get; }
    }
    public interface INonSiUnitMeasure<out TUnit> : IUnitMeasure<TUnit>
        where TUnit : INonSiUnit
    {
    }
}
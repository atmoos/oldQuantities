using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public interface IMeasure : IDimension { }
    public interface ISiMeasure : IMeasure, INormalize
    {
        Prefix Prefix { get; }
        SiUnit Unit { get; }
    }
    public interface ISiMeasure<out TPrefix, out TUnit> : ISiMeasure
        where TPrefix : Prefix
        where TUnit : SiUnit
    {
        new TPrefix Prefix { get; }
        new TUnit Unit { get; }
    }
    public interface INonSiMeasure<out TUnit> : IMeasure
        where TUnit : INonSiUnit
    {
        TUnit Unit { get; }
    }
}
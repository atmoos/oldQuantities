using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public interface IUnitMeasure<out TUnit> : ILinear
    {
        TUnit Unit { get; }
    }
    public interface IUnitSiMeasure<out TPrefix, out TUnit> : IUnitMeasure<TUnit>
        where TPrefix : Prefix
        where TUnit : SiUnit
    {
        TPrefix Prefix { get; }
    }
}
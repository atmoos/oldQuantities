using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;

namespace Quantities
{
    internal sealed class Time<TPrefix, TUnit> : LinearSiMeasure<TPrefix, TUnit>, ITime
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, ITime, new()
    {
    }
}
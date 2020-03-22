using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Time<TPrefix, TUnit> : LinearSiMeasure<TPrefix, TUnit>, ITime
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, ITime, new()
    {
    }
}
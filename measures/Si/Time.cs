using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Time<TPrefix, TUnit> : LinearSiMeasure<TPrefix, TUnit>, ITime
        where TPrefix : Prefix, new()
        where TUnit : ISiUnit, ITime, new()
    {
    }
}
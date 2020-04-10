using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Temperature<TPrefix, TUnit> : LinearSiMeasure<TPrefix, TUnit>, ITemperature
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, ITemperature, new()
    {
    }
}
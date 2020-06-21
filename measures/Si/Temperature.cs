using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Temperature<TPrefix, TUnit> : SiMeasure<Linear, PrefixedUnit<TPrefix, TUnit>>, ITemperature
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, ITemperature, new()
    {
    }
}
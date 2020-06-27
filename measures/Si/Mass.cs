using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Mass<TPrefix, TUnit> : SiMeasure<Linear, Si<TPrefix, TUnit>>, IMass
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, IMass, new()
    {
    }
}
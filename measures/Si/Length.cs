using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Length<TPrefix, TUnit> : LinearSiMeasure<TPrefix, TUnit>, ILength
        where TPrefix : Prefix, new()
        where TUnit : ISiUnit, ILength, new()
    {
    }
}
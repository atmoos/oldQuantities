using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;

namespace Quantities
{
    internal sealed class Length<TPrefix, TUnit> : LinearSiMeasure<TPrefix, TUnit>, ILength
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, ILength, new()
    {
    }
}
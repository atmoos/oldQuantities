using Quantities.Unit;
using Quantities.Unit.Transformation;
using Quantities.Prefixes;
using Quantities.Dimensions;
using Quantities.Measures.Other.Core;

namespace Quantities.Measures.Other
{
    internal sealed class Volume<TPrefix, TUnit> : LinearMeasure<TPrefix, TUnit>, IVolume
        where TPrefix : Prefix, new()
        where TUnit : IVolume, IUnit, ITransform, new()
    {
    }
}
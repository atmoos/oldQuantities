using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Volume<TLength> : CubicSiMeasure<TLength>, IVolume<TLength>
        where TLength : SiMeasure, ILength, new()
    {
    }
}
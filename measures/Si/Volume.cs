using Quantities.Dimensions;
using Quantities.Measures;

namespace Quantities
{
    internal sealed class Volume<TLength> : CubicSiMeasure<TLength>, IVolume<TLength>
        where TLength : SiMeasure, ILength, new()
    {
    }
}
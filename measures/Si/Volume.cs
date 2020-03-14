using Quantities.Dimensions;

namespace Quantities.Measures.Si
{
    internal sealed class Volume<TLength> : CubicSiMeasure<TLength>, IVolume<TLength>
        where TLength : SiMeasure, ILength, new()
    {
    }
}
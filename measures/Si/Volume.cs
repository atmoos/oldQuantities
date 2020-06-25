using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Volume<TLength> : SiMeasure<Cube, TLength>, IVolume<TLength>
        where TLength : ISiMeasure, ILength, new()
    {
    }
}
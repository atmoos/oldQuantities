using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Volume<TLength> : SiMeasure<Cube, TLength>, IVolume<TLength>
        where TLength : SiUnit, ILength, new()
    {
        public TLength LinearDimension => Pool<TLength>.Item;
    }
}
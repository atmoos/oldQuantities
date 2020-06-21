using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Area<TLength> : SiMeasure<Square, TLength>, IArea<TLength>
        where TLength : SiUnit, ILength, new()
    {
        public TLength LinearDimension => Pool<TLength>.Item;
    }
}
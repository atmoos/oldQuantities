using Quantities.Dimensions;
using Quantities.Measures;

namespace Quantities
{
    internal sealed class Area<TLength> : SquareSiMeasure<TLength>, IArea<TLength>
        where TLength : SiMeasure, ILength, new()
    {
    }
}
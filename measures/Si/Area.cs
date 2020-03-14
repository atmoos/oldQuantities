using Quantities.Dimensions;

namespace Quantities.Measures.Si
{
    internal sealed class Area<TLength> : SquareSiMeasure<TLength>, IArea<TLength>
        where TLength : SiMeasure, ILength, new()
    {
    }
}
using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Area<TLength> : SquareSiMeasure<TLength>, IArea<TLength>
        where TLength : SiMeasure, ILength, new()
    {
    }
}
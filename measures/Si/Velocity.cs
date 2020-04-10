using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Velocity<TLength, TTime> : SiDivide<TLength, Linear, TTime>, IVelocity<TLength, TTime>
        where TLength : SiMeasure, ILength, new()
        where TTime : SiMeasure, ITime, new()
    {
    }
}
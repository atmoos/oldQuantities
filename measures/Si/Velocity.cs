using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;

namespace Quantities.Measures.Si
{
    internal sealed class Velocity<TLength, TTime> : SiMeasure<Linear, Div<TLength, TTime>>, IVelocity<TLength, TTime>
        where TLength : SiUnit, ILength, new()
        where TTime : SiUnit, ITime, new()
    {
    }
}
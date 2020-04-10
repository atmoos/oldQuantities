using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Other.Core;

namespace Quantities.Measures.Other
{
    internal sealed class VelocityOf<TLength, TTime> : Divide<TLength, TTime>, IVelocity<TLength, TTime>
       where TLength : ILength, IUnit, ITransform, new()
       where TTime : ITime, IUnit, ITransform, new()
    {
    }
    internal sealed class SiVelocityOf<TLength, TTime> : Divide<SiWrapper<TLength>, TTime>, IVelocity<TLength, TTime>
       where TLength : SiMeasure, ILength, new()
       where TTime : ITime, IUnit, ITransform, new()
    {
    }
    internal sealed class VelocityOfSi<TLength, TTime> : Divide<TLength, SiWrapper<TTime>>, IVelocity<TLength, TTime>
        where TLength : ILength, IUnit, ITransform, new()
        where TTime : SiMeasure, ITime, new()
    {
    }
}
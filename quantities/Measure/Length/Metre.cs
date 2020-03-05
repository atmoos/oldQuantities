using Quantities.Unit;

using MetreUnit = Quantities.Unit.Si.Metre;

namespace Quantities.Measure.Length
{
    public sealed class Metre : Length, IMeasure<MetreUnit>
    {
        public MetreUnit Unit => Units<MetreUnit>.Unit;
    }
}
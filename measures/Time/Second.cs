using SecondUnit = Quantities.Unit.Si.Second;

namespace Quantities.Measure.Time
{
    public sealed class Second : Time, IMeasure<SecondUnit>
    {
        public SecondUnit Unit => Pool<SecondUnit>.Item;
    }
}
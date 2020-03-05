using Quantities.Unit;

namespace Quantities.Measure
{
    public interface IMeasure
    {

    }

    public interface IMeasure<out TUnit> : IMeasure
        where TUnit : IUnit
    {
        TUnit Unit { get; }
    }
}
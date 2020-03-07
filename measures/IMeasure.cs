using System;
using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public interface IMeasure : IDimension { }

    public interface ISiMeasure : IMeasure
    {
        Prefix Prefix { get; }
        SiUnit Unit { get; }
        Double Normalize(in Double value);
    }
    public interface ISiMeasure<out TPrefix, out TUnit> : ISiMeasure
        where TPrefix : Prefix
        where TUnit : SiUnit
    {
        new TPrefix Prefix { get; }
        new TUnit Unit { get; }
    }

    public interface INonSiMeasure<out TUnit> : IMeasure
        where TUnit : INonSiUnit
    {
        TUnit Unit { get; }
    }
}
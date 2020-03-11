using System;
using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SquareSiMeasure<TPrefix, TUnit> : SiMeasure<TPrefix, Square>
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly String REPRESENTATION = $"{PREFIX}{UNIT}²";
        public TUnit Unit => UNIT;

        public override String ToString() => REPRESENTATION;
    }
}
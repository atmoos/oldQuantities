using System;

namespace Quantities.Measures
{
    public abstract class SquareSiMeasure<TUnitSiMeasure> : SiMeasure
        where TUnitSiMeasure : SiMeasure, new()
    {
        private static readonly TUnitSiMeasure UNIT = Pool<TUnitSiMeasure>.Item;
        public TUnitSiMeasure UnitMeasure => UNIT;
        public override Double Normalize(in Double value)
        {
            return Math.Pow(UNIT.Normalize(in value), 2);
        }
        public override Double DeNormalize(in Double value)
        {
            return Math.Pow(UNIT.DeNormalize(in value), 2);
        }
        public override Double Scale<TOther>(in Double other)
        {
            return Math.Pow(UNIT.Scale<TOther>(in other), 2);
        }
    }
}
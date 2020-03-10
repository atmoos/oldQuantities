using System;
using Quantities.Prefixes;

namespace Quantities.Measures
{
    public abstract class SquareSiMeasure<TUnitSiMeasure> : SiMeasure
        where TUnitSiMeasure : SiMeasure, new()
    {
        private static readonly TUnitSiMeasure UNIT = Pool<TUnitSiMeasure>.Item;

        private static readonly String REPRESENTATION = $"{UNIT}²";
        internal override Prefix Anchor => UNIT.Anchor;
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
            return other * Math.Pow(UNIT.Scale<TOther>(1d), 2);
        }

        public override String ToString() => REPRESENTATION;
    }
}
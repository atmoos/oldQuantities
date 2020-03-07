using System;
using Quantities.Unit;
using Quantities.Prefixes;

namespace Quantities.Measures
{
    public abstract class SiMeasure<TPrefix, TUnit> : ISiMeasure, IScaler<ISiMeasure>
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly String REPRESENTATION = $"{PREFIX}{UNIT}";
        public Prefix Prefix => PREFIX;
        public SiUnit Unit => UNIT;
        public Double Normalize(in Double value) => PREFIX.Scale<UnitPrefix>(in value);
        public Double Scale<TOther>(in Double other) where TOther : ISiMeasure, new()
        {
            return Pool<TOther>.Item.Prefix.Scale<TPrefix>(in other);
        }

        public override String ToString() => REPRESENTATION;
    }
}
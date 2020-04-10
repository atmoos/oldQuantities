using System;
using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Measures.Core;

namespace Quantities.Measures.Other.Core
{
    internal abstract class LinearMeasure<TPrefix, TUnit> : IUnit, ITransform
        where TPrefix : Prefix, new()
        where TUnit : IUnit, ITransform, new()
    {
        private static readonly TPrefix PREFIX = Pool<TPrefix>.Item;
        private static readonly TUnit UNIT = Pool<TUnit>.Item;
        private static readonly String REPRESENTATION = $"{PREFIX}{UNIT}";
        public TPrefix Prefix => PREFIX;
        public TUnit Unit => UNIT;

        public override String ToString() => REPRESENTATION;
        public Double FromSi(in Double siValue)
        {
            return Scale<UnitPrefix, TPrefix, Linear>.Lift(UNIT.FromSi(in siValue));
        }
        public Double ToSi(in Double nonSiValue)
        {
            return UNIT.ToSi(Scale<TPrefix, UnitPrefix, Linear>.Lift(in nonSiValue));
        }
    }
}
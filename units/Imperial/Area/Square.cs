using System;
using Quantities.Dimensions;

namespace Quantities.Unit.Imperial.Area
{
    public sealed class Square<TUnit> : IImperial, IArea<TUnit>
        where TUnit : IImperial, ILength, new()
    {
        private static readonly TUnit LINEAR_UNIT = Pool<TUnit>.Item;
        private static readonly Double TO_SI = Math.Pow(LINEAR_UNIT.ToSi(1d), 2);
        private static readonly Double FROM_SI = Math.Pow(LINEAR_UNIT.FromSi(1d), 2);
        private static readonly String REPRESENTATION = $"sq {LINEAR_UNIT}";
        public TUnit LinearDimension => LINEAR_UNIT;
        public double FromSi(in Double siValue) => siValue * FROM_SI;
        public double ToSi(in Double nonSiValue) => nonSiValue * TO_SI;

        public override String ToString() => REPRESENTATION;
    }
}
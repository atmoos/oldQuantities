using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;

namespace Quantities
{
    public sealed class Time : ITime
    {
        public Double Value => Quantity.Value;
        public ITime Dimension => Quantity.Dimension;
        private Quantity<ITime> Quantity { get; }
        private Time(Quantity<ITime> quantity) => Quantity = quantity;
        public Time To<TUnit>()
            where TUnit : SiUnit, ITime, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public Time To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ITime, new()
        {
            return new Time(Quantity.To<SiTime<TPrefix, TUnit>>());
        }
        public Time ToNonSi<TUnit>()
            where TUnit : INonSiUnit, ITime, new()
        {
            return new Time(Quantity.ToNonSi<TUnit>());
        }
        public static Time Create<TUnit>(in Double value)
            where TUnit : SiUnit, ITime, new()
        {
            return Create<UnitPrefix, TUnit>(in value);
        }
        public static Time Create<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ITime, new()
        {
            return new Time(Quantity<ITime>.Si<SiTime<TPrefix, TUnit>>(in value));
        }
        public static Time CreateNonSi<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, ITime, new()
        {
            return new Time(Quantity<ITime>.NonSi<TNonSiUnit>(in value));
        }
        public static Time operator +(Time left, Time right)
        {
            return new Time(left.Quantity.Add(right.Quantity));
        }
        public static Time operator -(Time left, Time right)
        {
            return new Time(left.Quantity.Subtract(right.Quantity));
        }

        public override String ToString() => Quantity.ToString();
        private sealed class SiTime<TPrefix, TUnit> : SiMeasure<TPrefix, TUnit>, ITime
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ITime, new()
        {
        }
    }
}
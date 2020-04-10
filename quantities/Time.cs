using System;
using Quantities.Unit;
using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Time : IQuantity<ITime>, ITime, IEquatable<Time>, IFormattable
    {
        public Double Value => Quantity.Value;
        public ITime Dimension => Quantity.Dimension;
        internal Quantity<ITime> Quantity { get; }
        private Time(Quantity<ITime> quantity) => Quantity = quantity;
        public Time ToSeconds() => To<UnitPrefix, Second>();
        public Time To<TPrefix, TUnit>()
            where TPrefix : Prefix, IScaleDown, new()
            where TUnit : SiUnit, ITime, new()
        {
            return new Time(Quantity.To<Time<TPrefix, TUnit>>());
        }
        public Time To<TUnit>()
            where TUnit : SiDerivedUnit, ITime, new()
        {
            return new Time(Quantity.ToOther<TUnit>());
        }
        public TimeSpan ToTimeSpan() => TimeSpan.FromSeconds(ToSeconds().Value);
        public static Time Seconds(in Double value) => Si<UnitPrefix, Second>(in value);
        public static Time Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, IScaleDown, new()
            where TUnit : SiUnit, ITime, new()
        {
            return new Time(Quantity<ITime>.Si<Time<TPrefix, TUnit>>(in value));
        }
        public static Time SiDerived<TSiDerived>(Double value)
            where TSiDerived : SiDerivedUnit, ITime, new()
        {
            return new Time(Quantity<ITime>.Other<TSiDerived>(in value));
        }
        public static implicit operator Time(TimeSpan span) => Seconds(span.TotalSeconds);
        public static Time operator +(Time left, Time right)
        {
            return new Time(left.Quantity.Add(right.Quantity));
        }
        public static Time operator -(Time left, Time right)
        {
            return new Time(left.Quantity.Subtract(right.Quantity));
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Time other) => Quantity.Equals(other.Quantity);
    }
}
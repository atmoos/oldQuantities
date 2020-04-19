using System;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Length : IQuantity<ILength>, ILength, IEquatable<Length>, IFormattable
    {
        public Double Value => Quantity.Value;
        public ILength Dimension => Quantity.Dimension;
        internal Quantity<ILength> Quantity { get; }
        internal Length(Quantity<ILength> quantity) => Quantity = quantity;
        public Length To<TUnit>()
            where TUnit : SiUnit, ILength, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public Length To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity.To<Length<TPrefix, TUnit>>());
        }
        public Length ToImperial<TUnit>()
            where TUnit : IImperial, ILength, new()
        {
            return new Length(Quantity.ToOther<TUnit>());
        }
        public static Length Si<TUnit>(in Double value)
            where TUnit : SiUnit, ILength, new()
        {
            return Si<UnitPrefix, TUnit>(in value);
        }
        public static Length Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity<ILength>.Si<Length<TPrefix, TUnit>>(in value));
        }
        public static Length Imperial<TNonSiUnit>(Double value)
            where TNonSiUnit : IImperial, ILength, new()
        {
            return new Length(Quantity<ILength>.Other<TNonSiUnit>(in value));
        }
        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Quantity.Add(right.Quantity));
        }
        public static Length operator -(Length left, Length right)
        {
            return new Length(left.Quantity.Subtract(right.Quantity));
        }
        public static Area operator *(Length left, Length right)
        {
            return Area.Square(left.Quantity, right.Quantity);
        }
        public static Velocity operator /(Length distance, Time duration)
        {
            return Velocity.Create(distance, duration);
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Length other) => Quantity.Equals(other.Quantity);
    }
}
using System;
using Quantities.Unit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Mass : IQuantity<IMass>, IMass, IEquatable<Mass>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IMass Dimension => Quantity.Dimension;
        internal Quantity<IMass> Quantity { get; }
        internal Mass(Quantity<IMass> quantity) => Quantity = quantity;
        public Mass To<TUnit>()
            where TUnit : SiUnit, IMass, new()
        {
            return new Mass(Quantity.To<Mass<UnitPrefix, TUnit>>());
        }
        public Mass To<TPrefix, TUnit>()
            where TPrefix : Prefix, IScaleDown, new()
            where TUnit : SiDerivedUnit, IMass, new()
        {
            return new Mass(Quantity.To<Mass<TPrefix, TUnit>>());
        }
        public Mass ToImperial<TUnit>()
            where TUnit : IImperial, IMass, new()
        {
            return new Mass(Quantity.ToOther<TUnit>());
        }
        public static Mass Si<TUnit>(in Double value)
            where TUnit : SiUnit, IMass, new()
        {
            return new Mass(Quantity<IMass>.Si<Mass<UnitPrefix, TUnit>>(in value));
        }
        public static Mass Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, IScaleDown, new()
            where TUnit : SiDerivedUnit, IMass, new()
        {
            return new Mass(Quantity<IMass>.Si<Mass<TPrefix, TUnit>>(in value));
        }
        public static Mass Imperial<TNonSiUnit>(Double value)
            where TNonSiUnit : IImperial, IMass, new()
        {
            return new Mass(Quantity<IMass>.Other<TNonSiUnit>(in value));
        }
        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left.Quantity.Add(right.Quantity));
        }
        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left.Quantity.Subtract(right.Quantity));
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Mass other) => Quantity.Equals(other.Quantity);
    }
}
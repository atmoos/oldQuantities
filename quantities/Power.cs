using System;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Power : IQuantity<IPower>, IPower, IEquatable<Power>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IPower Dimension => Quantity.Dimension;
        internal Quantity<IPower> Quantity { get; }
        internal Power(Quantity<IPower> quantity) => Quantity = quantity;
        public Power To<TUnit>()
            where TUnit : SiUnit, IPower, new()
        {
            return new Power(Quantity.To<Power<UnitPrefix, TUnit>>());
        }
        public Power To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiDerivedUnit, IPower, new()
        {
            return new Power(Quantity.To<Power<TPrefix, TUnit>>());
        }
        public Power ToImperial<TUnit>()
            where TUnit : IImperial, IPower, new()
        {
            return new Power(Quantity.ToOther<TUnit>());
        }
        public static Power Si<TUnit>(in Double value)
            where TUnit : SiUnit, IPower, new()
        {
            return new Power(Quantity<IPower>.Si<Power<UnitPrefix, TUnit>>(in value));
        }
        public static Power Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiDerivedUnit, IPower, new()
        {
            return new Power(Quantity<IPower>.Si<Power<TPrefix, TUnit>>(in value));
        }
        public static Power Imperial<TNonSiUnit>(Double value)
            where TNonSiUnit : IImperial, IPower, new()
        {
            return new Power(Quantity<IPower>.Other<TNonSiUnit>(in value));
        }
        public static Power operator +(Power left, Power right)
        {
            return new Power(left.Quantity.Add(right.Quantity));
        }
        public static Power operator -(Power left, Power right)
        {
            return new Power(left.Quantity.Subtract(right.Quantity));
        }
        public static ElectricPotential operator /(Power power, ElectricCurrent current)
        {
            return ElectricPotential.Create(power, current);
        }
        public static ElectricCurrent operator /(Power power, ElectricPotential potential)
        {
            return ElectricCurrent.Create(power, potential);
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Power other) => Quantity.Equals(other.Quantity);
        internal static Power Create(ElectricCurrent current, ElectricPotential potential)
        {
            return null;
        }
    }
}
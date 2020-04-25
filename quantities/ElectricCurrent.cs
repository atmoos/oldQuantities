using System;
using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class ElectricCurrent : IQuantity<IElectricCurrent>, IElectricCurrent, IEquatable<ElectricCurrent>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IElectricCurrent Dimension => Quantity.Dimension;
        internal Quantity<IElectricCurrent> Quantity { get; }
        internal ElectricCurrent(Quantity<IElectricCurrent> quantity) => Quantity = quantity;
        public ElectricCurrent To<TUnit>()
            where TUnit : SiUnit, IElectricCurrent, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public ElectricCurrent To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IElectricCurrent, new()
        {
            return new ElectricCurrent(Quantity.To<ElectricCurrent<TPrefix, TUnit>>());
        }
        public static ElectricCurrent Si<TUnit>(in Double value)
            where TUnit : SiUnit, IElectricCurrent, new()
        {
            return Si<UnitPrefix, TUnit>(in value);
        }
        public static ElectricCurrent Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IElectricCurrent, new()
        {
            return new ElectricCurrent(Quantity<IElectricCurrent>.Si<ElectricCurrent<TPrefix, TUnit>>(in value));
        }
        public static ElectricCurrent operator +(ElectricCurrent left, ElectricCurrent right)
        {
            return new ElectricCurrent(left.Quantity.Add(right.Quantity));
        }
        public static ElectricCurrent operator -(ElectricCurrent left, ElectricCurrent right)
        {
            return new ElectricCurrent(left.Quantity.Subtract(right.Quantity));
        }
        public static ElectricPotential operator *(ElectricCurrent current, ElectricalResistance resistance)
        {
            return ElectricPotential.Create(current, resistance);
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(ElectricCurrent other) => Quantity.Equals(other.Quantity);
        internal static ElectricCurrent Create(ElectricPotential potential, ElectricalResistance resistance)
        {
            throw new NotImplementedException();
        }
    }
}
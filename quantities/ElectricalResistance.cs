using System;
using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class ElectricalResistance : IQuantity<IElectricalResistance>, IElectricalResistance, IEquatable<ElectricalResistance>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IElectricalResistance Dimension => Quantity.Dimension;
        internal Quantity<IElectricalResistance> Quantity { get; }
        internal ElectricalResistance(Quantity<IElectricalResistance> quantity) => Quantity = quantity;
        public ElectricalResistance To<TUnit>()
            where TUnit : SiUnit, IElectricalResistance, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public ElectricalResistance To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IElectricalResistance, new()
        {
            return new ElectricalResistance(Quantity.To<ElectricalResistance<TPrefix, TUnit>>());
        }
        public static ElectricalResistance Si<TUnit>(in Double value)
            where TUnit : SiUnit, IElectricalResistance, new()
        {
            return Si<UnitPrefix, TUnit>(in value);
        }
        public static ElectricalResistance Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IElectricalResistance, new()
        {
            return new ElectricalResistance(Quantity<IElectricalResistance>.Si<ElectricalResistance<TPrefix, TUnit>>(in value));
        }
        public static ElectricalResistance operator +(ElectricalResistance left, ElectricalResistance right)
        {
            return new ElectricalResistance(left.Quantity.Add(right.Quantity));
        }
        public static ElectricalResistance operator -(ElectricalResistance left, ElectricalResistance right)
        {
            return new ElectricalResistance(left.Quantity.Subtract(right.Quantity));
        }
        public static ElectricPotential operator *(ElectricalResistance resistance, ElectricCurrent current)
        {
            return ElectricPotential.Create(current, resistance);
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(ElectricalResistance other) => Quantity.Equals(other.Quantity);
    }
}
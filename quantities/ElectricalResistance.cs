using System;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;
using Quantities.Measures.Builder;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class ElectricalResistance : IQuantity<IElectricalResistance>, IElectricalResistance, IEquatable<ElectricalResistance>, IFormattable
    {
        private static ResistanceFactory _resistanceFactory = new ResistanceFactory();
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

        internal static ElectricalResistance Create(ElectricPotential potential, ElectricCurrent current)
        {
            var builder = new CompoundBuilder<IElectricPotential, IElectricCurrent, IElectricalResistance>(_resistanceFactory);
            return new ElectricalResistance(builder.Build(potential.Quantity, current.Quantity));
        }

        private sealed class ResistanceFactory : ICompoundFactory<IElectricPotential, IElectricCurrent, IElectricalResistance>, ISiQuantityBuilder<IElectricalResistance>
        {
            Quantity<IElectricalResistance> ISiQuantityBuilder<IElectricalResistance>.Create<TPrefix>(in Double value)
            {
                return Quantity<IElectricalResistance>.Si<ElectricalResistance<TPrefix, Ohm>>(in value);
            }

            Quantity<IElectricalResistance> ICompoundFactory<IElectricPotential, IElectricCurrent, IElectricalResistance>.CreateOther<TOtherA, TOtherB>(in Double a, in Double b)
            {
                throw new NotImplementedException();
            }

            Quantity<IElectricalResistance> ICompoundFactory<IElectricPotential, IElectricCurrent, IElectricalResistance>.CreateOtherSi<TOtherA, TSiB>(in Double a, in Double b)
            {
                throw new NotImplementedException();
            }
            Quantity<IElectricalResistance> ICompoundFactory<IElectricPotential, IElectricCurrent, IElectricalResistance>.CreateSi<TSiA, TSiB>(in Double a, in Double b)
            {
                return SiDivisor<TSiA, Linear, TSiB>.Divide(this, a / b);
            }

            Quantity<IElectricalResistance> ICompoundFactory<IElectricPotential, IElectricCurrent, IElectricalResistance>.CreateSiOther<TSiA, TOtherB>(in Double a, in Double b)
            {
                throw new NotImplementedException();
            }
        }
    }
}
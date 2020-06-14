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
    public sealed class ElectricPotential : IQuantity<IElectricPotential>, IElectricPotential, IEquatable<ElectricPotential>, IFormattable
    {
        private static PotentialFactory _potentialFactory = new PotentialFactory();
        public Double Value => Quantity.Value;
        public IElectricPotential Dimension => Quantity.Dimension;
        internal Quantity<IElectricPotential> Quantity { get; }
        internal ElectricPotential(Quantity<IElectricPotential> quantity) => Quantity = quantity;
        public ElectricPotential To<TUnit>()
            where TUnit : SiUnit, IElectricPotential, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public ElectricPotential To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IElectricPotential, new()
        {
            return new ElectricPotential(Quantity.To<ElectricPotential<TPrefix, TUnit>>());
        }
        public static ElectricPotential Si<TUnit>(in Double value)
            where TUnit : SiUnit, IElectricPotential, new()
        {
            return Si<UnitPrefix, TUnit>(in value);
        }
        public static ElectricPotential Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IElectricPotential, new()
        {
            return new ElectricPotential(Quantity<IElectricPotential>.Si<ElectricPotential<TPrefix, TUnit>>(in value));
        }
        public static ElectricPotential operator +(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left.Quantity.Add(right.Quantity));
        }
        public static ElectricPotential operator -(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left.Quantity.Subtract(right.Quantity));
        }
        public static ElectricCurrent operator /(ElectricPotential potential, ElectricalResistance resistance)
        {
            return ElectricCurrent.Create(potential, resistance);
        }
        public static ElectricalResistance operator /(ElectricPotential potential, ElectricCurrent current)
        {
            return ElectricalResistance.Create(potential, current);
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(ElectricPotential other) => Quantity.Equals(other.Quantity);
        internal static ElectricPotential Create(ElectricalResistance resistance, ElectricCurrent current)
        {
            var builder = new CompoundBuilder<IElectricalResistance, IElectricCurrent, IElectricPotential>(_potentialFactory);
            return new ElectricPotential(builder.Build(resistance.Quantity, current.Quantity));
        }

        private sealed class PotentialFactory : ICompoundFactory<IElectricalResistance, IElectricCurrent, IElectricPotential>, ISiQuantityBuilder<IElectricPotential>
        {
            Quantity<IElectricPotential> ISiQuantityBuilder<IElectricPotential>.Create<TPrefix>(in Double value)
            {
                return Quantity<IElectricPotential>.Si<ElectricPotential<TPrefix, Volt>>(in value);
            }
            Quantity<IElectricPotential> ICompoundFactory<IElectricalResistance, IElectricCurrent, IElectricPotential>.CreateOther<TOtherA, TOtherB>(in Double a, in Double b)
            {
                throw new NotImplementedException();
            }
            Quantity<IElectricPotential> ICompoundFactory<IElectricalResistance, IElectricCurrent, IElectricPotential>.CreateOtherSi<TOtherA, TSiB>(in Double a, in Double b)
            {
                throw new NotImplementedException();
            }
            Quantity<IElectricPotential> ICompoundFactory<IElectricalResistance, IElectricCurrent, IElectricPotential>.CreateSi<TSiA, TSiB>(in Double a, in Double b)
            {
                var builder = new InjectableBuilder<IElectricPotential>(this, a * b);
                SiMultiply<TSiA, Linear, TSiB>.Inject(builder);
                return builder.Build();
            }
            Quantity<IElectricPotential> ICompoundFactory<IElectricalResistance, IElectricCurrent, IElectricPotential>.CreateSiOther<TSiA, TOtherB>(in Double a, in Double b)
            {
                throw new NotImplementedException();
            }
        }
    }
}
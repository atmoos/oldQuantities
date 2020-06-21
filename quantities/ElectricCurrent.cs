using System;
using Quantities.Unit.Si;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Core;
using Quantities.Measures.Si.Core;
using Quantities.Measures.Builder;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class ElectricCurrent : IQuantity<IElectricCurrent>, IElectricCurrent, IEquatable<ElectricCurrent>, IFormattable
    {
        private static readonly CurrentFactory _currentFactory = new CurrentFactory();
        private static readonly PowerCurrentFactory _powerCurrentFactory = new PowerCurrentFactory();
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
            return ElectricPotential.Create(resistance, current);
        }
        public static Power operator *(ElectricCurrent current, ElectricPotential potential)
        {
            return Power.Create(current, potential);
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(ElectricCurrent other) => Quantity.Equals(other.Quantity);
        internal static ElectricCurrent Create(ElectricPotential potential, ElectricalResistance resistance)
        {
            var builder = new CompoundBuilder<IElectricPotential, IElectricalResistance, IElectricCurrent>(_currentFactory);
            return new ElectricCurrent(builder.Build(potential.Quantity, resistance.Quantity));
        }
        internal static ElectricCurrent Create(Power power, ElectricPotential potential)
        {
            var builder = new CompoundBuilder<IPower, IElectricPotential, IElectricCurrent>(_powerCurrentFactory);
            return new ElectricCurrent(builder.Build(power.Quantity, potential.Quantity));
        }
        private sealed class CurrentFactory : SiFactory<IElectricPotential, IElectricalResistance, IElectricCurrent>
        {
            public override Quantity<IElectricCurrent> Create<TPrefix>(in Double value)
            {
                return Quantity<IElectricCurrent>.Si<ElectricCurrent<TPrefix, Ampere>>(in value);
            }
            public override Quantity<IElectricCurrent> CreateSi<TSiA, TSiB>(in Double a, in Double b)
            {
                var builder = new InjectableBuilder<IElectricCurrent>(this, a / b);
                SiMeasure<Linear, Div<TSiA, TSiB>>.Inject(builder);
                return builder.Build();
            }
        }

        private sealed class PowerCurrentFactory : SiFactory<IPower, IElectricPotential, IElectricCurrent>
        {
            public override Quantity<IElectricCurrent> Create<TPrefix>(in Double value)
            {
                return Quantity<IElectricCurrent>.Si<ElectricCurrent<TPrefix, Ampere>>(in value);
            }
            public override Quantity<IElectricCurrent> CreateSi<TSiA, TSiB>(in Double a, in Double b)
            {
                var builder = new InjectableBuilder<IElectricCurrent>(this, a / b);
                SiMeasure<Linear, Div<TSiA, TSiB>>.Inject(builder);
                return builder.Build();
            }
        }
    }
}
using System;
using Quantities.Unit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;
using Quantities.Measures.Other;
using Quantities.Measures.Other.Core;

namespace Quantities
{
    public interface IVelocityBuilder
    {
        Velocity Per<TTimeUnit>()
            where TTimeUnit : SiDerivedUnit, ITime, new();
        Velocity Per<TTimePrefix, TTimeUnit>()
            where TTimePrefix : Prefix, new()
            where TTimeUnit : SiUnit, ITime, new();
        Velocity PerSecond() => Per<UnitPrefix, Second>();
    }
    public sealed class Velocity : IQuantity<IVelocity>, IVelocity, IEquatable<Velocity>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IVelocity Dimension => Quantity.Dimension;
        internal Quantity<IVelocity> Quantity { get; }
        private Velocity(Quantity<IVelocity> quantity) => Quantity = quantity;
        public IVelocityBuilder To<TUnit>()
            where TUnit : SiUnit, ILength, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public IVelocityBuilder To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Transformer<TPrefix, TUnit>(Quantity);
        }
        public IVelocityBuilder ToImperial<TImperialLength>()
            where TImperialLength : IImperial, ILength, new()
        {
            return new Transformer<TImperialLength>(Quantity);
        }
        public static IVelocityBuilder Si<TUnit>(in Double velocity)
            where TUnit : SiUnit, ILength, new()
        {
            return Si<UnitPrefix, TUnit>(in velocity);
        }
        public static IVelocityBuilder Si<TPrefix, TUnit>(in Double velocity)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Builder<TPrefix, TUnit>(in velocity);
        }
        public static IVelocityBuilder Imperial<TUnit>(in Double velocity)
            where TUnit : IImperial, ILength, new()
        {
            return new Builder<TUnit>(in velocity);
        }
        public static Velocity CreateNonSi<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, IVelocity, new()
        {
            return new Velocity(Quantity<IVelocity>.Other<TNonSiUnit>(in value));
        }
        public static Velocity operator +(Velocity left, Velocity right)
        {
            return new Velocity(left.Quantity.Add(right.Quantity));
        }
        public static Velocity operator -(Velocity left, Velocity right)
        {
            return new Velocity(left.Quantity.Subtract(right.Quantity));
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Velocity other) => Quantity.Equals(other.Quantity);
        internal static Velocity Create(Length length, Time time)
        {
            var builder = new VelocityBuilder();
            length.Quantity.Inject(builder, builder);
            var (si, nonSi) = builder.Per;
            time.Quantity.Inject(si, nonSi);
            return new Velocity(builder.Build());
        }
        private sealed class Builder<TLengthPrefix, TLengthUnit> : IVelocityBuilder
            where TLengthPrefix : Prefix, new()
            where TLengthUnit : SiUnit, ILength, new()
        {
            private readonly Double _velocity;
            public Builder(in Double velocity) => _velocity = velocity;
            Velocity IVelocityBuilder.Per<TTimePrefix, TTimeUnit>()
            {
                return new Velocity(Quantity<IVelocity>.Si<Velocity<Length<TLengthPrefix, TLengthUnit>, Time<TTimePrefix, TTimeUnit>>>(_velocity));
            }
            Velocity IVelocityBuilder.Per<TTimeUnit>()
            {
                throw new NotImplementedException();
            }
        }
        private sealed class Transformer<TLengthPrefix, TLengthUnit> : IVelocityBuilder
            where TLengthPrefix : Prefix, new()
            where TLengthUnit : SiUnit, ILength, new()
        {
            private readonly Quantity<IVelocity> _self;
            public Transformer(Quantity<IVelocity> self) => _self = self;
            Velocity IVelocityBuilder.Per<TTimePrefix, TTimeUnit>()
            {
                return new Velocity(_self.To<Velocity<Length<TLengthPrefix, TLengthUnit>, Time<TTimePrefix, TTimeUnit>>>());
            }

            Velocity IVelocityBuilder.Per<TTimeUnit>()
            {
                throw new NotImplementedException();
            }
        }
        private sealed class Transformer<TImperialLength> : IVelocityBuilder
            where TImperialLength : IImperial, ILength, new()
        {
            private readonly Quantity<IVelocity> _self;
            public Transformer(Quantity<IVelocity> self) => _self = self;

            Velocity IVelocityBuilder.Per<TTimeUnit>()
            {
                return new Velocity(_self.ToOther<VelocityOf<TImperialLength, TTimeUnit>>());
            }
            Velocity IVelocityBuilder.Per<TTimePrefix, TTimeUnit>()
            {
                return new Velocity(_self.ToOther<VelocityOfSi<TImperialLength, Time<TTimePrefix, TTimeUnit>>>());
            }
        }
        private sealed class Builder<TImperialUnit> : IVelocityBuilder
            where TImperialUnit : IImperial, ILength, new()
        {
            private readonly Double _velocity;
            public Builder(in Double velocity) => _velocity = velocity;
            Velocity IVelocityBuilder.Per<TTimePrefix, TTimeUnit>()
            {
                return new Velocity(Quantity<IVelocity>.Other<VelocityOfSi<TImperialUnit, Time<TTimePrefix, TTimeUnit>>>(_velocity));
            }
            Velocity IVelocityBuilder.Per<TTimeUnit>()
            {
                return new Velocity(Quantity<IVelocity>.Other<VelocityOf<TImperialUnit, TTimeUnit>>(_velocity));
            }
        }
    }
}
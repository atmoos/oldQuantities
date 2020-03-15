using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Velocity : IQuantity<IVelocity>, IVelocity
    {
        public Double Value => Quantity.Value;
        public IVelocity Dimension => Quantity.Dimension;
        internal Quantity<IVelocity> Quantity { get; }
        private Velocity(Quantity<IVelocity> quantity) => Quantity = quantity;
        public Velocity To<TUnit>()
            where TUnit : SiUnit, IVelocity, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public Velocity To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IVelocity, new()
        {
            throw new NotImplementedException();
        }
        public Velocity ToNonSi<TUnit>()
            where TUnit : INonSiUnit, IVelocity, new()
        {
            return new Velocity(Quantity.ToOther<TUnit>());
        }
        public static Velocity Create<TUnit>(in Double value)
            where TUnit : SiUnit, IVelocity, new()
        {
            return Create<UnitPrefix, TUnit>(in value);
        }
        public static Velocity Create<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, IVelocity, new()
        {
            throw new NotImplementedException();
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
        internal static Velocity Create(Length length, Time time)
        {
            var builder = new VelocityBuilder();
            length.Quantity.Inject(builder, builder);
            var (si, nonSi) = builder.Per;
            time.Quantity.Inject(si, nonSi);
            return new Velocity(builder.Build());
        }
    }
}
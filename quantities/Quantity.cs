using System;
using Quantities.Unit;
using Quantities.Dimensions;

namespace Quantities
{
    internal abstract class Quantity<TDimesion> : IInjector<TDimesion>, IScaler<TDimesion>
        where TDimesion : IDimension
    {
        public Double Value { get; }

        public abstract TDimesion Dimension { get; }

        private Quantity(in Double value) => Value = value;

        public abstract Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : SiUnit, TDimesion, IScaler<TDimesion>, new();


        public abstract Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            where TNonSiDimesion : INonSiUnit, IScaler<TDimesion>, TDimesion, new();

        public Quantity<TDimesion> Add(Quantity<TDimesion> other)
        {
            return With(Value + other.Scale(this));
        }
        public Quantity<TDimesion> Subtract(Quantity<TDimesion> other)
        {
            return With(Value - other.Scale(this));
        }
        public override String ToString() => $"{Value} {Dimension}";

        public abstract void InjectInto(IInjectable<TDimesion> injectable);
        public abstract Double Scale<TOther>(in Double other) where TOther : TDimesion, new();
        private protected abstract Quantity<TDimesion> With(in Double value);
        private protected abstract Double Scale(Quantity<TDimesion> other);
        public static Quantity<TDimesion> Si<TSiDimesion>(in Double value)
            where TSiDimesion : SiUnit, IScaler<TDimesion>, TDimesion, new()
        {
            return new SiQuantity<TSiDimesion>(in value);
        }
        public static Quantity<TDimesion> NonSi<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : INonSiUnit, TDimesion, new()
        {
            return new NonSiQuantity<TNonSiDimesion>(in value);
        }
        private sealed class SiQuantity<TSiDimesion> : Quantity<TDimesion>
            where TSiDimesion : SiUnit, IScaler<TDimesion>, TDimesion, new()
        {
            private static TSiDimesion DIMENSION = Pool<TSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public SiQuantity(in Double value) : base(in value) { }
            public override Quantity<TDimesion> To<TOtherSiDimesion>()
            {
                return new SiQuantity<TOtherSiDimesion>(Value);
            }
            public override Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            {
                var nonSiValue = Pool<TNonSiDimesion>.Item.FromSi(Value);
                return new NonSiQuantity<TNonSiDimesion>(nonSiValue);
            }
            public override void InjectInto(IInjectable<TDimesion> injectable) => injectable.Inject<TSiDimesion>();
            private protected override Quantity<TDimesion> With(in Double value) => new SiQuantity<TSiDimesion>(in value);
            private protected override Double Scale(Quantity<TDimesion> other) => other.Scale<TSiDimesion>(Value);
            public override Double Scale<TOther>(in Double other) => DIMENSION.Scale<TOther>(in other);
        }
        private sealed class NonSiQuantity<TNonSiDimesion> : Quantity<TDimesion>
            where TNonSiDimesion : INonSiUnit, IScaler<TDimesion>, TDimesion, new()
        {
            private static TNonSiDimesion DIMENSION = Pool<TNonSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public NonSiQuantity(in Double value) : base(in value) { }
            public override Quantity<TDimesion> To<TSiDimesion>()
            {
                return new SiQuantity<TSiDimesion>(DIMENSION.ToSi(Value));
            }
            public override Quantity<TDimesion> ToNonSi<TOtherNonSiDimesion>()
            {
                var siValue = DIMENSION.ToSi(Value);
                var otherNonSiValue = Pool<TOtherNonSiDimesion>.Item.FromSi(siValue);
                return new NonSiQuantity<TOtherNonSiDimesion>(in otherNonSiValue);
            }
            public override void InjectInto(IInjectable<TDimesion> injectable) => injectable.Inject<TNonSiDimesion>();
            private protected override Quantity<TDimesion> With(in Double value) => new NonSiQuantity<TNonSiDimesion>(in value);
            private protected override Double Scale(Quantity<TDimesion> other) => other.Scale<TNonSiDimesion>(Value);
            public override Double Scale<TOther>(in Double other) => DIMENSION.Scale<TOther>(in other);
        }
    }
}
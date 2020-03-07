using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures;

namespace Quantities
{
    internal abstract class Quantity<TDimesion> : IInjector<TDimesion>
        where TDimesion : IDimension
    {
        public Double Value { get; }
        public abstract TDimesion Dimension { get; }
        private Quantity(in Double value) => Value = value;

        public abstract Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : ISiMeasure, IScaler<ISiMeasure>, TDimesion, new();


        public abstract Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            where TNonSiDimesion : INonSiUnit, TDimesion, new();

        public override String ToString() => $"{Value} {Dimension}";

        public abstract void InjectInto(IInjectable<TDimesion> injectable);
        private protected abstract Quantity<TDimesion> With(in Double value);
        public static Quantity<TDimesion> Si<TSiDimesion>(in Double value)
            where TSiDimesion : ISiMeasure, IScaler<ISiMeasure>, TDimesion, new()
        {
            return new SiQuantity<TSiDimesion>(in value);
        }
        public static Quantity<TDimesion> NonSi<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : INonSiUnit, TDimesion, new()
        {
            return new NonSiQuantity<TNonSiDimesion>(in value);
        }
        private sealed class SiQuantity<TSiDimesion> : Quantity<TDimesion>
            where TSiDimesion : ISiMeasure, IScaler<ISiMeasure>, TDimesion, new()
        {
            private static TSiDimesion DIMENSION = Pool<TSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public SiQuantity(in Double value) : base(in value) { }
            public override Quantity<TDimesion> To<TOtherSiDimesion>()
            {
                var value = Value;
                value = Pool<TOtherSiDimesion>.Item.Scale<TSiDimesion>(in value);
                return new SiQuantity<TOtherSiDimesion>(value);
            }
            public override Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            {
                var nonSiValue = Pool<TNonSiDimesion>.Item.FromSi(Value);
                return new NonSiQuantity<TNonSiDimesion>(nonSiValue);
            }
            public override void InjectInto(IInjectable<TDimesion> injectable) => injectable.Inject<TSiDimesion>();
            private protected override Quantity<TDimesion> With(in Double value) => new SiQuantity<TSiDimesion>(in value);
        }
        private sealed class NonSiQuantity<TNonSiDimesion> : Quantity<TDimesion>
            where TNonSiDimesion : INonSiUnit, TDimesion, new()
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
        }
    }
}
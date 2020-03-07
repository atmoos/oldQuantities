using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures;

namespace Quantities
{
    internal abstract class Quantity<TDimesion> : IInjector<TDimesion>, IFormattable
        where TDimesion : IDimension
    {
        public Double Value { get; }
        public abstract TDimesion Dimension { get; }
        private Quantity(in Double value) => Value = value;
        public abstract Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : ISiMeasure, IScaler<ISiMeasure>, TDimesion, new();

        public abstract Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            where TNonSiDimesion : INonSiUnit, TDimesion, new();

        public Quantity<TDimesion> Add(Quantity<TDimesion> other)
        {
            var converted = this.Map(other);
            return With(Value + converted.Value);
        }
        public Quantity<TDimesion> Subtract(Quantity<TDimesion> other)
        {
            var converted = this.Map(other);
            return With(Value - converted.Value);
        }

        public override String ToString() => $"{Value:g5} {Dimension}";

        public String ToString(String format, IFormatProvider formatProvider)
        {
            return $"{Value.ToString(format, formatProvider)} {Dimension}";
        }

        public abstract void InjectInto(IInjectable<TDimesion> injectable);
        private protected abstract Quantity<TDimesion> With(in Double value);
        private protected abstract Quantity<TDimesion> Map(Quantity<TDimesion> other);
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
                var value = Pool<TOtherSiDimesion>.Item.Scale<TSiDimesion>(Value);
                return new SiQuantity<TOtherSiDimesion>(value);
            }
            public override Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            {
                var value = DIMENSION.Normalize(Value);
                var nonSiValue = Pool<TNonSiDimesion>.Item.FromSi(value);
                return new NonSiQuantity<TNonSiDimesion>(nonSiValue);
            }
            public override void InjectInto(IInjectable<TDimesion> injectable) => injectable.Inject<TSiDimesion>();
            private protected override Quantity<TDimesion> With(in Double value) => new SiQuantity<TSiDimesion>(in value);

            private protected override Quantity<TDimesion> Map(Quantity<TDimesion> other)
            {
                return other.To<TSiDimesion>();
            }
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

            private protected override Quantity<TDimesion> Map(Quantity<TDimesion> other)
            {
                return other.ToNonSi<TNonSiDimesion>();
            }
        }
    }
}
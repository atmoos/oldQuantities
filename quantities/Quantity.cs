using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures;

using IConvert = Quantities.Unit.Conversion.IConvertible;

namespace Quantities
{
    internal abstract class Quantity<TDimesion> : IInjector<TDimesion>, IFormattable
        where TDimesion : IDimension
    {
        public Double Value { get; }
        public abstract TDimesion Dimension { get; }
        private Quantity(in Double value) => Value = value;
        public abstract Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : SiMeasure, TDimesion, new();

        public abstract Quantity<TDimesion> ToOther<TNonSiDimesion>()
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new();

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
        protected abstract Quantity<TDimesion> With(in Double value);
        protected abstract Quantity<TDimesion> Map(Quantity<TDimesion> other);
        public static Quantity<TDimesion> Si<TSiDimesion>(in Double value)
            where TSiDimesion : SiMeasure, TDimesion, new()
        {
            return new SiQuantity<TSiDimesion>(in value);
        }
        public static Quantity<TDimesion> Other<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new()
        {
            return new OtherQuantity<TNonSiDimesion>(in value);
        }

        private sealed class SiQuantity<TSiDimesion> : Quantity<TDimesion>
            where TSiDimesion : SiMeasure, TDimesion, new()
        {
            private static TSiDimesion DIMENSION = Pool<TSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public SiQuantity(in Double value) : base(in value) { }
            public override Quantity<TDimesion> To<TOtherSiDimesion>()
            {
                var value = Pool<TOtherSiDimesion>.Item.Scale<TSiDimesion>(Value);
                return new SiQuantity<TOtherSiDimesion>(value);
            }
            public override Quantity<TDimesion> ToOther<TNonSiDimesion>()
            {
                var value = DIMENSION.Normalize(Value);
                var nonSiValue = Pool<TNonSiDimesion>.Item.FromSi(in value);
                return new OtherQuantity<TNonSiDimesion>(in nonSiValue);
            }
            public override void InjectInto(IInjectable<TDimesion> injectable) => injectable.Inject<TSiDimesion>();
            protected override Quantity<TDimesion> With(in Double value) => new SiQuantity<TSiDimesion>(in value);
            protected override Quantity<TDimesion> Map(Quantity<TDimesion> other)
            {
                return other.To<TSiDimesion>();
            }
        }
        private sealed class OtherQuantity<TNonSiDimesion> : Quantity<TDimesion>
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new()
        {
            private static TNonSiDimesion DIMENSION = Pool<TNonSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public OtherQuantity(in Double value) : base(in value) { }
            public override Quantity<TDimesion> To<TSiDimesion>()
            {
                var siBaseValue = DIMENSION.ToSi(Value);
                var deNormalizedValue = Pool<TSiDimesion>.Item.DeNormalize(in siBaseValue);
                return new SiQuantity<TSiDimesion>(in deNormalizedValue);
            }
            public override Quantity<TDimesion> ToOther<TOtherNonSiDimesion>()
            {
                var siValue = DIMENSION.ToSi(Value);
                var otherNonSiValue = Pool<TOtherNonSiDimesion>.Item.FromSi(in siValue);
                return new OtherQuantity<TOtherNonSiDimesion>(in otherNonSiValue);
            }
            public override void InjectInto(IInjectable<TDimesion> injectable) => injectable.Inject<TNonSiDimesion>();
            protected override Quantity<TDimesion> With(in Double value) => new OtherQuantity<TNonSiDimesion>(in value);
            protected override Quantity<TDimesion> Map(Quantity<TDimesion> other)
            {
                return other.ToOther<TNonSiDimesion>();
            }
        }
    }
}
using System;
using Quantities.Unit;
using Quantities.Dimensions;

using IConvert = Quantities.Unit.Conversion.IConvertible;

namespace Quantities.Measures
{
    internal abstract class Quantity<TDimesion> : IEquatable<Quantity<TDimesion>>, IFormattable
        where TDimesion : IDimension
    {
        public Double Value { get; }
        public abstract TDimesion Dimension { get; }
        private Quantity(in Double value) => Value = value;
        public abstract Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : SiMeasure, IScaler<SiMeasure>, INormalize, TDimesion, new();

        public abstract Quantity<TDimesion> ToOther<TNonSiDimesion>()
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new();

        public Quantity<TDimesion> Add(Quantity<TDimesion> other)
        {
            return this.Eval(other, (self, other) => self + other);
        }
        public Quantity<TDimesion> Subtract(Quantity<TDimesion> other)
        {
            return this.Eval(other, (self, other) => self - other);
        }
        internal Double Multiply(Quantity<TDimesion> other, ISiInjectable<TDimesion> siInjectable, INonSiInjectable nonSiInjectable)
        {
            Inject(siInjectable, nonSiInjectable);
            return this.Eval(other, (self, other) => self * other).Value;
        }
        internal Double Divide(Quantity<TDimesion> other)
        {
            return this.Eval(other, (self, other) => self / other).Value;
        }
        internal abstract void Inject(ISiInjectable<TDimesion> siInjectable, INonSiInjectable nonSiInjectable);

        public Boolean Equals(Quantity<TDimesion> other)
        {
            const Double min = 1d - 2e-15;
            const Double max = 1d + 2e-15;
            var quotient = Divide(other);
            return min <= quotient && quotient <= max;
        }

        public override String ToString() => $"{Value:g5} {Dimension}";

        public String ToString(String format, IFormatProvider formatProvider)
        {
            return $"{Value.ToString(format, formatProvider)} {Dimension}";
        }
        protected abstract Quantity<TDimesion> Eval(Quantity<TDimesion> other, Func<Double, Double, Double> operation);
        public static Quantity<TDimesion> Si<TSiDimesion>(in Double value)
            where TSiDimesion : SiMeasure, IScaler<SiMeasure>, INormalize, TDimesion, new()
        {
            return new SiQuantity<TSiDimesion>(in value);
        }
        public static Quantity<TDimesion> Other<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new()
        {
            return new OtherQuantity<TNonSiDimesion>(in value);
        }
        private sealed class SiQuantity<TSiDimesion> : Quantity<TDimesion>
            where TSiDimesion : SiMeasure, IScaler<SiMeasure>, INormalize, TDimesion, new()
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
            protected override Quantity<TDimesion> Eval(Quantity<TDimesion> other, Func<Double, Double, Double> operation)
            {
                return new SiQuantity<TSiDimesion>(operation(Value, other.To<TSiDimesion>().Value));
            }
            internal override void Inject(ISiInjectable<TDimesion> siInjectable, INonSiInjectable _) => siInjectable.Inject<TSiDimesion>();
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
            protected override Quantity<TDimesion> Eval(Quantity<TDimesion> other, Func<Double, Double, Double> operation)
            {
                return new OtherQuantity<TNonSiDimesion>(operation(Value, other.ToOther<TNonSiDimesion>().Value));
            }
            internal override void Inject(ISiInjectable<TDimesion> _, INonSiInjectable nonSiInjectable) => nonSiInjectable.Inject<TNonSiDimesion>();
        }
    }
}
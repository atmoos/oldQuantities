using System;
using Quantities.Unit;
using Quantities.Prefixes;
using Quantities.Dimensions;

namespace Quantities
{
    internal abstract class Quantity<TDimesion>
        where TDimesion : IDimension
    {
        public Double Value { get; }

        public abstract TDimesion Dimension { get; }

        private Quantity(in Double value) => Value = value;

        public abstract Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : SiUnit, TDimesion, new();


        public abstract Quantity<TDimesion> ToNonSi<TNonSiDimesion>()
            where TNonSiDimesion : INonSiUnit, TDimesion, new();

        public override String ToString() => $"{Value} {Dimension}";

        public static Quantity<TDimesion> Si<TSiDimesion>(in Double value)
            where TSiDimesion : SiUnit, TDimesion, new()
        {
            return new SiQuantity<TSiDimesion>(in value);
        }
        public static Quantity<TDimesion> NonSi<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : INonSiUnit, TDimesion, new()
        {
            return new NonSiQuantity<TNonSiDimesion>(in value);
        }

        private sealed class SiQuantity<TSiDimesion> : Quantity<TDimesion>
            where TSiDimesion : SiUnit, TDimesion, new()
        {
            private static TSiDimesion UNIT = Pool<TSiDimesion>.Item;
            public override TDimesion Dimension => UNIT;
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
        }
        private sealed class NonSiQuantity<TNonSiDimesion> : Quantity<TDimesion>
            where TNonSiDimesion : INonSiUnit, TDimesion, new()
        {
            private static TNonSiDimesion UNIT = Pool<TNonSiDimesion>.Item;
            public override TDimesion Dimension => UNIT;
            public NonSiQuantity(in Double value) : base(in value) { }
            public override Quantity<TDimesion> To<TSiDimesion>()
            {
                return new SiQuantity<TSiDimesion>(UNIT.ToSi(Value));
            }
            public override Quantity<TDimesion> ToNonSi<TOtherNonSiDimesion>()
            {
                var siValue = UNIT.ToSi(Value);
                var otherNonSiValue = Pool<TOtherNonSiDimesion>.Item.FromSi(siValue);
                return new NonSiQuantity<TOtherNonSiDimesion>(in otherNonSiValue);
            }
        }
    }
}
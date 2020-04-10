using System;
using Quantities.Unit;
using Quantities.Dimensions;

namespace Quantities.Measures.Core
{
    internal abstract class Kernel<TDimesion>
        where TDimesion : IDimension
    {
        public abstract TDimesion Dimension { get; }
        public abstract Double To<TSiDimesion>(in Double value)
            where TSiDimesion : SiMeasure, TDimesion, new();
        public abstract Double ToOther<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : IUnit, ITransform, TDimesion, new();
        public abstract Double Map(Kernel<TDimesion> other, in Double value);
        public abstract void Inject(in Double value, IInjectable<TDimesion> injectable);
        public static Kernel<TDimesion> Si<TSiDimesion>()
            where TSiDimesion : SiMeasure, TDimesion, new()
        {
            return Pool<SiKernel<TSiDimesion>>.Item;
        }
        public static Kernel<TDimesion> Other<TNonSiDimesion>()
            where TNonSiDimesion : IUnit, ITransform, TDimesion, new()
        {
            return Pool<OtherKernel<TNonSiDimesion>>.Item;
        }
        private sealed class SiKernel<TSiDimesion> : Kernel<TDimesion>
            where TSiDimesion : SiMeasure, TDimesion, new()
        {
            private static TSiDimesion DIMENSION = Pool<TSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public override Double To<TOtherSiDimesion>(in Double value)
            {
                return Pool<TOtherSiDimesion>.Item.Scale<TSiDimesion>(in value);
            }
            public override Double ToOther<TNonSiDimesion>(in Double value)
            {
                var normalizedSiValue = DIMENSION.Normalise(in value);
                return Pool<TNonSiDimesion>.Item.FromSi(in normalizedSiValue);
            }
            public override Double Map(Kernel<TDimesion> other, in Double value) => other.To<TSiDimesion>(in value);
            public override void Inject(in Double value, IInjectable<TDimesion> injectable) => injectable.Inject<TSiDimesion>(in value);
        }
        private sealed class OtherKernel<TNonSiDimesion> : Kernel<TDimesion>
            where TNonSiDimesion : IUnit, ITransform, TDimesion, new()
        {
            private static TNonSiDimesion DIMENSION = Pool<TNonSiDimesion>.Item;
            public override TDimesion Dimension => DIMENSION;
            public override Double To<TSiDimesion>(in Double value)
            {
                var siValue = DIMENSION.ToSi(in value);
                return Pool<TSiDimesion>.Item.Renormalise(in siValue);
            }
            public override Double ToOther<TOtherNonSiDimesion>(in Double value)
            {
                var siValue = DIMENSION.ToSi(value);
                return Pool<TOtherNonSiDimesion>.Item.FromSi(in siValue);
            }
            public override Double Map(Kernel<TDimesion> other, in Double value) => other.ToOther<TNonSiDimesion>(in value);
            public override void Inject(in Double value, IInjectable<TDimesion> injectable) => injectable.Inject<TNonSiDimesion>(in value);
        }
    }
}
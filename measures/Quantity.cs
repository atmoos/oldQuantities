using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures.Core;

using IConvert = Quantities.Unit.Conversion.IConvertible;

namespace Quantities.Measures
{
    public sealed class Quantity<TDimesion> : IEquatable<Quantity<TDimesion>>, IFormattable
        where TDimesion : IDimension
    {
        public Double Value { get; }
        public TDimesion Dimension => Kernel.Dimension;
        internal Kernel<TDimesion> Kernel { get; }
        private Quantity(Kernel<TDimesion> kernel, in Double value)
        {
            Value = value;
            Kernel = kernel;
        }
        public Quantity<TDimesion> To<TSiDimesion>()
            where TSiDimesion : SiMeasure, TDimesion, new()
        {
            return Si<TSiDimesion>(Kernel.To<TSiDimesion>(Value));
        }
        public Quantity<TDimesion> ToOther<TNonSiDimesion>()
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new()
        {
            return Other<TNonSiDimesion>(Kernel.ToOther<TNonSiDimesion>(Value));
        }
        public Quantity<TDimesion> Add(Quantity<TDimesion> other)
        {
            return new Quantity<TDimesion>(Kernel, Value + Kernel.Map(other));
        }
        public Quantity<TDimesion> Subtract(Quantity<TDimesion> other)
        {
            return new Quantity<TDimesion>(Kernel, Value - Kernel.Map(other));
        }
        internal void Multiply(Quantity<TDimesion> other, ISiInjectable<TDimesion> siInjectable, INonSiInjectable nonSiInjectable)
        {
            Kernel.Inject(Value * Kernel.Map(other), siInjectable, nonSiInjectable);
        }
        internal Double Divide(Quantity<TDimesion> other)
        {
            return Value / Kernel.Map(other);
        }
        internal void Inject(ISiInjectable<TDimesion> siInjectable, INonSiInjectable nonSiInjectable) => Kernel.Inject(Value, siInjectable, nonSiInjectable);

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
        public static Quantity<TDimesion> Si<TSiDimesion>(in Double value)
            where TSiDimesion : SiMeasure, TDimesion, new()
        {
            return new Quantity<TDimesion>(Kernel<TDimesion>.Si<TSiDimesion>(), value);
        }
        public static Quantity<TDimesion> Other<TNonSiDimesion>(in Double value)
            where TNonSiDimesion : IUnit, IConvert, TDimesion, new()
        {
            return new Quantity<TDimesion>(Kernel<TDimesion>.Other<TNonSiDimesion>(), value);
        }
    }
}
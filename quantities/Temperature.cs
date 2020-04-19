using System;
using Quantities.Unit.Si;
using Quantities.Unit.Si.Derived;
using Quantities.Unit.Other;
using Quantities.Unit.Imperial;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Temperature : IQuantity<ITemperature>, ITemperature, IEquatable<Temperature>, IFormattable
    {
        public Double Value => Quantity.Value;
        public ITemperature Dimension => Quantity.Dimension;
        internal Quantity<ITemperature> Quantity { get; }
        private Temperature(Quantity<ITemperature> quantity) => Quantity = quantity;
        public Temperature To<TUnit>()
            where TUnit : ISiUnit, ITemperature, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public Temperature To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : ISiUnit, ITemperature, new()
        {
            return new Temperature(Quantity.To<Temperature<TPrefix, TUnit>>());
        }
        public Temperature ToCelsius() => new Temperature(Quantity.ToOther<Celsius>());
        public Temperature ToImperial<TUnit>()
            where TUnit : IImperial, ITemperature, new()
        {
            return new Temperature(Quantity.ToOther<TUnit>());
        }
        public Temperature ToOther<TUnit>()
            where TUnit : IOther, ITemperature, new()
        {
            return new Temperature(Quantity.ToOther<TUnit>());
        }
        public static Temperature Si<TUnit>(in Double value)
            where TUnit : ISiUnit, ITemperature, new()
        {
            return Si<UnitPrefix, TUnit>(in value);
        }
        public static Temperature Si<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : ISiUnit, ITemperature, new()
        {
            return new Temperature(Quantity<ITemperature>.Si<Temperature<TPrefix, TUnit>>(in value));
        }
        public static Temperature Celsius(in Double value)
        {
            return new Temperature(Quantity<ITemperature>.Other<Celsius>(in value));
        }
        public static Temperature Imperial<TUnit>(Double value)
            where TUnit : IImperial, ITemperature, new()
        {
            return new Temperature(Quantity<ITemperature>.Other<TUnit>(in value));
        }
        public static Temperature Other<TUnit>(Double value)
            where TUnit : IOther, ITemperature, new()
        {
            return new Temperature(Quantity<ITemperature>.Other<TUnit>(in value));
        }
        public static Temperature operator +(Temperature left, Temperature right)
        {
            return new Temperature(left.Quantity.Add(right.Quantity));
        }
        public static Temperature operator -(Temperature left, Temperature right)
        {
            return new Temperature(left.Quantity.Subtract(right.Quantity));
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Temperature other) => Quantity.Equals(other.Quantity);
    }
}
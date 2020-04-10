using System;
using Quantities.Unit;
using Quantities.Unit.Imperial;
using Quantities.Unit.Imperial.Area;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Core;
using Quantities.Measures.Si;

namespace Quantities
{
    public sealed class Area : IQuantity<IArea>, IArea, IEquatable<Area>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IArea Dimension => Quantity.Dimension;
        internal Quantity<IArea> Quantity { get; }
        internal Area(Quantity<IArea> quantity) => Quantity = quantity;
        public Area ToSquare<TUnit>()
            where TUnit : SiUnit, ILength, new()
        {
            return ToSquare<UnitPrefix, TUnit>();
        }
        public Area ToSquare<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Area(Quantity.To<Area<Length<TPrefix, TUnit>>>());
        }
        public Area ToImperial<TUnit>()
            where TUnit : IImperial, IArea, new()
        {
            return new Area(Quantity.ToOther<TUnit>());
        }
        public Area ToSquareImperial<TLength>()
            where TLength : IImperial, ILength, new()
        {
            return new Area(Quantity.ToOther<Square<TLength>>());
        }
        public static Area Square<TUnit>(in Double value)
            where TUnit : SiUnit, ILength, new()
        {
            return Square<UnitPrefix, TUnit>(in value);
        }
        public static Area Square<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Area(Quantity<IArea>.Si<Area<Length<TPrefix, TUnit>>>(in value));
        }
        public static Area SquareImperial<TLength>(Double value)
            where TLength : IImperial, ILength, new()
        {
            return new Area(Quantity<IArea>.Other<Square<TLength>>(in value));
        }
        public static Area Imperial<TNonSiUnit>(Double value)
            where TNonSiUnit : IImperial, IArea, new()
        {
            return new Area(Quantity<IArea>.Other<TNonSiUnit>(in value));
        }
        public static Area operator +(Area left, Area right)
        {
            return new Area(left.Quantity.Add(right.Quantity));
        }
        public static Area operator -(Area left, Area right)
        {
            return new Area(left.Quantity.Subtract(right.Quantity));
        }
        public static Length operator /(Area area, Length length)
        {
            var builder = new Division(area.Quantity);
            length.Quantity.Inject(builder);
            return new Length(builder.Build());
        }
        public static Volume operator *(Area area, Length length) => Volume.Multiply(area.Quantity, length.Quantity);

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Area other) => Quantity.Equals(other.Quantity);
        internal static Area Square(Quantity<ILength> left, Quantity<ILength> right)
        {
            var builder = new Builder();
            left.Multiply(right, builder);
            return new Area(builder.Build());
        }

        private sealed class Builder : IBuilder<IArea>, IInjectable<ILength>
        {
            Quantity<IArea> _area;
            public Quantity<IArea> Build() => _area;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double value)
            {
                _area = Quantity<IArea>.Si<Area<TInjectedDimension>>(value);
            }
            void INonSiInjectable<ILength>.Inject<TUnit>(in Double value)
            {
                _area = Quantity<IArea>.Other<Square<TUnit>>(value);
            }
        }

        private sealed class Division : IBuilder<ILength>, IInjectable<ILength>
        {
            readonly Quantity<IArea> _area;
            Quantity<ILength> _length;
            public Division(Quantity<IArea> area) => _area = area;
            public Quantity<ILength> Build() => _length;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double length)
            {
                var area = _area.To<Area<TInjectedDimension>>();
                _length = Quantity<ILength>.Si<TInjectedDimension>(area.Value / length);
            }
            void INonSiInjectable<ILength>.Inject<TUnit>(in Double length)
            {
                var area = _area.ToOther<Square<TUnit>>();
                _length = Quantity<ILength>.Other<TUnit>(area.Value / length);
            }
        }
    }
}
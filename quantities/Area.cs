using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;

namespace Quantities
{
    public sealed class Area : IQuantity<IArea>, IArea
    {
        public Double Value => Quantity.Value;
        public IArea Dimension => Quantity.Dimension;
        internal Quantity<IArea> Quantity { get; }
        private Area(Quantity<IArea> quantity) => Quantity = quantity;
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
        public Area ToNonSi<TUnit>()
            where TUnit : INonSiUnit, IArea, new()
        {
            return new Area(Quantity.ToOther<TUnit>());
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
        public static Area CreateNonSi<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, IArea, new()
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
            return null;
        }

        public override String ToString() => Quantity.ToString();
        internal static Area Square(Quantity<ILength> left, Quantity<ILength> right)
        {
            var builder = new AreaBuilder();
            return builder.Build(left.Multiply(right, builder, builder));
        }

        private sealed class AreaBuilder : ISiInjectable<ILength>, INonSiInjectable
        {
            Func<Double, Quantity<IArea>> _builder;
            public Area Build(Double value)
            {
                return new Area(_builder(value));
            }

            void ISiInjectable<ILength>.Inject<TInjectedDimension>()
            {
                _builder = v => Quantity<IArea>.Si<Area<TInjectedDimension>>(v);
            }

            void INonSiInjectable.Inject<TUnit>()
            {
                throw new NotImplementedException();
            }
        }
    }
}
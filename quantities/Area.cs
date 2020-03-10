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
        private Area(Quantity<ILength> left, Quantity<ILength> right) => Quantity = Square(left, right);
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
            return new Area(Quantity.To<SiArea<TPrefix, TUnit>>());
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
            return new Area(Quantity<IArea>.Si<SiArea<TPrefix, TUnit>>(in value));
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
        private sealed class SiArea<TPrefix, TUnit> : SquareSiMeasure<Length.SiLength<TPrefix, TUnit>>, IArea
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
        }
        private static Quantity<IArea> Square(Quantity<ILength> left, Quantity<ILength> right)
        {
            return null;
        }
    }
}
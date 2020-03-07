using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;

namespace Quantities
{
    public sealed class Length : ILength
    {
        public Double Value => Quantity.Value;

        public ILength Dimension => Quantity.Dimension;

        private Quantity<ILength> Quantity { get; }

        private Length(Quantity<ILength> quantity) => Quantity = quantity;
        public Length To<TUnit>()
            where TUnit : SiUnit, ILength, new()
        {
            return To<UnitPrefix, TUnit>();
        }
        public Length To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity.To<SiLength<TPrefix, TUnit>>());
        }
        public Length ToNonSi<TUnit>()
            where TUnit : INonSiUnit, ILength, new()
        {
            return new Length(Quantity.ToNonSi<TUnit>());
        }

        public static Length Create<TUnit>(in Double value)
            where TUnit : SiUnit, ILength, new()
        {
            return Create<UnitPrefix, TUnit>(in value);
        }
        public static Length Create<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity<ILength>.Si<SiLength<TPrefix, TUnit>>(in value));
        }
        public static Length CreateNonSi<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, ILength, new()
        {
            return new Length(Quantity<ILength>.NonSi<TNonSiUnit>(in value));
        }

        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Quantity.Add(right.Quantity));
        }

        public static Length operator -(Length left, Length right)
        {
            return new Length(left.Quantity.Subtract(right.Quantity));
        }

        public override String ToString() => Quantity.ToString();
        private sealed class SiLength<TPrefix, TUnit> : SiMeasure<TPrefix, TUnit>, ILength
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
        }
    }
}
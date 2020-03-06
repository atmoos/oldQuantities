using System;
using Quantities.Unit;
using Quantities.Unit.Compound;
using Quantities.Dimensions;
using Quantities.Prefixes;

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
            return new Length(Quantity.To<TUnit>());
        }
        public Length To<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity.To<LengthUnit<TPrefix, TUnit>>());
        }
        public Length ToNonSi<TUnit>()
            where TUnit : INonSiUnit, ILength, new()
        {
            return new Length(Quantity.ToNonSi<TUnit>());
        }

        public static Length Create<TUnit>(in Double value)
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity<ILength>.Si<TUnit>(in value));
        }
        public static Length Create<TPrefix, TUnit>(Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(Quantity<ILength>.Si<LengthUnit<TPrefix, TUnit>>(in value));
        }
        public static Length CreateNonSi<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, ILength, new()
        {
            return new Length(Quantity<ILength>.NonSi<TNonSiUnit>(in value));
        }

        private sealed class LengthUnit<TPrefix, TUnit> : SiUnit, ILength
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            public override String ToString() => Pool<PrefixedUnit<TPrefix, TUnit>>.Item.ToString();
        }
    }
}
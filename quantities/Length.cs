using System;
using Quantities.Unit;
using Quantities.Unit.Compound;
using Quantities.Dimensions;
using Quantities.Prefixes;

namespace Quantities
{
    public sealed class Length : ILength
    {
        public Double Value { get; }

        public IUnit Dimension { get; }

        private Length(Double value, IUnit dimension)
        {
            Value = value;
            Dimension = dimension;
        }

        public Length Create<TUnit>(Double value)
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(value, Pool<TUnit>.Item);
        }
        public Length Create<TPrefix, TUnit>(Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Length(value, Pool<PrefixedUnit<TPrefix, TUnit>>.Item);
        }
        public Length CreateNonSi<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, ILength, new()
        {
            return new Length(value, Pool<TNonSiUnit>.Item);
        }
    }
}
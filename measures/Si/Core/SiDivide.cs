using System;
using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;

namespace Quantities.Measures.Si.Core
{
    internal abstract class SiDivide<TNominator, TDimension, TDenominator> : SiMeasure
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{Nominator}/{Denominator}";
        private static readonly Normaliser<TDimension> NORMALISER = Normalisers<TDimension>.Get(Nominator.Anchor.Exponent - Denominator.Anchor.Exponent);
        internal override Normaliser Anchor => NORMALISER;

        public override String ToString() => REPRESENTATION;
    }
    internal static class SiDivisor<TNominator, TDimension, TDenominator>
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly Normaliser<TDimension> NORMALISER = Normalisers<TDimension>.Get(Pool<TNominator>.Item.Anchor.Exponent - Pool<TDenominator>.Item.Anchor.Exponent);
        public static Quantity<TBase> Divide<TBase>(ISiQuantityBuilder<TBase> builder, in Double value)
            where TBase : IDimension
        {
            var build = new Builder<TBase>(ref builder, in value);
            NORMALISER.InjectPrefix(build);
            return build.Build();
        }
        private sealed class Builder<TBase> : IPrefixInjectable, IBuilder<TBase>
            where TBase : IDimension
        {
            readonly Double _value;
            readonly ISiQuantityBuilder<TBase> _builder;
            Quantity<TBase> _result;
            public Builder(ref ISiQuantityBuilder<TBase> builder, in Double value)
            {
                _value = value;
                _builder = builder;
            }
            public Quantity<TBase> Build() => _result;
            void IPrefixInjectable.Inject<TPrefix>()
            {
                _result = _builder.Create<TPrefix>(_value);
            }
        }
    }
}
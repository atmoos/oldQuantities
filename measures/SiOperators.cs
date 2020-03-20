using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public class SiDivide<TNominator, TDimension, TDenominator> : SiMeasure<TDimension>
        where TNominator : SiMeasure, new()
        where TDimension : Dimension, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{Nominator}/{Denominator}";
        private static readonly Normaliser<TDimension> Normaliser = OperatorPool<TDimension>.Get(Nominator.Anchor.Exponent - Denominator.Anchor.Exponent);
        internal override Prefix Anchor => Normaliser.Prefix;

        public override String ToString() => REPRESENTATION;
        internal override Double DeNormalize<TDim>(in Double value) => Normaliser.DeNormalize(in value);
        internal override Double Normalize<TDim>(in Double value) => Normaliser.Normalize(in value);
        internal override void InjectPrefix(IPrefixInjectable injectable) => Normaliser.Inject(injectable);
        internal override Double Scale<TOther, TDim>(in Double value)
        {
            return 0;
        }
    }
}
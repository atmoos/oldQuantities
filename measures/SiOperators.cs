using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SiDivide<TNominator, TDenominator> : SiMeasure<Linear>
        where TNominator : SiMeasure, new()
        where TDenominator : SiMeasure, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{Nominator}/{Denominator}";
        private static readonly Operation Operation = OperatorPool.Get(Nominator.Anchor.Exponent - Denominator.Anchor.Exponent);
        internal override Prefix Anchor => Operation.Prefix;

        public override String ToString() => REPRESENTATION;
        internal override Double DeNormalize<TDim>(in Double value)
        {
            var nominator = Nominator.DeNormalize<TDim>(in value);
            var denominator = Denominator.DeNormalize<TDim>(1d);
            return nominator / denominator;
        }
        internal override Double Normalize<TDim>(in Double value)
        {
            var nominator = Nominator.Normalize<TDim>(in value);
            var denominator = Denominator.Normalize<TDim>(1d);
            return nominator / denominator;
        }
        internal override Double Scale<TOther, TDim>(in Double value)
        {
            var nominator = Nominator.Scale<TOther, TDim>(in value);
            var denominator = Denominator.Scale<TOther, TDim>(1d);
            return Operation.Op.Execute(nominator / denominator);
        }
    }
}
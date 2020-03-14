using System;
using Quantities.Prefixes;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Measures
{
    public abstract class SiTimes<TLeftOperand, TRightOperand> : SiMeasure, IScaler<SiMeasure>, INormalize
    {
        internal override Prefix Anchor => throw new NotImplementedException();
        public Double Normalize(in Double value)
        {
            throw new NotImplementedException();
        }
        public Double DeNormalize(in Double value)
        {
            throw new NotImplementedException();
        }
        public Double Scale<TOther>(in Double other) where TOther : SiMeasure, new()
        {
            throw new NotImplementedException();
        }
        internal override Double Normalize<TDim>(in Double value)
        {
            throw new NotImplementedException();
        }
        internal override Double DeNormalize<TDim>(in Double value)
        {
            throw new NotImplementedException();
        }
        internal override Double Scale<TOther, TDim>(in Double value)
        {
            throw new NotImplementedException();
        }
    }
}
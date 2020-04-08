using System;
using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures.Builder
{
    internal abstract class Builder<TDimension> : IBuilder<TDimension>
        where TDimension : IDimension
    {
        private protected Double Root { get; }
        private protected Quantity<TDimension> Quantity { get; set; }
        private protected Builder(in Double root) => Root = root;
        public Quantity<TDimension> Build() => Quantity;
    }
}
using System;
using Quantities.Dimensions;

namespace Quantities
{
    public interface IQuantity<out TDimension>
        where TDimension : IDimension
    {
        Double Value { get; }
        TDimension Dimension { get; }
    }
}
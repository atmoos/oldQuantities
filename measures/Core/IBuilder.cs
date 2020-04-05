using Quantities.Dimensions;

namespace Quantities.Measures.Core
{
    public interface IBuilder<TDimension>
        where TDimension : IDimension
    {
        Quantity<TDimension> Build();
    }
}
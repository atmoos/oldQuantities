namespace Quantities.Dimensions
{
    public interface IDimension { }
    public interface ILinear : IDimension { }
    public interface ISquare<out TDimension> : ITimes<TDimension, TDimension>
    where TDimension : ILinear
    {
        TDimension LinearDimension { get; }
    }
    public interface ICubic<out TDimension> : ITimes<ISquare<TDimension>, TDimension>
        where TDimension : ILinear
    {
        TDimension LinearDimension { get; }
    }
}
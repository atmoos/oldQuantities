namespace Quantities.Dimensions
{
    public interface IDimension { /* marker interface */ }
    public interface ILinear : IDimension { /* marker interface */ }
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
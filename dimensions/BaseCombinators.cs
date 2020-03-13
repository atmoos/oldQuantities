namespace Quantities.Dimensions
{
    public interface ITimes<out TLeft, out TRight> : IDimension
        where TLeft : IDimension
        where TRight : IDimension
    { }
    public interface IPer<out TNominator, out TDenominator> : IDimension
        where TNominator : IDimension
        where TDenominator : IDimension
    { }
    public interface ISquare<out TDimension> : ITimes<TDimension, TDimension>
        where TDimension : IDimension
    { }
    public interface ICubic<out TDimension> : ITimes<ITimes<TDimension, TDimension>, TDimension>
        where TDimension : IDimension
    { }
}
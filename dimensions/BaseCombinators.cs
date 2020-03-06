namespace Quantities.Dimensions
{
    public interface ITimes<TLeft, TRight> : IDimension
        where TLeft : IDimension
        where TRight : IDimension
    { }
    public interface IPer<TNominator, TDenominator> : IDimension
        where TNominator : IDimension
        where TDenominator : IDimension
    { }
    public interface ISquare<TDimension> : ITimes<TDimension, TDimension>
        where TDimension : IDimension
    { }
    public interface ICubic<TDimension> : ITimes<ITimes<TDimension, TDimension>, TDimension>
        where TDimension : IDimension
    { }
}
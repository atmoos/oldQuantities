namespace Quantities.Dimensions
{
    public interface IArea : IDimension { }
    public interface IArea<out TLength> : ISquare<TLength>, IArea
        where TLength : ILength
    { }
    public interface IVolume : IDimension { }
    public interface IVolume<out TLength> : ICubic<TLength>, IVolume
        where TLength : ILength
    { }

    public interface IVelocity : IDimension { }
    public interface IVelocity<out TLength, out TTime> : IPer<TLength, TTime>, IVelocity
        where TLength : ILength
        where TTime : ITime
    { }
}
namespace Quantities
{
    public interface IInjector<out TBase>
    {
        void InjectInto(IInjectable<TBase> injectable);
    }
}
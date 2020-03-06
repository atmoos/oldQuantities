namespace Quantities
{
    public interface IInjectable<in TBase>
    {
        void Inject<TInject>() where TInject : TBase, new();
    }
}
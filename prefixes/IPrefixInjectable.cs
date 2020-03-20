
namespace Quantities.Prefixes
{
    interface IPrefixInjectable
    {
        void Inject<TPrefix>() where TPrefix : Prefix, new();
    }
}
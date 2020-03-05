namespace Quantities
{
    internal static class Pool<TItem>
        where TItem : new()
    {
        static readonly TItem ITEM = new TItem();
        public static TItem Item => ITEM;
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

namespace Quantities.Prefixes
{
    internal static class PrefixPool
    {
        private static readonly Dictionary<Int32, Prefix> _pool;
        public static Prefix Get(Int32 exponent) => _pool[exponent];
        static PrefixPool()
        {
            var prefixes = new Prefix[]{
                Pool<Yotta>.Item,
                Pool<Zetta>.Item,
                Pool<Exa>.Item,
                Pool<Peta>.Item,
                Pool<Tera>.Item,
                Pool<Giga>.Item,
                Pool<Mega>.Item,
                Pool<Kilo>.Item,
                Pool<Hecto>.Item,
                Pool<Deca >.Item,
                Pool<UnitPrefix>.Item,
                Pool<Deci>.Item,
                Pool<Centi>.Item,
                Pool<Milli>.Item,
                Pool<Micro>.Item,
                Pool<Nano>.Item,
                Pool<Pico>.Item,
                Pool<Femto>.Item,
                Pool<Atto>.Item,
                Pool<Zepto>.Item,
                Pool<Yocto>.Item
            };
            _pool = prefixes.ToDictionary(p => p.Exponent);
        }
    }
}
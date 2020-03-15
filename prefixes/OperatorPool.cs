using System;
using System.Collections.Generic;

namespace Quantities.Prefixes
{
    internal static class OperatorPool
    {
        internal static Yotta Largest { get; } = Pool<Yotta>.Item;
        internal static Yocto Smallest { get; } = Pool<Yocto>.Item;

        internal static IEnumerable<Prefix> All { get; } = AllPrefixes();
        private static readonly Dictionary<Int32, Operation> _pool = CreatePool(AllPrefixes());
        public static Operation Get(Int32 exponent)
        {
            if(exponent > Largest.Exponent) {
                Double factor = Math.Pow(10, exponent - Largest.Exponent);
                return new Operation(new Multiply(factor), Largest);
            }
            if(exponent < Smallest.Exponent) {
                Double divisor = Math.Pow(10, Smallest.Exponent - exponent);
                return new Operation(new Divide(divisor), Smallest);
            }
            return _pool[exponent];
        }
        private static Dictionary<Int32, Operation> CreatePool(Prefix[] prefixes)
        {
            Prefix larger = null;
            var pool = new Dictionary<Int32, Operation>();
            for(Int32 index = 0; index < prefixes.Length - 1; ++index) {
                larger = prefixes[index + 1];
                Prefix smaller = prefixes[index];
                pool.Add(smaller.Exponent, new Operation(new NoOp(), smaller));
                for(Int32 exponent = smaller.Exponent + 1; exponent < larger.Exponent; ++exponent) {
                    Double factor = Math.Pow(10, larger.Exponent - smaller.Exponent);
                    pool.Add(exponent, new Operation(new Multiply(factor), smaller));
                }
            }
            pool.Add(larger.Exponent, new Operation(new NoOp(), larger));
            return pool;
        }
        private static Prefix[] AllPrefixes()
        {
            return new Prefix[]{
                Pool<Yocto>.Item,
                Pool<Zepto>.Item,
                Pool<Atto>.Item,
                Pool<Femto>.Item,
                Pool<Pico>.Item,
                Pool<Nano>.Item,
                Pool<Micro>.Item,
                Pool<Milli>.Item,
                Pool<Centi>.Item,
                Pool<Deci>.Item,
                Pool<UnitPrefix>.Item,
                Pool<Deca >.Item,
                Pool<Hecto>.Item,
                Pool<Kilo>.Item,
                Pool<Mega>.Item,
                Pool<Giga>.Item,
                Pool<Tera>.Item,
                Pool<Peta>.Item,
                Pool<Exa>.Item,
                Pool<Zetta>.Item,
                Pool<Yotta>.Item
            };
        }
    }
}
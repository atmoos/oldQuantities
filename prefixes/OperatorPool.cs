using System;
using System.Linq;
using System.Collections.Generic;
using Quantities.Prefixes.Dimensions;

namespace Quantities.Prefixes
{
    internal static class OperatorPool<TDimension>
        where TDimension : Dimension, new()
    {
        internal static Normaliser<TDimension> Largest { get; } = Normaliser<TDimension>.Create<Yotta>();
        internal static Normaliser<TDimension> Smallest { get; } = Normaliser<TDimension>.Create<Yocto>();
        internal static IEnumerable<Prefix> All { get; } = BaseNormalisers().Select(n => n.Prefix);
        private static readonly Dictionary<Int32, Normaliser<TDimension>> _pool = CreatePool(BaseNormalisers());
        public static Normaliser<TDimension> Get(Int32 exponent)
        {
            if(exponent > Largest.Prefix.Exponent) {
                Double factor = Math.Pow(10, exponent - Largest.Prefix.Exponent);
                return Largest.With(new Multiply(factor), new Divide(factor));
            }
            if(exponent < Smallest.Prefix.Exponent) {
                Double divisor = Math.Pow(10, Smallest.Prefix.Exponent - exponent);
                return Smallest.With(new Divide(divisor), new Multiply(divisor));
            }
            return _pool[exponent];
        }
        private static Dictionary<Int32, Normaliser<TDimension>> CreatePool(Normaliser<TDimension>[] baseNormalisers)
        {
            Normaliser<TDimension> larger = null;
            var pool = new Dictionary<Int32, Normaliser<TDimension>>();
            for(Int32 index = 0; index < baseNormalisers.Length - 1; ++index) {
                larger = baseNormalisers[index + 1];
                Normaliser<TDimension> baseNormaliser = baseNormalisers[index];
                pool.Add(baseNormaliser.Prefix.Exponent, baseNormaliser);
                for(Int32 exponent = baseNormaliser.Prefix.Exponent + 1; exponent < larger.Prefix.Exponent; ++exponent) {
                    Double factor = Math.Pow(10, larger.Prefix.Exponent - baseNormaliser.Prefix.Exponent);
                    pool.Add(exponent, baseNormaliser.With(new Multiply(factor), new Divide(factor)));
                }
            }
            pool.Add(larger.Prefix.Exponent, larger);
            return pool;
        }
        private static Normaliser<TDimension>[] BaseNormalisers()
        {
            return new Normaliser<TDimension>[]{
                Smallest,
                Normaliser<TDimension>.Create<Zepto>(),
                Normaliser<TDimension>.Create<Atto>(),
                Normaliser<TDimension>.Create<Femto>(),
                Normaliser<TDimension>.Create<Pico>(),
                Normaliser<TDimension>.Create<Nano>(),
                Normaliser<TDimension>.Create<Micro>(),
                Normaliser<TDimension>.Create<Milli>(),
                Normaliser<TDimension>.Create<Centi>(),
                Normaliser<TDimension>.Create<Deci>(),
                Normaliser<TDimension>.Create<UnitPrefix>(),
                Normaliser<TDimension>.Create<Deca >(),
                Normaliser<TDimension>.Create<Hecto>(),
                Normaliser<TDimension>.Create<Kilo>(),
                Normaliser<TDimension>.Create<Mega>(),
                Normaliser<TDimension>.Create<Giga>(),
                Normaliser<TDimension>.Create<Tera>(),
                Normaliser<TDimension>.Create<Peta>(),
                Normaliser<TDimension>.Create<Exa>(),
                Normaliser<TDimension>.Create<Zetta>(),
                Largest
            };
        }
    }
}
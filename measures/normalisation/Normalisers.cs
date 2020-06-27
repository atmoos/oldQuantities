using System;
using System.Collections.Generic;
using Quantities.Prefixes;

namespace Quantities.Measures.Normalisation
{
    internal static class Normalisers
    {
        internal static Normaliser Largest { get; } = Normaliser.Create<Yotta>();
        internal static Normaliser Smallest { get; } = Normaliser.Create<Yocto>();
        private static readonly Dictionary<Int32, Normaliser> _pool = CreatePool(BaseNormalisers());
        public static Normaliser Get(Int32 exponent)
        {
            if(exponent > Largest.Exponent) {
                Double factor = Math.Pow(10, exponent - Largest.Exponent);
                return Largest.With(new Multiply(factor), new Divide(factor));
            }
            if(exponent < Smallest.Exponent) {
                Double divisor = Math.Pow(10, Smallest.Exponent - exponent);
                return Smallest.With(new Divide(divisor), new Multiply(divisor));
            }
            return _pool[exponent];
        }
        private static Dictionary<Int32, Normaliser> CreatePool(Normaliser[] baseNormalisers)
        {
            Normaliser larger = null;
            var pool = new Dictionary<Int32, Normaliser>();
            for(Int32 index = 0; index < baseNormalisers.Length - 1; ++index) {
                larger = baseNormalisers[index + 1];
                Normaliser baseNormaliser = baseNormalisers[index];
                pool.Add(baseNormaliser.Exponent, baseNormaliser);
                for(Int32 exponent = baseNormaliser.Exponent + 1; exponent < larger.Exponent; ++exponent) {
                    Double factor = Math.Pow(10, larger.Exponent - baseNormaliser.Exponent);
                    pool.Add(exponent, baseNormaliser.With(new Multiply(factor), new Divide(factor)));
                }
            }
            pool.Add(larger.Exponent, larger);
            return pool;
        }
        private static Normaliser[] BaseNormalisers()
        {
            return new Normaliser[]{
                Smallest,
                Normaliser.Create<Zepto>(),
                Normaliser.Create<Atto>(),
                Normaliser.Create<Femto>(),
                Normaliser.Create<Pico>(),
                Normaliser.Create<Nano>(),
                Normaliser.Create<Micro>(),
                Normaliser.Create<Milli>(),
                Normaliser.Create<Centi>(),
                Normaliser.Create<Deci>(),
                Normaliser.Create<UnitPrefix>(),
                Normaliser.Create<Deca >(),
                Normaliser.Create<Hecto>(),
                Normaliser.Create<Kilo>(),
                Normaliser.Create<Mega>(),
                Normaliser.Create<Giga>(),
                Normaliser.Create<Tera>(),
                Normaliser.Create<Peta>(),
                Normaliser.Create<Exa>(),
                Normaliser.Create<Zetta>(),
                Largest
            };
        }
    }
}
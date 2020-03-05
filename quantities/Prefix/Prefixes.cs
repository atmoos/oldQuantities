using System;

namespace Quantities.Prefix
{
    static class Prefixes<TPrefix>
        where TPrefix : Prefix, new()
    {
        static readonly TPrefix PREFIX = new TPrefix();

        public static TPrefix Prefix => PREFIX;
    }
}
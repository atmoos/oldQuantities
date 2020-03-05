using System;
using Quantities.Prefixes;

namespace Quantities.Unit.Compound
{
    public sealed class PrefixedUnit<TPrefix, TUnit> : SiUnit
        where TPrefix : Prefix, new()
        where TUnit : SiUnit, new()
    {
        private static readonly String _representation = $"{Pool<TPrefix>.Item}{Pool<TUnit>.Item}";
        public TPrefix Prefix => Pool<TPrefix>.Item;
        public TUnit Unit => Pool<TUnit>.Item;
        public override String ToString() => _representation;
    }
}
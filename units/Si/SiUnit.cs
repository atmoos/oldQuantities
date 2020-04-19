using System;

namespace Quantities.Unit.Si
{
    public abstract class SiUnit : IUnit
    {
        internal abstract Int32 Offset { get; }
    }
}
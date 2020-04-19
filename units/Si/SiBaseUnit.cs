using System;

namespace Quantities.Unit.Si
{
    public abstract class SiBaseUnit : SiUnit
    {
        internal override Int32 Offset => 0;
    }
}
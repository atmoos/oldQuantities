using System;

namespace Quantities.Unit
{
    internal static class Units<TUnit>
        where TUnit : IUnit, new()
    {
        private static readonly TUnit UNIT = new TUnit();
        public static TUnit Unit => UNIT;
    }
}
using System;
using Quantities.Unit.Si;

namespace Quantities.Measures.Si.Core
{
    internal sealed class Mult<TNominator, TDenominator> : SiUnit
        where TNominator : SiUnit, new()
        where TDenominator : SiUnit, new()
    {
        private static readonly TNominator Nominator = Pool<TNominator>.Item;
        private static readonly TDenominator Denominator = Pool<TDenominator>.Item;
        internal override Int32 Offset => Nominator.Offset + Denominator.Offset;

        public override String ToString() => $"{Nominator}\u2009{Denominator}"; // U+2009 is thin space.
    }
}
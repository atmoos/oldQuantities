using System;

namespace Quantities.Measure.Combinators
{
    public abstract class Div<TNom, TDenom>
    {
        private readonly String _representation;
        internal TNom Nominator { get; }
        internal TNom Denominator { get; }
        internal Div(String sep)
        {
            _representation = $"{Nominator}{sep}{Denominator}";
        }
        public override String ToString() => _representation;
    }
}
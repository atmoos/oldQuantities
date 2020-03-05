using System;

namespace Quantities.Measure.Combinators
{
    public abstract class Mult<TLeft, TRight>
    {
        private readonly String _representation;
        internal TLeft Left { get; }
        internal TLeft Right { get; }
        internal Mult(String sep)
        {
            _representation = $"{Left}{sep}{Right}";
        }
        public override String ToString() => _representation;
    }
}
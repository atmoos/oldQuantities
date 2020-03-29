using System;
using Quantities.Unit;
using Quantities.Unit.Transformation;

namespace Quantities.Measures.Other.Core
{
    internal abstract class Divide<TNominator, TDenominator> : IUnit, ITransform
        where TNominator : IUnit, ITransform, new()
        where TDenominator : IUnit, ITransform, new()
    {
        private static readonly TNominator NOMINATOR = Pool<TNominator>.Item;
        private static readonly TDenominator DENOMINATOR = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{NOMINATOR}/{DENOMINATOR}";
        private static readonly Double TO_SI_DIVISOR = DENOMINATOR.ToSi(1d);
        private static readonly Double FROM_SI_DIVISOR = DENOMINATOR.FromSi(1d);

        public override String ToString() => REPRESENTATION;
        public Double FromSi(in Double siValue)
        {
            var nominator = NOMINATOR.FromSi(in siValue);
            return nominator / FROM_SI_DIVISOR;
        }
        public Double ToSi(in Double nonSiValue)
        {
            var nominator = NOMINATOR.ToSi(in nonSiValue);
            return nominator / TO_SI_DIVISOR;
        }
    }
}
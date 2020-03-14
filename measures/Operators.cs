using System;
using Quantities.Dimensions;

namespace Quantities.Measures
{
    public class Operator
    {
        private protected Operator() { }
    }

    public sealed class Times<TLeftOperand, TRightOperand> : ITimes<TLeftOperand, TRightOperand>
        where TLeftOperand : IDimension, new()
        where TRightOperand : IDimension, new()
    {
        private static readonly TLeftOperand LEFT = Pool<TLeftOperand>.Item;
        private static readonly TRightOperand RIGHT = Pool<TRightOperand>.Item;
        private static readonly String REPRESENTATION = $"{LEFT}*{RIGHT}";
        public TRightOperand RightOperand => RIGHT;
        public TLeftOperand LeftOperand => LEFT;

        public override String ToString() => REPRESENTATION;
    }

    public sealed class Per<TNominator, TDenominator> : IPer<TNominator, TDenominator>
    where TNominator : IDimension, new()
    where TDenominator : IDimension, new()
    {
        private static readonly TNominator NOMINATOR = Pool<TNominator>.Item;
        private static readonly TDenominator DENOMINATOR = Pool<TDenominator>.Item;
        private static readonly String REPRESENTATION = $"{NOMINATOR}/{DENOMINATOR}";
        public TNominator Nominator => Nominator;
        public TDenominator Denominator => DENOMINATOR;

        public override String ToString() => REPRESENTATION;
    }
}
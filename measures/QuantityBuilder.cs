using System;
using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures
{
    internal sealed class QuantityBuilder<TDimension> : IBuilder<TDimension>, IInjectable<TDimension>
        where TDimension : IDimension
    {
        private readonly Double _rootValue;
        private readonly Func<Double, Double, Double> _operator;
        private Quantity<TDimension> _result;
        public QuantityBuilder(in Double root, Func<Double, Double, Double> operation)
        {
            _rootValue = root;
            _operator = operation;
        }
        public Quantity<TDimension> Build() => _result;
        void ISiInjectable<TDimension>.Inject<TInjectedDimension>(in Double value)
        {
            _result = Quantity<TDimension>.Si<TInjectedDimension>(_operator(_rootValue, value));
        }
        void INonSiInjectable<TDimension>.Inject<TUnit>(in Double value)
        {
            _result = Quantity<TDimension>.Other<TUnit>(_operator(_rootValue, value));
        }
    }
}
using System;
using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures.Builder
{
    // This class is not thread safe!
    internal sealed class InjectableBuilder<TBase> : IPrefixInjectable, IBuilder<TBase>
        where TBase : IDimension
    {
        readonly Double _value;
        readonly ISiQuantityBuilder<TBase> _builder;
        Quantity<TBase> _result;
        public InjectableBuilder(ISiQuantityBuilder<TBase> builder, in Double value)
        {
            _value = value;
            _builder = builder;
        }
        public Quantity<TBase> Build() => _result;
        void IPrefixInjectable.Inject<TPrefix>() => _result = _builder.Create<TPrefix>(_value);
    }
}
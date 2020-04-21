using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures.Core;

namespace Quantities.Measures.Builder
{
    // This class is not thread safe!
    internal sealed class CompoundBuilder<TInA, TInB, TResult> : IInjectable<TInA>
        where TInA : IDimension
        where TInB : IDimension
        where TResult : IDimension
    {
        private readonly ICompoundFactory<TInA, TInB, TResult> _factory;
        private Quantity<TResult> _result;
        private IInjectable<TInB> _next;
        public CompoundBuilder(ICompoundFactory<TInA, TInB, TResult> factory) => _factory = factory;
        void ISiInjectable<TInA>.Inject<TInjectedDimension>(in Double inA)
        {
            _next = new SiBuilder<TInjectedDimension>(in inA, this);
        }
        void INonSiInjectable<TInA>.Inject<TUnit>(in Double inA)
        {
            _next = new OtherBuilder<TUnit>(in inA, this);
        }
        public Quantity<TResult> Build(Quantity<TInA> a, Quantity<TInB> b)
        {
            a.Inject(this);
            b.Inject(_next);
            return _result;
        }
        private void Set(Quantity<TResult> result) => _result = result;

        private sealed class SiBuilder<TIInA> : IInjectable<TInB>
            where TIInA : SiMeasure, TInA, new()
        {
            private readonly Double _a;
            private readonly CompoundBuilder<TInA, TInB, TResult> _parent;
            public SiBuilder(in Double a, CompoundBuilder<TInA, TInB, TResult> parent)
            {
                _a = a;
                _parent = parent;
            }
            void ISiInjectable<TInB>.Inject<TInjectedDimension>(in Double inB)
            {
                _parent.Set(_parent._factory.CreateSi<TIInA, TInjectedDimension>(in _a, inB));
            }
            void INonSiInjectable<TInB>.Inject<TUnit>(in Double inB)
            {
                _parent.Set(_parent._factory.CreateSiOther<TIInA, TUnit>(in _a, in inB));
            }
        }

        private sealed class OtherBuilder<TIInA> : IInjectable<TInB>
            where TIInA : TInA, IUnit, ITransform, new()
        {
            private readonly Double _a;
            private readonly CompoundBuilder<TInA, TInB, TResult> _parent;
            public OtherBuilder(in Double a, CompoundBuilder<TInA, TInB, TResult> parent)
            {
                _a = a;
                _parent = parent;
            }
            void INonSiInjectable<TInB>.Inject<TUnit>(in Double inB)
            {
                _parent.Set(_parent._factory.CreateOther<TIInA, TUnit>(in _a, in inB));
            }
            void ISiInjectable<TInB>.Inject<TInjectedDimension>(in Double inB)
            {
                _parent.Set(_parent._factory.CreateOtherSi<TIInA, TInjectedDimension>(in _a, in inB));
            }
        }
    }
}
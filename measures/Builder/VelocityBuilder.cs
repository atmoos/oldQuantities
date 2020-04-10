using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Measures.Core;
using Quantities.Measures.Si;
using Quantities.Measures.Other;

namespace Quantities.Measures.Builder
{
    internal class VelocityBuilder : IInjectable<ILength>, IBuilder<IVelocity>
    {
        IBuilder<IVelocity> _velocityBuilder;
        public IInjectable<ITime> Per { get; private set; }
        public Quantity<IVelocity> Build()
        {
            return _velocityBuilder.Build();
        }
        void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double length)
        {
            var builder = new SiVelocityBuilder<TInjectedDimension>(in length);
            _velocityBuilder = builder;
            Per = builder;
        }
        void INonSiInjectable<ILength>.Inject<TUnit>(in Double length)
        {
            var builder = new OtherVelocityBuilder<TUnit>(in length);
            _velocityBuilder = builder;
            Per = builder;
        }
        private sealed class SiVelocityBuilder<TLength> : Builder<IVelocity>, IInjectable<ITime>
            where TLength : SiMeasure, ILength, new()
        {
            public SiVelocityBuilder(in Double length) : base(in length) { }
            void ISiInjectable<ITime>.Inject<TInjectedDimension>(in Double time)
            {
                Quantity = Quantity<IVelocity>.Si<Velocity<TLength, TInjectedDimension>>(Root / time);
            }
            void INonSiInjectable<ITime>.Inject<TUnit>(in Double time)
            {
                Quantity = Quantity<IVelocity>.Other<SiVelocityOf<TLength, TUnit>>(Root / time);
            }
        }
        private sealed class OtherVelocityBuilder<TLength> : Builder<IVelocity>, IInjectable<ITime>
            where TLength : ILength, IUnit, ITransform, new()
        {
            public OtherVelocityBuilder(in Double length) : base(in length) { }
            void INonSiInjectable<ITime>.Inject<TUnit>(in Double time)
            {
                Quantity = Quantity<IVelocity>.Other<VelocityOf<TLength, TUnit>>(Root / time);
            }
            void ISiInjectable<ITime>.Inject<TInjectedDimension>(in Double time)
            {
                Quantity = Quantity<IVelocity>.Other<VelocityOfSi<TLength, TInjectedDimension>>(Root / time);
            }
        }
    }
}
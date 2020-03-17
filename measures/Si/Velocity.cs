using System;
using Quantities.Dimensions;

namespace Quantities.Measures.Si
{
    internal sealed class Velocity<TLength, TTime> : SiDivide<TLength, TTime>, IVelocity<TLength, TTime>
        where TLength : SiMeasure, ILength, new()
        where TTime : SiMeasure, ITime, new()
    {
    }

    internal interface IBuilder<TDimension>
        where TDimension : IDimension
    {
        Quantity<TDimension> Build();
    }
    internal sealed class SiVelocityBuilder<TLength> : IBuilder<IVelocity>, ISiInjectable<ITime>
        where TLength : SiMeasure, ILength, new()
    {
        private readonly Double _length;
        private Quantity<IVelocity> _velocity;
        public SiVelocityBuilder(in Double length) => _length = length;
        public Quantity<IVelocity> Build()
        {
            return _velocity;
        }
        public void Inject<TInjectedDimension>(in Double time) where TInjectedDimension : SiMeasure, ITime, new()
        {
            _velocity = Quantity<IVelocity>.Si<Velocity<TLength, TInjectedDimension>>(_length / time);
        }
    }
    internal class VelocityBuilder : ISiInjectable<ILength>, INonSiInjectable, IBuilder<IVelocity>
    {
        IBuilder<IVelocity> _velocityBuilder;
        public (ISiInjectable<ITime> si, INonSiInjectable nSi) Per { get; private set; }
        public Quantity<IVelocity> Build()
        {
            return _velocityBuilder.Build();
        }
        void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double length)
        {
            var builder = new SiVelocityBuilder<TInjectedDimension>(in length);
            _velocityBuilder = builder;
            Per = (builder, null);
        }

        void INonSiInjectable.Inject<TUnit>(in Double value)
        {
            throw new NotImplementedException();
        }
    }
}
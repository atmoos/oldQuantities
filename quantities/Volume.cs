using System;
using Quantities.Unit;
using Quantities.Unit.Imperial;
using Quantities.Unit.Imperial.Volume;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Core;
using Quantities.Measures.Si;
using Quantities.Measures.Other;

namespace Quantities
{
    public sealed class Volume : IQuantity<IVolume>, IVolume, IEquatable<Volume>, IFormattable
    {
        public Double Value => Quantity.Value;
        public IVolume Dimension => Quantity.Dimension;
        internal Quantity<IVolume> Quantity { get; }
        private Volume(Quantity<IVolume> quantity) => Quantity = quantity;
        public Volume ToCubic<TUnit>()
            where TUnit : SiUnit, ILength, new()
        {
            return ToCubic<UnitPrefix, TUnit>();
        }
        public Volume ToCubic<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Volume(Quantity.To<Volume<Length<TPrefix, TUnit>>>());
        }
        public Volume ToSi<TUnit>()
            where TUnit : SiDerivedUnit, IVolume, new()
        {
            return new Volume(Quantity.ToOther<TUnit>());
        }
        public Volume ToSi<TPrefix, TUnit>()
            where TPrefix : Prefix, new()
            where TUnit : SiDerivedUnit, IVolume, new()
        {
            return new Volume(Quantity.ToOther<Volume<TPrefix, TUnit>>());
        }
        public Volume ToImperial<TUnit>()
            where TUnit : IImperial, IVolume, new()
        {
            return new Volume(Quantity.ToOther<TUnit>());
        }
        public Volume ToCubicImperial<TImperialUnit>()
            where TImperialUnit : IImperial, ILength, new()
        {
            return new Volume(Quantity.ToOther<Cubic<TImperialUnit>>());
        }
        public static Volume Cubic<TUnit>(in Double value)
            where TUnit : SiUnit, ILength, new()
        {
            return Cubic<UnitPrefix, TUnit>(in value);
        }
        public static Volume Cubic<TPrefix, TUnit>(in Double value)
            where TPrefix : Prefix, new()
            where TUnit : SiUnit, ILength, new()
        {
            return new Volume(Quantity<IVolume>.Si<Volume<Length<TPrefix, TUnit>>>(in value));
        }
        public static Volume Si<TSiDerived>(Double value)
            where TSiDerived : SiDerivedUnit, IVolume, new()
        {
            return new Volume(Quantity<IVolume>.Other<TSiDerived>(in value));
        }
        public static Volume Si<TPrefix, TSiDerived>(Double value)
            where TPrefix : Prefix, new()
            where TSiDerived : SiDerivedUnit, IVolume, new()
        {
            return new Volume(Quantity<IVolume>.Other<Volume<TPrefix, TSiDerived>>(in value));
        }
        public static Volume Imperial<TImperialUnit>(Double value)
            where TImperialUnit : IImperial, IVolume, new()
        {
            return new Volume(Quantity<IVolume>.Other<TImperialUnit>(in value));
        }
        public static Volume CubicImperial<TImperialUnit>(Double value)
            where TImperialUnit : IImperial, ILength, new()
        {
            return new Volume(Quantity<IVolume>.Other<Cubic<TImperialUnit>>(in value));
        }
        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left.Quantity.Add(right.Quantity));
        }
        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left.Quantity.Subtract(right.Quantity));
        }
        public static Area operator /(Volume volume, Length length)
        {
            return null;
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Volume other) => Quantity.Equals(other.Quantity);
        internal static Volume Square(Quantity<ILength> left, Quantity<ILength> right)
        {
            var builder = new VolumeBuilder();
            left.Multiply(right, builder, builder);
            return new Volume(builder.Build());
        }
        private sealed class VolumeBuilder : IBuilder<IVolume>, ISiInjectable<ILength>, INonSiInjectable<ILength>
        {
            Quantity<IVolume> _volume;
            public Quantity<IVolume> Build() => _volume;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double value)
            {
                _volume = Quantity<IVolume>.Si<Volume<TInjectedDimension>>(value);
            }
            void INonSiInjectable<ILength>.Inject<TUnit>(in Double value)
            {
                throw new NotImplementedException();
            }
        }
    }
}
using System;
using Quantities.Unit;
using Quantities.Dimensions;
using Quantities.Prefixes;
using Quantities.Measures;
using Quantities.Measures.Core;
using Quantities.Measures.Si;

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
        public Volume ToNonSi<TUnit>()
            where TUnit : INonSiUnit, IVolume, new()
        {
            return new Volume(Quantity.ToOther<TUnit>());
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
        public static Volume Create<TNonSiUnit>(Double value)
            where TNonSiUnit : INonSiUnit, IVolume, new()
        {
            return new Volume(Quantity<IVolume>.Other<TNonSiUnit>(in value));
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
        private sealed class VolumeBuilder : IBuilder<IVolume>, ISiInjectable<ILength>, INonSiInjectable
        {
            Quantity<IVolume> _volume;
            public Quantity<IVolume> Build() => _volume;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double value)
            {
                _volume = Quantity<IVolume>.Si<Volume<TInjectedDimension>>(value);
            }
            void INonSiInjectable.Inject<TUnit>(in Double value)
            {
                throw new NotImplementedException();
            }
        }
    }
}
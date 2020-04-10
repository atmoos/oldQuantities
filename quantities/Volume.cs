using System;
using Quantities.Unit;
using Quantities.Unit.Imperial;
using Quantities.Unit.Imperial.Area;
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
            var division = new Division(volume.Quantity);
            length.Quantity.Inject(division);
            return new Area(division.Build());
        }

        public override String ToString() => Quantity.ToString();

        public String ToString(String format, IFormatProvider formatProvider) => Quantity.ToString(format, formatProvider);

        public Boolean Equals(Volume other) => Quantity.Equals(other.Quantity);
        internal static Volume Multiply(Quantity<IArea> area, Quantity<ILength> length)
        {
            var builder = new Multiplication(area);
            length.Inject(builder);
            return new Volume(builder.Build());
        }
        private sealed class Builder : IBuilder<IVolume>, IInjectable<ILength>
        {
            Quantity<IVolume> _volume;
            public Quantity<IVolume> Build() => _volume;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double value)
            {
                _volume = Quantity<IVolume>.Si<Volume<TInjectedDimension>>(value);
            }
            void INonSiInjectable<ILength>.Inject<TUnit>(in Double value)
            {
                _volume = Quantity<IVolume>.Other<Cubic<TUnit>>(in value);
            }
        }
        private sealed class Multiplication : IBuilder<IVolume>, IInjectable<ILength>
        {
            readonly Quantity<IArea> _area;
            Quantity<IVolume> _volume;
            public Multiplication(Quantity<IArea> area) => _area = area;
            public Quantity<IVolume> Build() => _volume;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double length)
            {
                var area = _area.To<Area<TInjectedDimension>>();
                _volume = Quantity<IVolume>.Si<Volume<TInjectedDimension>>(area.Value * length);
            }
            void INonSiInjectable<ILength>.Inject<TUnit>(in Double length)
            {
                var area = _area.ToOther<Square<TUnit>>();
                _volume = Quantity<IVolume>.Other<Cubic<TUnit>>(area.Value * length);
            }
        }
        private sealed class Division : IBuilder<IArea>, IInjectable<ILength>
        {
            readonly Quantity<IVolume> _volume;
            Quantity<IArea> _area;
            public Division(Quantity<IVolume> volume) => _volume = volume;
            public Quantity<IArea> Build() => _area;
            void ISiInjectable<ILength>.Inject<TInjectedDimension>(in Double length)
            {
                var volume = _volume.To<Volume<TInjectedDimension>>();
                _area = Quantity<IArea>.Si<Area<TInjectedDimension>>(volume.Value / length);
            }
            void INonSiInjectable<ILength>.Inject<TUnit>(in Double length)
            {
                var volume = _volume.ToOther<Cubic<TUnit>>();
                _area = Quantity<IArea>.Other<Square<TUnit>>(volume.Value / length);
            }
        }
    }
}
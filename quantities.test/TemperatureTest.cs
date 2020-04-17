using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Other.Temperature;
using Quantities.Unit.Imperial.Temperature;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    // For a lot of the values here, see: https://en.wikipedia.org/wiki/Conversion_of_units_of_temperature#Comparison_of_temperature_scales
    public sealed class TemperatureTest
    {
        private static Int32 ImperialTemperaturePrecision = ImperialPrecision - 1;
        [Fact]
        public void KelvinToString() => FormattingMatches(v => Temperature.Si<Kelvin>(v), "K");
        [Fact]
        public void CelsiusToString() => FormattingMatches(v => Temperature.Celsius(v), "°C");
        [Fact]
        public void DelisleToString() => FormattingMatches(v => Temperature.Other<Delisle>(v), "°De");
        [Fact]
        public void NewtonToString() => FormattingMatches(v => Temperature.Other<Newton>(v), "°N");
        [Fact]
        public void RéaumurToString() => FormattingMatches(v => Temperature.Other<Réaumur>(v), "°Ré");
        [Fact]
        public void RømerToString() => FormattingMatches(v => Temperature.Other<Rømer>(v), "°Rø");
        [Fact]
        public void FahrenheitToString() => FormattingMatches(v => Temperature.Imperial<Fahrenheit>(v), "°F");
        [Fact]
        public void RankineToString() => FormattingMatches(v => Temperature.Imperial<Rankine>(v), "°R");
        [Fact]
        public void GasMarkToString() => FormattingMatches(v => Temperature.Imperial<GasMark>(v), "GM");
        [Fact]
        public void AddThreeTemperatures()
        {
            var a = Temperature.Celsius(-40);
            var b = Temperature.Imperial<Fahrenheit>(-40);
            var c = Temperature.Si<Kelvin>(363.15);
            var expected = Temperature.Celsius(10);

            var actual = a + b + c;

            actual.Matches(expected);
        }
        [Fact]
        public void SubtractTemperatures()
        {
            var a = Temperature.Celsius(70);
            var b = Temperature.Si<Kelvin>(273.15 + 28);
            var expected = Temperature.Celsius(42);

            var actual = a - b;

            actual.Matches(expected);
        }

        [Fact]
        public void KelvinToCelsius()
        {
            var temperature = Temperature.Si<Kelvin>(36 + 273.15);
            var expected = Temperature.Celsius(36);

            var actual = temperature.ToCelsius();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToFahrenheit()
        {
            var temperature = Temperature.Si<Kelvin>(364);
            var expected = Temperature.Imperial<Fahrenheit>(195.53);

            var actual = temperature.ToImperial<Fahrenheit>();

            actual.Matches(expected);
        }
        [Fact]
        public void CelsiusToKelvin()
        {
            var temperature = Temperature.Celsius(312 - 273.15);
            var expected = Temperature.Si<Kelvin>(312);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void CelsiusToMilliKelvin()
        {
            var temperature = Temperature.Celsius(-273.13534324);
            var expected = Temperature.Si<Milli, Kelvin>(14.65676);

            var actual = temperature.To<Milli, Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void CelsiusToFahrenheit()
        {
            var temperature = Temperature.Celsius(37.0);
            var expected = Temperature.Imperial<Fahrenheit>(98.6);

            var actual = temperature.ToImperial<Fahrenheit>();

            actual.Matches(expected);
        }
        [Fact]
        public void FahrenheitToKelvin()
        {
            var temperature = Temperature.Imperial<Fahrenheit>(-40);
            var expected = Temperature.Si<Kelvin>(233.15);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void CelsiusToGasMark()
        {
            var temperature = Temperature.Celsius(218d + 1d / 3d);
            var expected = Temperature.Imperial<GasMark>(7);

            var actual = temperature.ToImperial<GasMark>();

            actual.Matches(expected, ImperialTemperaturePrecision);
        }

        [Fact]
        public void FahrenheitToGasMark()
        {
            var temperature = Temperature.Imperial<Fahrenheit>(350);
            var expected = Temperature.Imperial<GasMark>(4);

            var actual = temperature.ToImperial<GasMark>();

            actual.Matches(expected, ImperialTemperaturePrecision);
        }
        [Fact]
        public void GasMarkToFahrenheit()
        {
            var temperature = Temperature.Imperial<GasMark>(1);
            var expected = Temperature.Imperial<Fahrenheit>(275);

            var actual = temperature.ToImperial<Fahrenheit>();

            actual.Matches(expected);
        }
        [Fact]
        public void GasMarkToKelvin()
        {
            var temperature = Temperature.Imperial<GasMark>(1);
            var expected = Temperature.Si<Kelvin>(408.15);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToGasMark()
        {
            var temperature = Temperature.Si<Kelvin>(475);
            var expected = Temperature.Imperial<GasMark>(5.8132);

            var actual = temperature.ToImperial<GasMark>();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToRankine()
        {
            var temperature = Temperature.Si<Kelvin>(255.37);
            var expected = Temperature.Imperial<Rankine>(459.666);

            var actual = temperature.ToImperial<Rankine>();

            actual.Matches(expected);
        }
        [Fact]
        public void RankineToKelvin()
        {
            var temperature = Temperature.Imperial<Rankine>(671.64102);
            var expected = Temperature.Si<Kelvin>(373.1339);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void FahrenheitToRankine()
        {
            var temperature = Temperature.Imperial<Fahrenheit>(32);
            var expected = Temperature.Imperial<Rankine>(491.67);

            var actual = temperature.ToImperial<Rankine>();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToDelisle()
        {
            var temperature = Temperature.Si<Kelvin>(273.16);
            var expected = Temperature.Other<Delisle>(149.985);

            var actual = temperature.ToOther<Delisle>();

            actual.Matches(expected);
        }
        [Fact]
        public void DelisleToKelvin()
        {
            var temperature = Temperature.Other<Delisle>(176.67);
            var expected = Temperature.Si<Kelvin>(255.37);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToNewton()
        {
            var temperature = Temperature.Si<Kelvin>(373.15);
            var expected = Temperature.Other<Newton>(33);

            var actual = temperature.ToOther<Newton>();

            actual.Matches(expected);
        }
        [Fact]
        public void NewtonToKelvin()
        {
            var temperature = Temperature.Other<Newton>(0);
            var expected = Temperature.Si<Kelvin>(273.15);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToRéaumur()
        {
            var temperature = Temperature.Si<Kelvin>(1941);
            var expected = Temperature.Other<Réaumur>(1334.28);

            var actual = temperature.ToOther<Réaumur>();

            actual.Matches(expected);
        }
        [Fact]
        public void RéaumurToKelvin()
        {
            var temperature = Temperature.Other<Réaumur>(-14.22);
            var expected = Temperature.Si<Kelvin>(255.375);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
        [Fact]
        public void KelvinToRømer()
        {
            var temperature = Temperature.Si<Kelvin>(255.37);
            var expected = Temperature.Other<Rømer>(-1.8345);

            var actual = temperature.ToOther<Rømer>();

            actual.Matches(expected);
        }
        [Fact]
        public void RømerToKelvin()
        {
            var temperature = Temperature.Other<Rømer>(7.50525);
            var expected = Temperature.Si<Kelvin>(273.16);

            var actual = temperature.To<Kelvin>();

            actual.Matches(expected);
        }
    }
}
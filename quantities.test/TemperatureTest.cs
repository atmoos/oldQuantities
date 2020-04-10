using System;
using Xunit;
using Quantities.Unit.Si;
using Quantities.Unit.Imperial.Temperature;
using Quantities.Prefixes;

using static Quantities.Test.Metrics;

namespace Quantities.Test
{
    public sealed class TemperatureTest
    {
        [Fact]
        public void KelvinToString() => FormattingMatches(v => Temperature.Si<Kelvin>(v), "K");
        [Fact]
        public void CelsiusToString() => FormattingMatches(v => Temperature.Celsius(v), "°C");
        [Fact]
        public void FahrenheitToString() => FormattingMatches(v => Temperature.Imperial<Fahrenheit>(v), "°F");
        [Fact]
        public void KelvinToCelsius()
        {
            var temperature = Temperature.Si<Kelvin>(36 + 273.15);
            var expected = Temperature.Celsius(36);

            var actual = temperature.ToCelsius();

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
    }
}
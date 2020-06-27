using System;
using System.Collections.Generic;
using Xunit;
using Quantities.Prefixes;
using Quantities.Measures.Core;
using Quantities.Measures.Normalisation;


namespace Quantities.Measures.Test
{
    public sealed class NormalisersTest
    {
        [Fact]
        public void VeryLargeResultantExponentsMultiply()
        {
            var operation = Normalisers.Get(Normalisers.Largest.Exponent + 3);
            IsMultiply(operation);
        }
        [Fact]
        public void VeryLargeResultantExponentsAreSupported()
        {
            var leftOperand = new Exa();
            var rightOperand = new Tera();
            Int32 multiplication = leftOperand.Exponent + rightOperand.Exponent;
            var expectedScaleFactor = Math.Pow(10, multiplication - Normalisers.Largest.Exponent);
            var resultantOperator = Normalisers.Get(multiplication);
            Assert.Equal(Normalisers.Largest.Exponent, resultantOperator.Exponent);
        }
        [Fact]
        public void InBetweenScalingIsMultiplicative()
        {
            var leftOperand = new Kilo();
            var rightOperand = new Hecto();
            var multiplication = leftOperand.Exponent + rightOperand.Exponent;
            var operation = Normalisers.Get(multiplication);
            IsMultiply(operation);
        }
        [Fact]
        public void InBetweenScalingIsBasedOnLargerOfBothOperands()
        {
            var largerOperand = new Mega();
            var inBetweenPrefix = new Hecto();
            var expectedPrefix = new Mega();
            var multiplication = largerOperand.Exponent + inBetweenPrefix.Exponent;
            var operation = Normalisers.Get(multiplication);
            Assert.Equal(expectedPrefix.Exponent, operation.Exponent);
        }
        [Fact]
        public void AllPrefixExponentsHaveNoOpOperators()
        {
            var nonNoOps = new Dictionary<Prefix, Normaliser>();
            foreach(var prefix in Prefixes.Prefixes.All) {
                var operation = Normalisers.Get(prefix.Exponent);
                if(IsNoOp(operation)) {
                    continue;
                }
                nonNoOps.Add(prefix, operation);
            }
            Assert.Equal(Array.Empty<Prefix>(), nonNoOps.Keys);
        }
        [Fact]
        public void VerySmallResultantExponentsAreSupported()
        {
            // ToDo!
            var nominator = new Femto();
            var denominator = new Peta();
            var division = nominator.Exponent - denominator.Exponent;
            var expectedScaleFactor = Math.Pow(10, division - Normalisers.Smallest.Exponent);
            var resultantOperator = Normalisers.Get(division);
            Assert.Equal(Normalisers.Smallest.Exponent, resultantOperator.Exponent);
        }
        [Fact]
        public void VerySmallResultantExponentsDivide()
        {
            var operation = Normalisers.Get(Normalisers.Smallest.Exponent - 3);
            IsDivide(operation);
        }

        private static Boolean IsMultiply(Normaliser normaliser)
        {
            Double value = 2d;
            Double actual = normaliser.Normalise<Linear>(value);
            Double lower = Math.Pow(10, normaliser.Exponent + 1);
            Double upper = Math.Pow(10, normaliser.Exponent + 4);
            Assert.InRange(actual, lower, upper);
            return true;
        }
        private static Boolean IsDivide(Normaliser normaliser)
        {
            Double value = 2d;
            Double actual = normaliser.Normalise<Linear>(value);
            Double lower = Math.Pow(10, normaliser.Exponent - 4);
            Double upper = Math.Pow(10, normaliser.Exponent - 1);
            Assert.InRange(actual, lower, upper);
            return true;
        }
        private static Boolean IsNoOp(Normaliser normaliser)
        {
            Double actual = normaliser.Normalise<Linear>(1d);
            Double expected = Math.Pow(10, normaliser.Exponent);
            Assert.Equal(expected, actual);
            return true;
        }
    }
}

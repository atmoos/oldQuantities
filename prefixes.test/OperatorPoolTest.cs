using System;
using System.Collections.Generic;
using Xunit;
using Quantities.Prefixes;


namespace Quantities.Test
{
    public sealed class OperatorPoolTest
    {
        [Fact]
        public void VeryLargeResultantExponentsMultiply()
        {
            var operation = OperatorPool.Get(OperatorPool.Largest.Exponent + 5);
            Assert.IsType<Multiply>(operation.Op);
        }
        [Fact]
        public void VeryLargeResultantExponentsAreSupported()
        {
            var leftOperand = new Exa();
            var rightOperand = new Tera();
            Int32 multiplication = leftOperand.Exponent + rightOperand.Exponent;
            var expectedScaleFactor = Math.Pow(10, multiplication - OperatorPool.Largest.Exponent);
            var resultantOperator = OperatorPool.Get(multiplication);
            var actualScaleFactor = resultantOperator.Op.Execute(1d);
            Assert.Same(OperatorPool.Largest, resultantOperator.Prefix);
            Assert.Equal(expectedScaleFactor, actualScaleFactor);
        }
        [Fact]
        public void InBetweenScalingIsMultiplicative()
        {
            var leftOperand = new Kilo();
            var rightOperand = new Hecto();
            var multiplication = leftOperand.Exponent + rightOperand.Exponent;
            var operation = OperatorPool.Get(multiplication);
            Assert.IsType<Multiply>(operation.Op);
        }
        [Fact]
        public void InBetweenScalingIsBasedOnLargerOfBothOperands()
        {
            var largerOperand = new Mega();
            var inBetweenPrefix = new Hecto();
            var multiplication = largerOperand.Exponent + inBetweenPrefix.Exponent;
            var operation = OperatorPool.Get(multiplication);
            Assert.IsType<Mega>(operation.Prefix);
        }
        [Fact]
        public void AllPrefixExponentsHaveNoOpOperators()
        {
            var nonNoOps = new Dictionary<Prefix, Operator>();
            foreach(var prefix in OperatorPool.All) {
                var operation = OperatorPool.Get(prefix.Exponent);
                if(operation.Op is NoOp) {
                    continue;
                }
                nonNoOps.Add(prefix, operation.Op);
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
            var expectedScaleFactor = Math.Pow(10, division - OperatorPool.Smallest.Exponent);
            var resultantOperator = OperatorPool.Get(division);
            var actualScaleFactor = resultantOperator.Op.Execute(1d);
            Assert.Same(OperatorPool.Smallest, resultantOperator.Prefix);
            Assert.Equal(expectedScaleFactor, actualScaleFactor);
        }
        [Fact]
        public void VeryMallResultantExponentsDivide()
        {
            var operation = OperatorPool.Get(OperatorPool.Smallest.Exponent - 7);
            Assert.IsType<Divide>(operation.Op);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TtfAssignment.Core.Core;
using TtfAssignment.Core.Enums;
using TtfAssignment.Core.Strategies;

namespace TtfAssignment.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShouldBeStrategyS()
        {
            var inputs = new Input()
            {
                A = true,
                B = true,
                C = false,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new BaseMapping();

            var output = baseMapping.Calculate(inputs);

            Assert.AreEqual(output.X, ResultEnum.S);
        }

        [TestMethod]
        public void TestStrategySFormula()
        {
            var i = new Input()
            {
                A = true,
                B = true,
                C = false,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new BaseMapping();

            var output = baseMapping.Calculate(i);

            decimal expected = i.D + ( (i.D * i.E) / 100m); //3 + (3 * 4 / 100) = 3.12

            Assert.AreEqual(output.Y, expected);
        }

        [TestMethod]
        public void TestShouldBeStrategyR()
        {
            var inputs = new Input()
            {
                A = true,
                B = true,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new BaseMapping();

            var output = baseMapping.Calculate(inputs);

            Assert.AreEqual(output.X, ResultEnum.R);
        }

        [TestMethod]
        public void TestStrategyRFormula()
        {
            var i = new Input()
            {
                A = true,
                B = true,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new BaseMapping();

            var output = baseMapping.Calculate(i);

            decimal expected = i.D + (i.D * (i.E - i.F) / 100m); // 2.97

            Assert.AreEqual(output.Y, expected);
        }

        [TestMethod]
        public void TestShouldBeStrategyT()
        {
            var inputs = new Input()
            {
                A = false,
                B = true,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new BaseMapping();

            var output = baseMapping.Calculate(inputs);

            Assert.AreEqual(output.X, ResultEnum.T);
        }

        [TestMethod]
        public void TestStrategyTFormula()
        {
            var i = new Input()
            {
                A = false,
                B = true,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new BaseMapping();

            var output = baseMapping.Calculate(i);

            decimal expected = i.D - (i.D * i.F / 100m); // 2.85

            Assert.AreEqual(output.Y, expected);
        }

        [TestMethod]
        public void TestSpecialized1StrategyRFormula()
        {
            var i = new Input
            {
                A = true,
                B = true,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var mapping = new SpecializedMapping1();

            var output = mapping.Calculate(i);

            decimal expected = (2 * i.D) + (i.D * i.E / 100m); // 6.12

            Assert.AreEqual(output.Y, expected);
        }

        [TestMethod]
        public void TestUseSpecialized2AndStrategyShouldBeT()
        {
            var inputs = new Input()
            {
                A = true,
                B = true,
                C = false,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new SpecializedMapping2();

            var output = baseMapping.Calculate(inputs);

            Assert.AreEqual(output.X, ResultEnum.T);
        }

        [TestMethod]
        public void TestUseSpecialized2AndStrategyShouldBeS()
        {
            var inputs = new Input()
            {
                A = true,
                B = false,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new SpecializedMapping2();

            var output = baseMapping.Calculate(inputs);

            Assert.AreEqual(output.X, ResultEnum.S);
        }


        [TestMethod]
        public void TestSpecializedStrategySFormula()
        {
            var i = new Input
            {
                A = true,
                B = false,
                C = true,
                D = 3,
                E = 4,
                F = 5
            };

            var baseMapping = new SpecializedMapping2();

            var output = baseMapping.Calculate(i);

            decimal expected = i.F + i.D + (i.D * i.E / 100m); // 8.12

            Assert.AreEqual(output.Y, expected);
        }
    }
}

using System;
using NUnit.Framework;

namespace GCD.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(0, -5, ExpectedResult = 5)]
        [TestCase(15, 0, 5, ExpectedResult = 5)]
        [TestCase(0, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(3, 7, 2, 5, ExpectedResult = 1)]
        [TestCase(5, 15, 10, 100, ExpectedResult = 5)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(24, 368, 1024, ExpectedResult = 8)]
        public int GCDEuclidean_ValidNumbers_ReturnGCD(params int[] numbers)
        {
            return GCD.GCDEuclidean(numbers);
        }

        [Test]
        public void GCDEuclidean_MinValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.GCDEuclidean(int.MinValue, 0));
        }

        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(0, -5, ExpectedResult = 5)]
        [TestCase(15, 0, 5, ExpectedResult = 5)]
        [TestCase(0, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(3, 7, 2, 5, ExpectedResult = 1)]
        [TestCase(5, 15, 10, 100, ExpectedResult = 5)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(24, 368, 1024, ExpectedResult = 8)]
        public int GCDBinary_ValidNumbers_ReturnGCD(params int[] numbers)
        {
            return GCD.GCDBinary(numbers);
        }

        [Test]
        public void GCDBinary_MinValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.GCDBinary(int.MinValue, 0));
        }
    }
}

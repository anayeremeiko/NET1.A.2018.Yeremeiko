using System;
using NUnit.Framework;

namespace GCD.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(3, 7, 2, 5, ExpectedResult = 1)]
        [TestCase(5, 15, 10, 100, ExpectedResult = 5)]
        [TestCase(24, 368, 1024, 8, ExpectedResult = 8)]
        [TestCase(123456789, 987654321, 44444444, 581734090, 79254138, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue - 104, 48732198, 987154860, ExpectedResult = 1)]
        public int GCDEuclidean_ValidNumbers_ReturnGCD(params int[] numbers)
        {
            return GCD.GCDEuclidean(out _, numbers);
        }

        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(0, -5, ExpectedResult = 5)]
        [TestCase(0, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(1234567890, 44444444, ExpectedResult = 2)]
        [TestCase(65798329, 30000006, ExpectedResult = 1)]
        public int GCDEuclidean_ValidNumbers_ReturnGCD(int first, int second)
        {
            return GCD.GCDEuclidean(out _, first, second);
        }

        [TestCase(15, 0, 5, ExpectedResult = 5)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        public int GCDEuclidean_ValidNumbers_ReturnGCD(int first, int second, int third)
        {
            return GCD.GCDEuclidean(out _, first, second, third);
        }

        [Test]
        public void GCDEuclidean_MinValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.GCDEuclidean(out _, int.MinValue, 0));
        }

        [Test]
        public void GCDEuclidean_ThrowArgumentNullException()
        {
            int[] array = new int[0];

            Assert.Throws<ArgumentNullException>(() => GCD.GCDEuclidean(out _, array));
        }

        [TestCase(3, 7, 2, 5, ExpectedResult = 1)]
        [TestCase(5, 15, 10, 100, ExpectedResult = 5)]
        [TestCase(24, 368, 1024, ExpectedResult = 8)]
        [TestCase(123456789, 987654321, 44444444, 581734090, 79254138, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue - 104, 48732198, 987154860, ExpectedResult = 1)]
        public int GCDBinary_ValidNumbers_ReturnGCD(params int[] numbers)
        {
            return GCD.GCDBinary(out _, numbers);
        }

        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(0, -5, ExpectedResult = 5)]
        [TestCase(0, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(1234567890, 44444444, ExpectedResult = 2)]
        [TestCase(65798329, 30000006, ExpectedResult = 1)]
        public int GCDBinary_ValidNumbers_ReturnGCD(int first, int second)
        {
            return GCD.GCDBinary(out _, first, second);
        }

        [TestCase(15, 0, 5, ExpectedResult = 5)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        public int GCDBinary_ValidNumbers_ReturnGCD(int first, int second, int third)
        {
            return GCD.GCDBinary(out _, first, second, third);
        }

        [Test]
        public void GCDBinary_MinValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.GCDBinary(out _, int.MinValue, 0));
        }

        [Test]
        public void GCDBinary_ThrowArgumentNullException()
        {
            int[] array = new int[0];

            Assert.Throws<ArgumentNullException>(() => GCD.GCDBinary(out _, array));
        }
    }
}

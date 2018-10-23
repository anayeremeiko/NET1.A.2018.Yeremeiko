using System;
using NUnit.Framework;

namespace FindNumberLogic.Tests
{
    [TestFixture]
    public class NumberFinderTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        public int? FindNextBiggerNumber_ReturnNextBiggerNumber(int number)
        {
            return NumberFinder.FindNextBiggerNumber(number);
        }

        [TestCase(0)]
        [TestCase(-5780)]
        public void FindNextBiggerNumber_ThrowArgumentOutOfRangeException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberFinder.FindNextBiggerNumber(number));
        }

        [TestCase(10, ExpectedResult = null)]
        [TestCase(20, ExpectedResult = null)]
        [TestCase(1, ExpectedResult = null)]
        public int? FindNextBiggerNumber_ReturnNeg1(int number)
        {
            return NumberFinder.FindNextBiggerNumber(number);
        }
    }
}

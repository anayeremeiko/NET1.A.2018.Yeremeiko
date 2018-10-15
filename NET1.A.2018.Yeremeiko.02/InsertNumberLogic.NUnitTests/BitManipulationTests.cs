using System;
using NUnit.Framework;

namespace InsertNumberLogic.NUnitTests
{
    [TestFixture]
    public class BitManipulationTests
    {
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(15, 15, 1, 10, ExpectedResult = 31)]
        [TestCase(15, -15, 2, 6, ExpectedResult = 71)]
        [TestCase(-8, -15, 3, 8, ExpectedResult = -120)]
        [TestCase(-1, 8, 31, 31, ExpectedResult = int.MaxValue)]
        public int InsertNumber_Success(int destNum, int sourceNum, int i, int j)
        {
            return BitManipulation.InsertNumber(destNum, sourceNum, i, j);
        }

        [TestCase(8, 15, -1, 0)]
        [TestCase(8, 15, 32, 9)]
        [TestCase(8, 15, 0, -4)]
        [TestCase(8, 15, 0, 35)]
        public void InsertNumber_ThrowArgumentOutOfRangeException(int destNum, int sourceNum, int i, int j)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitManipulation.InsertNumber(destNum, sourceNum, i, j));
        }

        [Test]
        public void InsertNumber_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => BitManipulation.InsertNumber(8, 15, 5, 1));
        }
    }
}

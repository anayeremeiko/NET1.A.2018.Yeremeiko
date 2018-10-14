using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertNumberLogic.Tests
{
    [TestClass]
    public class BitManipulationTests
    {
        [TestMethod]
        public void InsertNumber_IBiggerThenJ_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitManipulation.InsertNumber(8, 15, 3, 1));
        }

        [TestMethod]
        public void InsertNumber_IBiggerThen31_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitManipulation.InsertNumber(8, 15, 40, 1));
        }

        [TestMethod]
        public void InsertNumber_ILessThen0_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitManipulation.InsertNumber(8, 15, -1, 1));
        }

        [TestMethod]
        public void InsertNumber_JBiggerThen31_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitManipulation.InsertNumber(8, 15, 3, 33));
        }

        [TestMethod]
        public void InsertNumber_JLessThen0_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitManipulation.InsertNumber(8, 15, 3, -1));
        }

        [TestMethod]
        public void InsertNumber_FirstBitIn8From15_Return9()
        {
            int expected = 9;
            int actual;
                
            actual = BitManipulation.InsertNumber(8, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_FirstBitIn15From15_Return15()
        {
            int expected = 15;
            int actual;
            
            actual = BitManipulation.InsertNumber(15, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_ManyBitsIn8From15_Return120()
        {
            int expected = 120;
            int actual;

            actual = BitManipulation.InsertNumber(8, 15, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_ManyBitsIn15From15_Return31()
        {
            int expected = 31;
            int actual;

            actual = BitManipulation.InsertNumber(15, 15, 1, 10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_FromNegNumToPosNum_Success()
        {
            int expected = 71;
            int actual;

            actual = BitManipulation.InsertNumber(15, -15, 2, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_FromNegNumToNegNum_Success()
        {
            int expected = -120;
            int actual;

            actual = BitManipulation.InsertNumber(-8, -15, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_LastBitInNeg1From8_ReturnMaxValue()
        {
            int expected = int.MaxValue;
            int actual;

            actual = BitManipulation.InsertNumber(-1, 8, 31, 31);

            Assert.AreEqual(expected, actual);
        }
    }
}

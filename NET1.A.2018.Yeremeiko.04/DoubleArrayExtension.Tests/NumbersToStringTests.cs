using System;
using NUnit.Framework;

namespace DoubleArrayExtension.Tests
{
    [TestFixture]
    public class NumbersToStringTests
    {
        [Test]
        public void TransformToWords_DoubleArray_ReturnStringArray()
        {
            string[] expected = { "minus one two three point four zero five ", "nine eight seven six five four point one two zero three " };

            string[] actual = NumbersToString.TransformToWords(-123.405, 987654.1203);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformToWords_ThrowArgumentNullException()
        {
            double[] array = { };

            Assert.Throws<ArgumentNullException>(() => NumbersToString.TransformToWords(array));
        }
    }
}

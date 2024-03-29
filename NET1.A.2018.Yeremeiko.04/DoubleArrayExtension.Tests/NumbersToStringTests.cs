﻿using System;
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

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleConverter(), -123.405, 987654.1203);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformDoubleArray_DoubleArray_ReturnStringArray()
        {
            string[] expected = { "minus one two three point four zero five ", "nine eight seven six five four point one two zero three " };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleConverter().Transform, -123.405, 987654.1203);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformToWords_SpecialValues_ReturnStringArray()
        {
            string[] expected = 
            {
                "not a number ",
                "negative infinity ",
                "positive infinity ",
                "minus one point seven nine seven six nine three one three four eight six two three two exponent plus three zero eight ",
                "one point seven nine seven six nine three one three four eight six two three two exponent plus three zero eight ",
                "zero "
            };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleConverter(), double.NaN, double.NegativeInfinity, double.PositiveInfinity, double.MinValue, double.MaxValue, 0.0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformDoubleArray_SpecialValues_ReturnStringArray()
        {
            string[] expected =
            {
                "not a number ",
                "negative infinity ",
                "positive infinity ",
                "minus one point seven nine seven six nine three one three four eight six two three two exponent plus three zero eight ",
                "one point seven nine seven six nine three one three four eight six two three two exponent plus three zero eight ",
                "zero "
            };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleConverter().Transform, double.NaN, double.NegativeInfinity, double.PositiveInfinity, double.MinValue, double.MaxValue, 0.0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformToWords_ThrowArgumentNullException()
        {
            double[] array = { };

            Assert.Throws<ArgumentNullException>(() => NumbersToString.TransformDoubleArray(new DoubleConverter(), array));
        }

        [Test]
        public void TransformDoubleArray_ThrowArgumentNullException()
        {
            double[] array = { };

            Assert.Throws<ArgumentNullException>(() => NumbersToString.TransformDoubleArray(new DoubleConverter().Transform, array));
        }

        [Test]
        public void ToBinary_SpecialValues_ReturnBinaryString()
        {
            string[] expected =
            {
                "1111111111111000000000000000000000000000000000000000000000000000",
                "1111111111110000000000000000000000000000000000000000000000000000",
                "0111111111110000000000000000000000000000000000000000000000000000",
                "1111111111101111111111111111111111111111111111111111111111111111",
                "0111111111101111111111111111111111111111111111111111111111111111",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000"
            };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleToIEEE(), double.NaN, double.NegativeInfinity, double.PositiveInfinity, double.MinValue, double.MaxValue, +0.0, -0.0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Transform_SpecialValues_ReturnBinaryString()
        {
            string[] expected =
            {
                "1111111111111000000000000000000000000000000000000000000000000000",
                "1111111111110000000000000000000000000000000000000000000000000000",
                "0111111111110000000000000000000000000000000000000000000000000000",
                "1111111111101111111111111111111111111111111111111111111111111111",
                "0111111111101111111111111111111111111111111111111111111111111111",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000"
            };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleToIEEE().Transform, double.NaN, double.NegativeInfinity, double.PositiveInfinity, double.MinValue, double.MaxValue, +0.0, -0.0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_DoubleArray_ReturnBinaryString()
        {
            string[] expected =
            {
                "1100000001101111111010000010100011110101110000101000111101011100",
                "0100000001101111111010000010100011110101110000101000111101011100",
                "0100000111101111111111111111111111111111111000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000001"
            };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleToIEEE(), -255.255, 255.255, 4294967295.0, double.Epsilon);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Transform_DoubleArray_ReturnBinaryString()
        {
            string[] expected =
            {
                "1100000001101111111010000010100011110101110000101000111101011100",
                "0100000001101111111010000010100011110101110000101000111101011100",
                "0100000111101111111111111111111111111111111000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000001"
            };

            string[] actual = NumbersToString.TransformDoubleArray(new DoubleToIEEE().Transform, -255.255, 255.255, 4294967295.0, double.Epsilon);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ToBinary_ThrowArgumentNullException()
        {
            double[] array = { };

            Assert.Throws<ArgumentNullException>(() => NumbersToString.TransformDoubleArray(new DoubleToIEEE(), array));
        }

        [Test]
        public void Transform_ThrowArgumentNullException()
        {
            double[] array = { };

            Assert.Throws<ArgumentNullException>(() => NumbersToString.TransformDoubleArray(new DoubleToIEEE().Transform, array));
        }
    }
}

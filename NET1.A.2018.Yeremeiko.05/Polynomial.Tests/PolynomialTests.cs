using System;
using NUnit.Framework;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Equality_EqualPolynomials_ReturnTrue()
        {
            Polynomial firstPolynomial = new Polynomial(1.2, 3.4, 9.8, 0.0001);
            Polynomial secondPolynomial = new Polynomial(1.2, 3.4, 9.8, 0.0001);

            Assert.IsTrue(firstPolynomial == secondPolynomial);
        }

        [Test]
        public void Equality_NonEqualPolynomials_ReturnFalse()
        {
            Polynomial firstPolynomial = new Polynomial(1.2, 3.4, 9.8, 0.0001);
            Polynomial secondPolynomial = new Polynomial(1.2, 3.4, 9.8);

            Assert.IsFalse(firstPolynomial == secondPolynomial);
        }

        [Test]
        public void NonEquality_EqualPolynomials_ReturnFalse()
        {
            Polynomial firstPolynomial = new Polynomial(1.2, 3.4, 9.8, 0.0001);
            Polynomial secondPolynomial = new Polynomial(1.2, 3.4, 9.8, 0.0001);

            Assert.IsFalse(firstPolynomial != secondPolynomial);
        }

        [Test]
        public void NonEquality_NonEqualPolynomials_ReturnTrue()
        {
            Polynomial firstPolynomial = new Polynomial(1.2, 3.4, 9.8, 0.0001);
            Polynomial secondPolynomial = new Polynomial(5.3, 3.4, 9.8);

            Assert.IsTrue(firstPolynomial != secondPolynomial);
        }

        [TestCase(1.2, 0.9, 1, ExpectedResult = "Polynomial: 1,2x^2 + 0,9x^1 + 1")]
        [TestCase(double.MinValue, double.MaxValue, ExpectedResult = "Polynomial: -1,79769313486232E+308x^1 + 1,79769313486232E+308")]
        [TestCase(2, ExpectedResult = "Polynomial: 2")]
        [TestCase(987.000008, double.Epsilon, 0, ExpectedResult = "Polynomial: 987,000008x^2 + 4,94065645841247E-324x^1 + 0")]
        public string ToString_ReturnStringPolynomial(params double[] array)
        {
            Polynomial polynomial = new Polynomial(array);

            return polynomial.ToString();
        }

        [TestCase(9.3, ExpectedResult = 0)]
        [TestCase(1.6, 0.5, ExpectedResult = 1)]
        [TestCase(9.4, 4.7, 6.5, ExpectedResult = 2)]
        [TestCase(6.5, 8.05, 6.3, 7.1, ExpectedResult = 3)]
        [TestCase(9.1, 0.2, 45, 8.4, 0.0005, 3.6, 1.2, 8, 0.05, ExpectedResult = 8)]
        public int Degree_ReturnDegreeOfPolynomial(params double[] array)
        {
            Polynomial polynomial = new Polynomial(array);

            return polynomial.Degree();
        }

        [TestCase(9, 9, 9)]
        [TestCase(0, 7.2, 5.2, 9.3, 7.2)]
        [TestCase(1, 34, 2, 3, 5, 10, 8, 6)]
        [TestCase(8.6, 3905.8171, 5.3, 7.1, 0.0005, 9.6)]
        public void GetPolynomialValue_ReturnPolynomialValue(double unknown, double expected, params double[] array)
        {
            Polynomial polynomial = new Polynomial(array);

            double actual = polynomial.GetPolynomialValue(unknown);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        [TestCase(double.NaN, 9, 5.2)]
        [TestCase(double.NegativeInfinity, 6.3, 4.5, 0.3)]
        [TestCase(double.PositiveInfinity, 9.1, 1.5, 8.6, 0.4, 7.3)]
        public void GetPolynomialValue_InvalidValues(double unknown, params double[] array)
        {
            Polynomial polynomial = new Polynomial(array);
            Assert.Throws<ArgumentException>(() => polynomial.GetPolynomialValue(unknown));
        }

        [Test]
        public void Add_ReturnSum()
        {
            Polynomial firstPolynomial = new Polynomial(5, -3);
            Polynomial secondPolynomial = new Polynomial(4, 7);
            Polynomial expected = new Polynomial(9, 4);

            CollectionAssert.AreEqual(expected.Arguments, (firstPolynomial + secondPolynomial).Arguments);
        }

        [Test]
        public void Subtract_ReturnSubtract()
        {
            Polynomial firstPolynomial = new Polynomial(-5, 0, 8, -5);
            Polynomial secondPolynomial = new Polynomial(3, 0, 4, -1);
            Polynomial expected = new Polynomial(-8, 0, 4, -4);

            CollectionAssert.AreEqual(expected.Arguments, (firstPolynomial - secondPolynomial).Arguments);
        }

        [Test]
        public void Multiply_ReturnMul()
        { 
            Polynomial firstPolynomial = new Polynomial(3, 0, 8);
            Polynomial secondPolynomial = new Polynomial(2, -9);
            Polynomial expected = new Polynomial(6, -27, 16, -72);

            CollectionAssert.AreEqual(expected.Arguments, (firstPolynomial * secondPolynomial).Arguments);
        }
    }
}

using System;
using NUnit.Framework;

namespace FindNthRootLogic.NUnitTests
{
    [TestFixture()]
    public class FindRootNewtonTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_ReturnRoot(double number, int degree, double accurancy, double expected)
        {
            double actual = FindRootNewton.FindNthRoot(number, degree, accurancy);

            Assert.AreEqual(expected, actual, accurancy);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_ThrowArgumentException(double number, int degree, double accurancy)
        {
            Assert.Throws<ArgumentException>(() => FindRootNewton.FindNthRoot(number, degree, accurancy));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fibonacci.Tests
{
    [TestFixture]
    public class FibonacciGeneratorTests
    {
        [Test]
        public void Generate_Success()
        {
            BigInteger[] array =
            {
                1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711,
                28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887,
                9227465, 14930352, 24157817, 39088169, 63245986, 102334155
            };

            CollectionAssert.AreEqual(array, FibonacciGenerator.Generate(40));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Generate_ThrowArgumentException(int number)
        {
            Assert.Throws<ArgumentException>(() => FibonacciGenerator.Generate(number));
        }
    }
}

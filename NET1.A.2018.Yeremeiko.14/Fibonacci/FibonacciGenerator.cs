using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciGenerator
    {
        /// <summary>
        /// Generates the Fibonacci number.
        /// </summary>
        /// <param name="count">The number of generated Fibonacci numbers.</param>
        /// <returns>The Fibonacci number.</returns>
        /// <exception cref="ArgumentException">Number need to be positive.</exception>
        public static IEnumerable<BigInteger> Generate(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(count)} need to be positive.");
            }

            return GenerateCore(count);

            IEnumerable<BigInteger> GenerateCore(int number)
            {
                BigInteger current = 0;
                BigInteger next = 1;
                for (var i = 0; i < number; i++)
                {
                    yield return next;
                    next = current + (current = next);
                }
            }
        }
    }
}

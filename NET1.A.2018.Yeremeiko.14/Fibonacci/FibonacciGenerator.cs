using System;
using System.Collections.Generic;
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
        /// <param name="number">The number of generated Fibonacci numbers.</param>
        /// <returns>The Fibonacci number.</returns>
        /// <exception cref="ArgumentException">Number need to be positive.</exception>
        public static IEnumerable<long> Generate(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException($"{nameof(number)} need to be positive.");
            }

            long current = 0;
            long next = 1;
            for (var i = 0; i < number; i++)
            {
                yield return next;
                next = current + (current = next);
            }
        }
    }
}

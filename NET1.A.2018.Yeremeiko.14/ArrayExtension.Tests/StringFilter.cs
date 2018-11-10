using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtension.Tests
{
    public class StringFilter : IFilter<string>
    {
        private readonly int lengthBoundary;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringFilter"/> class.
        /// </summary>
        /// <param name="length">The length boundary.</param>
        /// <exception cref="System.ArgumentException">Length need to be non negative.</exception>
        public StringFilter(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException($"{nameof(length)} need to be non negative.");
            }

            lengthBoundary = length;
        }

        /// <summary>
        /// Defines if source length matches the pattern.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True is matched, false otherwise.</returns>
        public bool FilterSource(string source)
        {
            return source.Length == lengthBoundary ? true : false;
        }
    }
}

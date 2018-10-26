using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings.Tests
{
    public class CompareByMaxElementAscending : IComparer<int[]>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompareByMaxElementAscending"/> class.
        /// </summary>
        public CompareByMaxElementAscending() { }

        /// <summary>
        /// Compares first array with second array by max element in each array.
        /// </summary>
        /// <param name="firstArray">The first array.</param>
        /// <param name="secondArray">The second array.</param>
        /// <returns>0 if equals, 1 if second array is bigger then first and -1 if first array is bigger then second.</returns>
        public int Compare(int[] firstArray, int[] secondArray)
        {
            if (firstArray == null && secondArray == null)
            {
                return 0;
            }

            if (firstArray == null)
            {
                return -1;
            }

            if (secondArray == null)
            {
                return 1;
            }

            return secondArray.Max() - firstArray.Max();
        }
    }
}

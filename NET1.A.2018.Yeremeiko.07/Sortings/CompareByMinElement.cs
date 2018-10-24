using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public class CompareByMinElement : IComparer<int[]>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompareByMinElement"/> class.
        /// </summary>
        /// <param name="ascending">if set to <c>true</c> [descending].</param>
        public CompareByMinElement(bool descending = true)
        {
            Descending = descending;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CompareByMinElement"/> is descending.
        /// </summary>
        /// <value>
        ///   <c>true</c> if descending; otherwise, <c>false</c>.
        /// </value>
        public bool Descending { get; set; }

        /// <summary>
        /// Compares first array with second array by min element in each array.
        /// </summary>
        /// <param name="firstArray">The first array.</param>s
        /// <param name="secondArray">The second array.</param>
        /// <returns>0 if equals, 1 if first array is bigger then second and -1 if second array is bigger then first.</returns>
        public int Compare(int[] firstArray, int[] secondArray)
        {
            if (firstArray == null && secondArray == null)
            {
                return 0;
            }

            if (firstArray == null)
            {
                return Descending ? 1 : -1;
            }

            if (secondArray == null)
            {
                return Descending ? -1 : 1;
            }

            return Descending ? secondArray.Min() - firstArray.Min() : firstArray.Min() - secondArray.Min();
        }
    }
}

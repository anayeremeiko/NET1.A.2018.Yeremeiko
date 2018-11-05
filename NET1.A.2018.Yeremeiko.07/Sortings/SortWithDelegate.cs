using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public static class SortWithDelegate
    {
        /// <summary>
        /// Sorts the jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="sorter">The sort strategy.</param>
        /// <exception cref="ArgumentNullException">Array shouldn't be null or empty.</exception>
        /// <exception cref="ArgumentNullException">Array shouldn't be null or empty.</exception>
        public static void Sort(int[][] array, Comparison<int[]> sorter) => Sort(array, Comparer<int[]>.Create(sorter));

        /// <summary>
        /// Sorts the jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The sort strategy.</param>
        /// <exception cref="ArgumentNullException">Array shouldn't be null or empty.</exception>
        /// <exception cref="ArgumentNullException">Array shouldn't be null or empty.</exception>
        public static void Sort(int[][] array, IComparer<int[]> comparer) => Sortings.Sort(array, comparer);
    }
}

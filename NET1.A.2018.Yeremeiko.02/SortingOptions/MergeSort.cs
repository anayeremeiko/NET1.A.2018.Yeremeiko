using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingOptions
{
    /// <summary>
    /// Sorting the specified array using merge sort method.
    /// </summary>
    public static class MergeSort
    {
        /// <summary>
        /// Sorts the specified array using merge sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        public static void Sort(int[] array)
        {
            Sort(array, array.GetLowerBound(0), array.Length - 1);
        }

        /// <summary>
        /// Sorts the specified array with merge sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">The left boundary.</param>
        /// <param name="right">The right boundary.</param>
        /// <exception cref="System.NullReferenceException">Need not null array</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Need non negative boundaries</exception>
        public static void Sort(int[] array, int left, int right)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }

            if (left < 0 || right < 0)
            {
                throw new ArgumentOutOfRangeException(left < 0 ? nameof(left) : nameof(right));
            }

            if (left >= right)
            {
                return;
            }

            int middle = left + (right - left >> 1);
            Sort(array, left, middle);
            Sort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {

        }
    }
}

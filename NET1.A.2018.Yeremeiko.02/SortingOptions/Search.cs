using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingOptions
{
    public static class Search<T>
    {
        /// <summary>
        /// Binary search.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="element">The target element.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The index of target element if exists.</returns>
        /// <exception cref="ArgumentNullException">Comparer need to be not null.</exception>
        public static int? BinarySearch(T[] array, T element, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} ned to be not null.");
            }

            return BinarySearch(array, element, comparer.Compare);
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="element">The target element.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The index of target element if exists.</returns>
        /// <exception cref="ArgumentNullException">Array need to be not null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Element out of range.</exception>
        public static int? BinarySearch(T[] array, T element, Comparison<T> comparer)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} need to be not null.");
            }

            if ((comparer?.Invoke(element, array[array.Length - 1]) > 0) || (comparer?.Invoke(element, array[0]) < 0))
            {
                throw new ArgumentOutOfRangeException($"{nameof(element)} out of range.");
            }
            
            int first = 0;
            int last = array.Length;
            int middle;
            while (first < last)
            {
                middle = first + (last - first) / 2;
                if (comparer(element, array[middle]) == 0)
                {
                    return middle;
                }

                if (comparer(element, array[middle]) <= 0)
                {
                    last = middle;
                }
                else
                {
                    first = middle + 1;
                }
            }

            return null;
        }
    }
}

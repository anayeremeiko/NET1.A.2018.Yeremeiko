using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public static class Sortings
    {
        /// <summary>
        /// Sorts the specified array with bubble method.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Array shouldn't be null or empty.</exception>
        /// <exception cref="ArgumentException">Comparer need to be not null.</exception>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} shouldn't be null or empty.");
            }

            if (comparer == null)
            {
                throw new ArgumentException(nameof(comparer));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > 0; j--)
                {
                    if (comparer.Compare(array[j], array[j - 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j - 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] temp = firstArray;
            firstArray = secondArray;
            secondArray = temp;
        }
    }
}

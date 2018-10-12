using System;

namespace SortingOptions
{
    /// <summary>
    /// Sorting the specified array with quick sort method.
    /// </summary>
    public static class QuickSort
    {
        /// <summary>
        /// Sorts the specified array using quick sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts the specified array with quick sort method.
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

            int pivot = Partition(array, left, right);
            Sort(array, left, pivot);
            Sort(array, pivot + 1, right);
        }

        /// <summary>
        /// Defines the location of pivot element in the specified array.
        /// </summary>
        /// <remarks>Defines a special pivot value that partitions A[left,right] into a first half
        /// whose elements are smaller or equal to pivot
        /// and a second half whose elements are larger or equal to pivot.</remarks>
        /// <param name="array">The array.</param>
        /// <param name="left">The left boundary.</param>
        /// <param name="right">The right boundary.</param>
        /// <returns>The index of pivot element in the specified array.</returns>
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = left;

            for (int i = left + 1; i <= right; i++)
            {
                if (array[i].CompareTo(array[left]) <= 0)
                {
                    SwapArrayElements(array, ++pivot, i);
                }
            }

            SwapArrayElements(array, left, pivot);
            return pivot;
        }

        /// <summary>
        /// Swaps two elements of integers array.
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="i">Index of first array element</param>
        /// <param name="j">Index of second array element</param>
        private static void SwapArrayElements(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

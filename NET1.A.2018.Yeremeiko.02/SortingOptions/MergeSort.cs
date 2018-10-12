using System;

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
            Sort(array, 0, array.Length - 1);
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

            int middle = (left + right) / 2; //left + (right - (left >> 1));
            Sort(array, left, middle);
            Sort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }

        /// <summary>
        /// Merges the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">Index of first element.</param>
        /// <param name="middle">Index of middle element.</param>
        /// <param name="right">Index of last element.</param>
        private static void Merge(int[] array, int left, int middle, int right)
        {
            int lengthOfLeft = middle - left + 1;
            int lengthOfRight = right - middle;
            int[] leftArray = new int[lengthOfLeft];
            int[] rightArray = new int[lengthOfRight];

            for (int a = 0; a < lengthOfLeft; a++)
            {
                leftArray[a] = array[left + a];
            }
            for (int b = 0; b < lengthOfRight; b++)
            {
                rightArray[b] = array[middle + b + 1];
            }

            int i = 0, j = 0, n = left;

            while (i < lengthOfLeft && j < lengthOfRight)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[n] = leftArray[i];
                    i++;
                }
                else
                {
                    array[n] = rightArray[j];
                    j++;
                }

                n++;
            }

            while (i < lengthOfLeft)
            {
                array[n] = leftArray[i];
                i++;
                n++;
            }

            while (j < lengthOfRight)
            {
                array[n] = rightArray[j];
                j++;
                n++;
            }
        }
    }
}

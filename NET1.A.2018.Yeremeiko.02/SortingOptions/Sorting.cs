using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingOptions
{
    /// <summary>
    /// Sorting the specified array with quick or merge sort method.
    /// </summary>
    public static class Sorting<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the specified array using quick sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="System.ArgumentNullException">Need not null array</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Need non negative boundaries</exception>
        public static void QuickSort(T[] array)
        {
            CheckArrayNullReference(array);
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts the specified array with quick sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">The left boundary.</param>
        /// <param name="right">The right boundary.</param>
        /// <exception cref="System.ArgumentNullException">Need not null array</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Need non negative boundaries</exception>
        public static void QuickSort(T[] array, int left, int right)
        {
            CheckArrayNullReference(array);
            if (left < 0 || right < 0)
            {
                throw new ArgumentOutOfRangeException(left < 0 ? nameof(left) : nameof(right));
            }

            if (left >= right)
            {
                return;
            }

            int pivot = Partition(array, left, right);
            QuickSort(array, left, pivot);
            QuickSort(array, pivot + 1, right);
        }

        /// <summary>
        /// Sorts the specified array using merge sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="System.ArgumentNullException">Need not null array</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Need non negative boundaries</exception>
        public static void MergeSort(T[] array)
        {
            CheckArrayNullReference(array);
            MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts the specified array with merge sort method.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">The left boundary.</param>
        /// <param name="right">The right boundary.</param>
        /// <exception cref="System.ArgumentNullException">Need not null array</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Need non negative boundaries</exception>
        public static void MergeSort(T[] array, int left, int right)
        {
            CheckArrayNullReference(array);
            if (left < 0 || right < 0)
            {
                throw new ArgumentOutOfRangeException(left < 0 ? nameof(left) : nameof(right));
            }

            if (left >= right)
            {
                return;
            }

            int middle = (left + right) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }

        /// <summary>
        /// Merges the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">Index of first element.</param>
        /// <param name="middle">Index of middle element.</param>
        /// <param name="right">Index of last element.</param>
        private static void Merge(T[] array, int left, int middle, int right)
        {
            int lengthOfLeft = middle - left + 1;
            int lengthOfRight = right - middle;
            T[] leftArray = new T[lengthOfLeft];
            T[] rightArray = new T[lengthOfRight];

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
                if (leftArray[i].CompareTo(rightArray[j]) != 1)
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
        private static int Partition(T[] array, int left, int right)
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
        private static void SwapArrayElements(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /// <summary>
        /// Checks the array null reference.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentNullException">Need not empty array.</exception>
        private static void CheckArrayNullReference(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Need not empty {nameof(array)}");
            }
        }
    }
}

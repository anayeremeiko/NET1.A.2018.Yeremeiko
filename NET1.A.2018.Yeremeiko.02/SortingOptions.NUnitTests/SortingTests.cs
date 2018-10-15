using System;
using NUnit.Framework;

namespace SortingOptions.NUnitTests
{
    [TestFixture]
    public class SortingTests
    {
        [Test]
        public void QuickSort_SortedArray_Success()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void QuickSort_1ElementArray_Success()
        {
            int[] array = { 10 };
            int[] sortedArray = { 10 };

            Sorting.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void QuickSort_10PosNumbers_Success()
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sorting.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void QuickSort_10NegNumbers_Success()
        {
            int[] array = { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            int[] sortedArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1 };

            Sorting.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void QuickSort_RandomArrayBigAmountOfElements_Success()
        {
            GC.Collect();
            int[] array = GenerateRandomArray(10000);
            int[] sortedArray = new int[10000];
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            Sorting.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void QuickSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => Sorting.QuickSort(array));
        }

        [Test]
        public void QuickSort_EmptyArray_ThrowArgumentOutOfRangeException()
        {
            int[] array = { };

            Assert.Throws<ArgumentOutOfRangeException>(() => Sorting.QuickSort(array));
        }

        [Test]
        public void MergeSort_EvenNumberOfElementsInArray_Success()
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sorting.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_OddNumbersOfElementsInArray_Success()
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sorting.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_10NegNumbers_Success()
        {
            int[] array = { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            int[] sortedArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1 };

            Sorting.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_SortedArray_Success()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_1ElementArray_Success()
        {
            int[] array = { 10 };
            int[] sortedArray = { 10 };

            Sorting.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_RandomArrayOfMillionElements_Success()
        {
            GC.Collect();
            int[] array = GenerateRandomArray(1000000);
            int[] sortedArray = new int[1000000];
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            Sorting.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => Sorting.MergeSort(array));
        }

        [Test]
        public void MergeSort_EmptyArray_ThrowArgumentOutOfRangeException()
        {
            int[] array = { };

            Assert.Throws<ArgumentOutOfRangeException>(() => Sorting.MergeSort(array));
        }

        private int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = r.Next();
            }

            return array;
        }
    }
}

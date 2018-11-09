using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingOptions.Tests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void QuickSort_SortedArray_Success()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting<int>.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void QuickSort_1ElementArray_Success()
        {
            int[] array = { 10 };
            int[] sortedArray = { 10 };

            Sorting<int>.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void QuickSort_10PosNumbers_Success()
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sorting<int>.QuickSort(array);
            
            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void QuickSort_10NegNumbers_Success()
        {
            int[] array = { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            int[] sortedArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1 };

            Sorting<int>.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void QuickSort_RandomArrayBigAmountOfElements_Success()
        {
            GC.Collect();
            int[] array = GenerateRandomArray(10000);
            int[] sortedArray = new int[10000];
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            Sorting<int>.QuickSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void QuickSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.ThrowsException<ArgumentNullException>(() => Sorting<int>.QuickSort(array));
        }

        [TestMethod]
        public void QuickSort_EmptyArray_ThrowArgumentOutOfRangeException()
        {
            int[] array = { };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Sorting<int>.QuickSort(array));
        }

        [TestMethod]
        public void MergeSort_EvenNumbersOfElementsInArray_Success()
        {
            GC.Collect();
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sorting<int>.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void MergeSort_OddNumbersOfElementsInArray_Success()
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] sortedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Sorting<int>.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void MergeSort_10NegNumbers_Success()
        {
            int[] array = { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            int[] sortedArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1 };

            Sorting<int>.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void MergeSort_SortedArray_Success()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting<int>.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void MergeSort_1ElementArray_Success()
        {
            int[] array = { 10 };
            int[] sortedArray = { 10 };

            Sorting<int>.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void Sort_RandomArrayOfMillionElements_Success()
        {
            GC.Collect();
            int[] array = GenerateRandomArray(1000000);
            int[] sortedArray = new int[1000000];
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            Sorting<int>.MergeSort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void MergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;

            Assert.ThrowsException<ArgumentNullException>(() => Sorting<int>.MergeSort(array));
        }

        [TestMethod]
        public void MergeSort_EmptyArray_ThrowArgumentOutOfRangeException()
        {
            int[] array = { };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Sorting<int>.MergeSort(array));
        }

        private static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next();
            }

            return array;
        }
    }
}

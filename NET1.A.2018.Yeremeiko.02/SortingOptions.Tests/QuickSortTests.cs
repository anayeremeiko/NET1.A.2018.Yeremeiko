using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingOptions.Tests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void Sort_SortedArray_Success()
        {
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void Sort_1ElementArray_Success()
        {
            int[] array = { 10 };
            int[] sortedArray = { 10 };

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void Sort_10PosNumbers_Success()
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            QuickSort.Sort(array);
            
            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void Sort_10NegNumbers_Success()
        {
            int[] array = { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            int[] sortedArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1 };

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void Sort_RandomArrayOfMillionElements_Success()
        {
            GC.Collect();
            int[] array = new int[100000];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next();
            }
            
            int[] sortedArray = new int[100000];
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [TestMethod]
        public void Sort_ArrayIsNull_ThrowNullReferenceException()
        {
            int[] array = null;

            Assert.ThrowsException<NullReferenceException>(() => QuickSort.Sort(array));
        }

        [TestMethod]
        public void Sort_EmptyArray_ThrowArgumentOutOfRangeException()
        {
            int[] array = { };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => QuickSort.Sort(array));
        }
    }
}

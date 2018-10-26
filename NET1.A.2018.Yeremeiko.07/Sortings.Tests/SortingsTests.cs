using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sortings.Tests
{
    [TestFixture]
    public class SortingsTests
    {
        [Test]
        public void Sort_NullArray_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sortings.Sort(null, new CompareBySumDescending()));
        }

        [Test]
        public void Sort_EmptyArray_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sortings.Sort(new int[0][], new CompareByMinElementAscending()));
        }

        [Test]
        public void Sort_NullComparer_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sortings.Sort(new int[3][], null));
        }

        [Test]
        public void Sort_BySumAscending_ReturnSortedArray()
        {
            int[][] array = new int[6][]
            {
                new int[] { 3, 5, 9, 6 },
                new int[] { 6, 1, 2 },
                new int[] { 0, 563, 45321862 },
                new int[] { -51237965 },
                new int[] { 3, -12358, 687812, 13 },
                new int[] { 9, 1, -1 }
            };

            int[][] sortedArray = new int[6][]
            {
                new int[] { -51237965 },
                new int[] { 6, 1, 2 },
                new int[] { 9, 1, -1 },
                new int[] { 3, 5, 9, 6 },
                new int[] { 3, -12358, 687812, 13 },
                new int[] { 0, 563, 45321862 }
            };

            Sortings.Sort(array, new CompareBySumAscending());

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_BySumDescending_ReturnSortedArray()
        {
            int[][] array = new int[6][]
            {
                new int[] { 3, 5, 9, 6 },
                new int[] { 6, 1, 2 },
                new int[] { 0, 563, 45321862 },
                new int[] { -51237965 },
                new int[] { 3, -12358, 687812, 13 },
                new int[] { 9, 1, -1 }
            };

            int[][] sortedArray = new int[6][]
            {
                new int[] { 0, 563, 45321862 },
                new int[] { 3, -12358, 687812, 13 },
                new int[] { 3, 5, 9, 6 },
                new int[] { 6, 1, 2 },
                new int[] { 9, 1, -1 },
                new int[] { -51237965 }
            };

            Sortings.Sort(array, new CompareBySumDescending());

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_ByMaxElementAscending_ReturnSortedArray()
        {
            int[][] array = new int[4][]
            {
                new int[] { 1, 9, 3, int.MaxValue },
                new int[] { 6, 0, int.MinValue },
                new int[] { 9, 4568 },
                null
            };

            int[][] sortedArray = new int[4][]
            {
                new int[] { 6, 0, int.MinValue },
                new int[] { 9, 4568 },
                new int[] { 1, 9, 3, int.MaxValue },
                null
            };

            Sortings.Sort(array, new CompareByMaxElementAscending());

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_ByMaxElementDescending_ReturnSortedArray()
        {
            int[][] array = new int[4][]
            {
                new int[] { 1, 9, 3, int.MaxValue },
                new int[] { 6, 0, int.MinValue },
                new int[] { 9, 4568 },
                null
            };

            int[][] sortedArray = new int[4][]
            {
                null,
                new int[] { 1, 9, 3, int.MaxValue },
                new int[] { 9, 4568 },
                new int[] { 6, 0, int.MinValue }
            };

            Sortings.Sort(array, new CompareByMaxElementDescending());

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_ByMinElementAscending_ReturnSortedArray()
        {
            int[][] array = new int[5][]
            {
                null,
                new int[] { 5 },
                new int[] { 0, 3, -3 },
                new int[] { -214748364, int.MaxValue },
                null
            };

            int[][] sortedArray = new int[5][]
            {
                new int[] { 5 },
                new int[] { 0, 3, -3 },
                new int[] { -214748364, int.MaxValue },
                null,
                null,
            };

            Sortings.Sort(array, new CompareByMinElementAscending());

            CollectionAssert.AreEqual(sortedArray, array);
        }

        [Test]
        public void Sort_ByMinElementDescending_ReturnSortedArray()
        {
            int[][] array = new int[5][]
            {
                null,
                new int[] { -5 },
                new int[] { 0, 6, -365 },
                new int[] { int.MinValue },
                null
            };

            int[][] sortedArray = new int[5][]
            {
                null,
                null,
                new int[] { int.MinValue },
                new int[] { 0, 6, -365 },
                new int[] { -5 }
            };

            Sortings.Sort(array, new CompareByMinElementDescending());

            CollectionAssert.AreEqual(sortedArray, array);
        }
    }
}

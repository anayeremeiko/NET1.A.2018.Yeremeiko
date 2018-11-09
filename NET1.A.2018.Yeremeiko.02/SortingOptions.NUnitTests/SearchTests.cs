using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SortingOptions.NUnitTests
{
    [TestFixture()]
    public class SearchTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, ExpectedResult = 3)]
        [TestCase(new[] { 20, 25, 30, 51 }, 51, ExpectedResult = 3)]
        public int? BinarySearch(int[] array, int element)
        {
            return Search<int>.BinarySearch(array, element, Comparer<int>.Default);
        }

        [TestCase(new[] { "abc", "c#", "oskar" }, "c#", ExpectedResult = 1)]
        [TestCase(new[] { "Привет", "пройдись", "тест" }, "тест", ExpectedResult = 2)]
        public int? BinarySearch_Strings(string[] array, string element)
        {
            return Search<string>.BinarySearch(array, element, (first, second) => first.CompareTo(second));
        }

        [TestCase(new int[] { }, 0)]
        [TestCase(null, 2)]
        public void BinarySearch_ThrowArgumentNullException(int[] array, int element)
        {
            Assert.Throws<ArgumentNullException>(() => Search<int>.BinarySearch(array, element, (first, second) => first.CompareTo(second)));
        }

        [TestCase(new[] { 2, 1, 0 }, 0)]
        [TestCase(new[] {0, 5, 6, -1 }, 5)]
        public void BinarySearch_ThrowArgumentOutOfRangeException(int[] array, int element)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Search<int>.BinarySearch(array, element, (first, second) => first.CompareTo(second)));
        }

        [TestCase(new[] { "Привет", "тест", "пройдись" }, "тест")]
        public void BinarySearch_ThrowArgumentOutOfRangeException(string[] array, string element)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Search<string>.BinarySearch(array, element, (first, second) => first.CompareTo(second)));
        }
    }
}

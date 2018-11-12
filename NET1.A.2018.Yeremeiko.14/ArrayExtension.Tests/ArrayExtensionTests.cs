using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayExtension.Tests
{
    [TestFixture()]
    public class ArrayExtensionTests
    {
        [TestCase(new[] { "hi", "two", "cup", "c#", "epam", "not" }, 3, ExpectedResult = new[] { "two", "cup", "not" })]
        [TestCase(new[] { "pollution", "never", "wood", "UI", "1234" }, 4, ExpectedResult = new[] { "wood", "1234" })]
        public IEnumerable<string> Filter_Strings(string[] array, int length)
        {
            return array.Filter(new StringFilter(length).FilterSource);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, int.MaxValue }, ExpectedResult = new[] { 2, 4, 6, 8 })]
        [TestCase(new[] { -1, -2, -3 }, ExpectedResult = new[] { -2 })]
        public IEnumerable<int> Filter_Int(int[] array)
        {
            return array.Filter(new IntFilter());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, int.MaxValue })]
        [TestCase(new[] { int.MinValue, int.MaxValue, 0, -1, 1})]
        public void Filter_WithDelegate_ThrowArgumentNullException(int[] array)
        {
            Predicate<int> predicate = null;
            Assert.Throws<ArgumentNullException>(() => array.Filter(predicate));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, int.MaxValue })]
        [TestCase(new[] { int.MinValue, int.MaxValue, 0, -1, 1 })]
        public void Filter_WithInterface_ThrowArgumentNullException(int[] array)
        {
            IntFilter predicate = null;
            Assert.Throws<ArgumentNullException>(() => array.Filter(predicate));
        }
    }
}

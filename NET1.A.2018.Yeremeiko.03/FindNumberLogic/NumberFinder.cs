using System;

namespace FindNumberLogic
{
    /// <summary>
    /// Contains logic of finding the next bigger number.
    /// </summary>
    public static class NumberFinder
    {
        /// <summary>
        /// Finds the next bigger number of specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The next bigger number of specified number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Need positive number.</exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(number)} need to be positive.");
            }

            int[] numberToArray = IntToArray(number);
            Array.Reverse(numberToArray);

            int indexOfFirstBiggestDigit = FindAndSwapBiggestDigit(numberToArray);
            Array.Sort(numberToArray, indexOfFirstBiggestDigit, numberToArray.Length - indexOfFirstBiggestDigit);
            int nextNumber = ArrayToInt(numberToArray);

            if (nextNumber > number)
            {
                return nextNumber;
            }

            return -1;
        }

        /// <summary>
        /// Finds and swaps the biggest digit in array of digits.
        /// </summary>
        /// <param name="array">The digit array.</param>
        /// <returns>The index of first biggest digit in array.</returns>
        private static int FindAndSwapBiggestDigit(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    Swap(array, i - 1, i);
                    return i;
                }
            }

            return array.Length - 1;
        }

        /// <summary>
        /// Swaps the numbers in specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="i">The index of first number.</param>
        /// <param name="j">The index of second number.</param>
        private static void Swap(int[] array, int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return;
            }

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /// <summary>
        /// Converts array to int.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The number containing each digit from array.</returns>
        private static int ArrayToInt(int[] array)
        {
            int number = 0;
            int n = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                number += array[i] * n;
                n *= 10;
            }

            return number;
        }

        /// <summary>
        /// Converts int to array.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The array containing every digit of the number.</returns>
        private static int[] IntToArray(int number)
        {
            int[] array = new int[number.ToString().Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = number % 10;
                number /= 10;
            }

            return array;
        }
    }
}

using System;

namespace InsertNumberLogic
{
    /// <summary>
    /// Contains logic for changing bits of two numbers.
    /// </summary>
    public static class BitManipulation
    {
        /// <summary>
        /// Changes bits of two numbers
        /// </summary>
        /// <param name="destNum">The number to insert bits.</param>
        /// <param name="sourceNum">The number which bits where taken.</param>
        /// <param name="i">Low boundary of bit sequence.</param>
        /// <param name="j">High boundary of bit sequence.</param>
        /// <exception cref="ArgumentOutOfRangeException">Boundaries need to be less then 31 and bigger then 0,
        /// low boundary need to be less then high boundary.</exception>
        /// <returns>The number with changed bits</returns>
        public static int InsertNumber(int destNum, int sourceNum, int i, int j)
        {
            const int MAXBIT = 31;
            const int MINBIT = 0;

            if (i > j)
            {
                throw new ArgumentException($"{nameof(i)} must be less then {nameof(j)}");
            }

            if ((i < MINBIT || i > MAXBIT) || (j < MINBIT || j > MAXBIT))
            {
                throw new ArgumentOutOfRangeException($"Arguments {nameof(i)} and {nameof(j)} must be between {MAXBIT} and {MINBIT}");
            }

            int maskToSelectSourceBits = ~(~0 << (j - i + 1));
            int maskToResetDestBits = ~(~(~0 << (j - i + 1)) << i);

            sourceNum &= maskToSelectSourceBits;
            sourceNum <<= i;
            destNum &= maskToResetDestBits;

            return destNum | sourceNum;
        }
    }
}

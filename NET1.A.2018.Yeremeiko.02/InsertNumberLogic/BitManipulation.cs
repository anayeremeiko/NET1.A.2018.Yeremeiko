using System;

namespace InsertNumberLogic
{
    public static class BitManipulation
    {
        public static int InsertNumber(int destNum, int sourceNum, int i, int j)
        {
            const int MAXBIT = 31;
            const int MINBIT = 0;

            if (i > j)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} must be less then {nameof(j)}");
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

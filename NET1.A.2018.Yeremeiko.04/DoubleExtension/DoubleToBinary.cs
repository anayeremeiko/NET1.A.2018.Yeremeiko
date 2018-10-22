using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DoubleExtension
{
    /// <summary>
    /// Contains extension to double type.
    /// </summary>
    public static class DoubleToBinary
    {
        private const int MAXBITS = 64;

        /// <summary>
        /// Converts double to binary.
        /// </summary>
        /// <param name="number">The target number.</param>
        /// <returns>Binary representation of target number in IEEE 754.</returns>
        public static string ToBinary(this double number)
        {
            DoubleToLong converter = new DoubleToLong(number);
            long longNumber = converter.LongValue;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < MAXBITS; i++)
            {
                result.Insert(0, (longNumber & 1) == 1 ? "1" : "0");

                longNumber >>= 1;
            }

            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            public long LongValue;

            [FieldOffset(0)]
            private double doubleValue;

            public DoubleToLong(double number) : this()
            {
                doubleValue = number;
            }
        }
    }
}

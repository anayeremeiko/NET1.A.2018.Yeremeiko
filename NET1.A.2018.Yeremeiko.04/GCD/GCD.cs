using System;
using System.Diagnostics;

namespace GCD
{
    /// <summary>
    /// Defines gcd for integers and counts time of algorithms work.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Defines the gcd for integers using the euclidean method.
        /// </summary>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The gcd of numbers.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static int GCDEuclidean(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers[0] == int.MinValue)
            {
                throw new ArgumentException($"{nameof(numbers)} shouldn't contain {nameof(int.MinValue)}.");
            }

            int gcd = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = -numbers[i];
                }

                if (numbers[i] == int.MinValue)
                {
                    throw new ArgumentException($"{nameof(numbers)} shouldn't contain {nameof(int.MinValue)}.");
                }

                gcd = EuclideanMethod(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Defines the gcd for integers using the euclidean method and counts the time algorithm demands for work.
        /// </summary>
        /// <param name="time">The time algorithm demands for work.</param>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The gcd of numbers.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static int GCDEuclidean(out TimeSpan time, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = GCDEuclidean(numbers);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            return gcd;
        }

        /// <summary>
        /// Counts the time euclidean method of counting gcd demands for work.
        /// </summary>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The time euclidean method of counting gcd demands for work.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static TimeSpan GetTimeGCDEuclidean(params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            GCDEuclidean(numbers);
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }

        /// <summary>
        /// Defines the gcd for integers using the stein's method.
        /// </summary>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The gcd of numbers.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static int GCDBinary(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers[0] == int.MinValue)
            {
                throw new ArgumentException($"{nameof(numbers)} shouldn't contain {nameof(int.MinValue)}.");
            }

            int gcd = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = -numbers[i];
                }

                if (numbers[i] == int.MinValue)
                {
                    throw new ArgumentException($"{nameof(numbers)} shouldn't contain {nameof(int.MinValue)}.");
                }

                gcd = BinaryMethod(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Defines the gcd for integers using the stein's method and counts the time algorithm demands for work.
        /// </summary>
        /// <param name="time">The time algorithm demands for work.</param>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The gcd of numbers.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static int GCDBinary(out TimeSpan time, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = GCDBinary(numbers);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            return gcd;
        }

        /// <summary>
        /// Counts the time stein's method of counting gcd demands for work.
        /// </summary>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The time stein's method of counting gcd demands for work.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static TimeSpan GetTimeGCDBinary(params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            GCDBinary(numbers);
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }

        /// <summary>
        /// Euclidean method of counting the gcd.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The gcd of two numbers.</returns>
        private static int EuclideanMethod(int a, int b)
        {
            return b == 0 ? a : EuclideanMethod(b, a % b);
        }

        /// <summary>
        /// Stein's method of counting the gcd.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The gcd of two numbers.</returns>
        private static int BinaryMethod(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if ((~a & 1) == 1)
            {
                if ((b & 1) == 1)
                {
                    return BinaryMethod(a >> 1, b);
                }
                else
                {
                    return BinaryMethod(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) == 1)
            {
                return BinaryMethod(a, b >> 1);
            }

            if (a > b)
            {
                return BinaryMethod((a - b) >> 1, b);
            }

            return BinaryMethod((b - a) >> 1, a);
        }
    }
}

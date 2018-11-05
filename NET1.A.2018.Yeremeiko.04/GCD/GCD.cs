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
        public static int GCDEuclidean(out int milliseconds, params int[] numbers) => GCDCount(out milliseconds, EuclideanMethod, numbers);

        /// <summary>
        /// Defines the gcd of two numbers using euclidean method.
        /// </summary>
        /// <param name="milliseconds">The milliseconds algorithm need for work.</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <exception cref="ArgumentException">Arguments shouldn't be <see cref="Int32.MinValue"/>.</exception>
        /// <returns>The GCD of two numbers.</returns>
        public static int GCDEuclidean(out int milliseconds, int firstNumber, int secondNumber) => GCDCount(out milliseconds, EuclideanMethod, firstNumber, secondNumber);

        /// <summary>
        /// Defines the gcd of three numbers using euclidean method.
        /// </summary>
        /// <param name="milliseconds">The milliseconds algorithm need for work..</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <exception cref="ArgumentException">Arguments shouldn't be <see cref="Int32.MinValue"/>.</exception>
        /// <returns>The GCD of three numbers.</returns>
        public static int GCDEuclidean(out int milliseconds, int firstNumber, int secondNumber, int thirdNumber) => GCDCount(out milliseconds, EuclideanMethod, firstNumber, secondNumber, thirdNumber);

        /// <summary>
        /// Defines the gcd for integers using the stein's method.
        /// </summary>
        /// <param name="numbers">The array containing numbers of all possible value except <see cref="Int32.MinValue"/>.</param>
        /// <returns>The gcd of numbers.</returns>
        /// <exception cref="ArgumentException"><see cref="numbers"/> shouldn't contain <see cref="Int32.MinValue"/>.</exception>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static int GCDBinary(out int milliseconds, params int[] numbers) => GCDCount(out milliseconds, BinaryMethod, numbers);

        /// <summary>
        /// Defines the gcd of two numbers using stein's method.
        /// </summary>
        /// <param name="milliseconds">The milliseconds algorithm need for work.</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <exception cref="ArgumentException">Arguments shouldn't be <see cref="Int32.MinValue"/>.</exception>
        /// <returns>The GCD of two numbers.</returns>
        public static int GCDBinary(out int milliseconds, int firstNumber, int secondNumber) => GCDCount(out milliseconds, BinaryMethod, firstNumber, secondNumber);

        /// <summary>
        /// Defines the gcd of three numbers using stein's method.
        /// </summary>
        /// <param name="milliseconds">The milliseconds algorithm need for work..</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <exception cref="ArgumentException">Arguments shouldn't be <see cref="Int32.MinValue"/>.</exception>
        /// <returns>The GCD of three numbers.</returns>
        public static int GCDBinary(out int milliseconds, int firstNumber, int secondNumber, int thirdNumber) => GCDCount(out milliseconds, BinaryMethod, firstNumber, secondNumber, thirdNumber);
        
        /// <summary>
        /// Counts the gcd.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="method">The method of gcd count.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>The gcd.</returns>
        private static int GCDCount(out int milliseconds, Func<int, int, int> method, params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers[0] == int.MinValue)
            {
                throw new ArgumentException($"{nameof(numbers)} shouldn't contain {nameof(int.MinValue)}.");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

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

                gcd = method.Invoke(gcd, numbers[i]);
            }

            stopWatch.Stop();
            milliseconds = stopWatch.Elapsed.Milliseconds;

            return gcd;
        }

        /// <summary>
        /// Counts the gcd.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="method">The method. of gcd count.</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The gcd</returns>
        private static int GCDCount(out int milliseconds, Func<int, int, int> method, int firstNumber, int secondNumber)
        {
            if (firstNumber == int.MinValue || secondNumber == int.MinValue)
            {
                throw new ArgumentException($"Arguments shouldn't be {nameof(int.MinValue)}.");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (firstNumber < 0)
            {
                firstNumber *= -1;
            }

            if (secondNumber < 0)
            {
                secondNumber *= -1;
            }

            int gcd = method.Invoke(firstNumber, secondNumber);

            stopWatch.Stop();
            milliseconds = stopWatch.Elapsed.Milliseconds;

            return gcd;
        }

        /// <summary>
        /// Counts the gcd.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="method">The method of gcd count.</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns>The gcd.</returns>
        private static int GCDCount(out int milliseconds, Func<int, int, int> method, int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber == int.MinValue || secondNumber == int.MinValue || thirdNumber == int.MinValue)
            {
                throw new ArgumentException($"Arguments shouldn't be {nameof(int.MinValue)}.");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (firstNumber < 0)
            {
                firstNumber *= -1;
            }

            if (secondNumber < 0)
            {
                secondNumber *= -1;
            }

            if (thirdNumber < 0)
            {
                thirdNumber *= -1;
            }

            int gcd = EuclideanMethod(EuclideanMethod(firstNumber, secondNumber), thirdNumber);
            stopWatch.Stop();
            milliseconds = stopWatch.Elapsed.Milliseconds;

            return gcd;
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

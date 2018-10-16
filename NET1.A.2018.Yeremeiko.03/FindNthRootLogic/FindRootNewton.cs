using System;

namespace FindNthRootLogic
{
    /// <summary>
    /// Contains the logic of finding the Nth root of number with certain accurancy.
    /// </summary>
    public static class FindRootNewton
    {
        /// <summary>
        /// Finds the Nth root of number with certain accurancy.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="n">The rank of root.</param>
        /// <param name="accurancy">The accurancy of nth root.</param>
        /// <returns>The Nth root of number.</returns>
        /// <exception cref="System.ArgumentException">Arguments need to be non negative.</exception>
        public static double FindNthRoot(double number, int n, double accurancy)
        {
            if (number < 0 && ((n & 1) == 0))
            {
                throw new ArgumentException($"{nameof(number)} need to be non negative if {nameof(n)} is even.");
            }

            if (n <= 0)
            {
                throw new ArgumentException($"{nameof(n)} need to be positive.");
            }

            if (accurancy < 0)
            {
                throw new ArgumentException($"{nameof(accurancy)} need to be non negative.");
            }
            
            double x0 = number / n;
            double x1 = FindNextX(number, x0, n);
            
            while (Math.Abs(x1 - x0) > accurancy)
            {
                x0 = x1;
                x1 = FindNextX(number, x0, n);
            }

            return x1;
        }

        /// <summary>
        /// Finds the next x in Newton method.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="x0">The initial assumption.</param>
        /// <param name="n">The rank of root.</param>
        /// <returns></returns>
        private static double FindNextX(double number, double x0, int n)
        {
            return (1.0 / n) * (((n - 1) * x0) + (number / Math.Pow(x0, n - 1)));
        }
    }
}

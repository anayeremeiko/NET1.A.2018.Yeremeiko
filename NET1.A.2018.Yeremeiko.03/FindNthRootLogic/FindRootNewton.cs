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
        /// <param name="degree">The degree of root.</param>
        /// <param name="accurancy">The accurancy of nth root.</param>
        /// <returns>The Nth root of number.</returns>
        /// <exception cref="System.ArgumentException">Arguments need to be non negative.</exception>
        public static double FindNthRoot(double number, int degree, double accurancy)
        {
            if (number < 0 && ((degree & 1) == 0))
            {
                throw new ArgumentException($"{nameof(number)} need to be non negative if {nameof(degree)} is even.");
            }

            if (degree <= 0)
            {
                throw new ArgumentException($"{nameof(degree)} need to be positive.");
            }

            if (accurancy < 0)
            {
                throw new ArgumentException($"{nameof(accurancy)} need to be non negative.");
            }
            
            double current = number / degree;
            double next = FindNextX(number, current, degree);
            
            while (Math.Abs(next - current) > accurancy)
            {
                current = next;
                next = FindNextX(number, current, degree);
            }

            return next;
        }

        /// <summary>
        /// Finds the next x in Newton method.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="current">The initial assumption.</param>
        /// <param name="degree">The degree of root.</param>
        /// <returns></returns>
        private static double FindNextX(double number, double current, int degree) => (1.0 / degree) * (((degree - 1) * current) + (number / Math.Pow(current, degree - 1)));
    }
}

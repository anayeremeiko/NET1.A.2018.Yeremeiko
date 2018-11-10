using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DoubleExtension;

namespace DoubleArrayExtension
{
    public delegate string Transformer(double number);

    /// <summary>
    /// Contains logic of transforming double number to it's word equivalent.
    /// </summary>
    public static class NumbersToString
    {
        /// <summary>
        /// Transforms the double array.
        /// </summary>
        /// <param name="transformer">The transformer.</param>
        /// <param name="array">The array.</param>
        /// <returns>Transformed array.</returns>
        /// <exception cref="ArgumentNullException">Array need to be not null.</exception>
        public static string[] TransformDoubleArray(ITransformer<double, string> transformer, params double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} need not null array");
            }
            
            string[] stringArray = new string[array.Length];
            int i = 0;
            foreach (double element in array)
            {
                stringArray[i] = transformer.Transform(element);
                i++;
            }

            return stringArray;
        }

        /// <summary>
        /// Transforms the double array.
        /// </summary>
        /// <param name="transformer">The transformer.</param>
        /// <param name="array">The array.</param>
        /// <returns>Transformed array.</returns>
        /// <exception cref="ArgumentNullException">Array need to be not null.</exception>
        public static string[] TransformDoubleArray(Transformer transformer, params double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} need not null array");
            }

            string[] stringArray = new string[array.Length];
            int i = 0;
            foreach (double element in array)
            {
                stringArray[i] = transformer.Invoke(element);
                i++;
            }

            return stringArray;
        }
    }
}

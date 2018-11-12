using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtension
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Converts numbers.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="numbers">The numbers.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed numbers.</returns>
        /// <exception cref="System.ArgumentNullException">Transformer and numbers need to be not null.</exception>
        public static IEnumerable<TResult> TransformTo<TInput, TResult>(this TInput[] numbers, ITransformer<TInput, TResult> transformer)
        {
            InputValidation(numbers);
            if (transformer == null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} need to be not null.");
            }

            return numbers.TransformTo(transformer.Transform);
        }

        /// <summary>
        /// Converts numbers.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="numbers">The numbers.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed numbers.</returns>
        /// <exception cref="System.ArgumentNullException">Transformer and numbers need to be not null.</exception>
        public static IEnumerable<TResult> TransformTo<TInput, TResult>(this TInput[] numbers, Func<TInput, TResult> transformer)
        {
            InputValidation(numbers);
            if (transformer == null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} need to be not null.");
            }

            TResult[] result = new TResult[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = transformer(numbers[i]);
            }

            return result;
        }

        /// <summary>
        /// Filters the source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Filtered source.</returns>
        /// <exception cref="System.ArgumentNullException">Source or filter need to be not null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this TSource[] source, IFilter<TSource> filter)
        {
            InputValidation(source);
            if (filter == null)
            {
                throw new ArgumentNullException($"{nameof(filter)} need to be not null.");
            }

            return source.Filter(filter.FilterSource);
        }

        /// <summary>
        /// Filters the source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Filtered source.</returns>
        /// <exception cref="System.ArgumentNullException">Source or filter need to be not null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this TSource[] source, Predicate<TSource> filter)
        {
            InputValidation(source);
            if (filter == null)
            {
                throw new ArgumentNullException($"{nameof(filter)} need to be not null.");
            }

            List<TSource> result = new List<TSource>();
            foreach (var number in source)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Validation.
        /// </summary>
        /// <typeparam name="T">The type of the numbers</typeparam>
        /// <param name="numbers">The numbers.</param>
        /// <exception cref="System.ArgumentNullException">Numbers need to be not null.</exception>
        private static void InputValidation<T>(T[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(numbers)} need to be not null.");
            }
        }
    }
}

using System;
using System.Text;

namespace DoubleArrayExtension
{
    /// <summary>
    /// Contains logic of transforming double number to it's word equivalent.
    /// </summary>
    public static class NumbersToString
    {
        /// <summary>
        /// Converts double numbers to their word equivalent.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>String array containing word equivalent of double numbers.</returns>
        /// <exception cref="ArgumentNullException">Need not null array.</exception>
        public static string[] TransformToWords(params double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array));
            }

            string[] stringArray = new string[array.Length];
            int i = 0;
            foreach (double element in array)
            {
                stringArray[i] = ConvertToString(element.ToString());
                i++;
            }

            return stringArray;
        }

        /// <summary>
        /// Converts double in string format to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Number in words.</returns>
        private static string ConvertToString(string number)
        {
            StringBuilder stringNumber = new StringBuilder();
            foreach (char symbol in number)
            {
                switch (symbol)
                {
                    case '-':
                        stringNumber.Append("minus ");
                        break;
                    case '0':
                        stringNumber.Append("zero ");
                        break;
                    case '1':
                        stringNumber.Append("one ");
                        break;
                    case '2':
                        stringNumber.Append("two ");
                        break;
                    case '3':
                        stringNumber.Append("three ");
                        break;
                    case '4':
                        stringNumber.Append("four ");
                        break;
                    case '5':
                        stringNumber.Append("five ");
                        break;
                    case '6':
                        stringNumber.Append("six ");
                        break;
                    case '7':
                        stringNumber.Append("seven ");
                        break;
                    case '8':
                        stringNumber.Append("eight ");
                        break;
                    case '9':
                        stringNumber.Append("nine ");
                        break;
                    case '.':
                    case ',':
                        stringNumber.Append("point ");
                        break;
                }
            }

            return stringNumber.ToString();
        }
    }
}

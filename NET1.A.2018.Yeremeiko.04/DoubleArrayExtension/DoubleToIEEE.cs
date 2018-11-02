using DoubleExtension;

namespace DoubleArrayExtension
{
    public class DoubleToIEEE : ITransformer
    {
        /// <summary>
        /// Transforms double number to IEEE format.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Binary representation of number.</returns>
        public string Transform(double number)
        {
            return number.ToBinary();
        }
    }
}

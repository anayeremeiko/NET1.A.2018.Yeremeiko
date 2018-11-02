using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleArrayExtension
{
    public interface ITransformer
    {
        /// <summary>
        /// Transforms the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Transformed number.</returns>
        string Transform(double number);
    }
}

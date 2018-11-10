using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtension
{
    public interface IFilter<in TSource>
    {
        /// <summary>
        /// Filters the source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The filtered source.</returns>
        bool FilterSource(TSource source);
    }
}

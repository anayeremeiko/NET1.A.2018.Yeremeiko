using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtension.Tests
{
    public class IntFilter : IFilter<int>
    {
        /// <summary>
        /// Defines if source is even.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True is even, false otherwise.</returns>
        public bool FilterSource(int source)
        {
            return source % 2 == 0 ? true : false;
        }
    }
}

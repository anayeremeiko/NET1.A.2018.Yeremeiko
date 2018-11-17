using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Tests
{
    public class PointComparer : IComparer<BinarySearchTreeTests.Point>
    {
        public int Compare(BinarySearchTreeTests.Point x, BinarySearchTreeTests.Point y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return -1;
            }

            return x.X - y.X;
        }
    }
}

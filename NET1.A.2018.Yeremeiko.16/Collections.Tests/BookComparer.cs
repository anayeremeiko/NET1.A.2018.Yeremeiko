using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace Collections.Tests
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return -1;
            }

            return x.Pages - y.Pages;
        }
    }
}

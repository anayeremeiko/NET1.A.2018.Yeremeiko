using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using NUnit.Framework;

namespace Collections.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void CreateIntTree()
        {
            new BinarySearchTree<int>();
        }

        [Test]
        public void CreateStringTree()
        {
            new BinarySearchTree<string>();
        }

        [Test]
        public void CreatePointTree_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BinarySearchTree<Point>());
        }

        [Test]
        public void CreateBookTree()
        {
            new BinarySearchTree<Book>();
        }

        [Test]
        public void IntTree_Contains()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(48);
            tree.Insert(22);
            tree.Insert(10);
            tree.Insert(1);
            tree.Insert(15);
            tree.Insert(75);
            tree.Insert(59);
            tree.Insert(60);
            Assert.IsTrue(tree.Contains(22));
        }

        [Test]
        public void IntTree_InOrder()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(48);
            tree.Insert(22);
            tree.Insert(10);
            tree.Insert(28);
            tree.Insert(17);
            tree.Insert(1);
            tree.Insert(15);
            tree.Insert(75);
            tree.Insert(77);
            tree.Insert(59);
            tree.Insert(60);
            CollectionAssert.AreEqual(new[] { 1, 10, 15, 17, 22, 28, 48, 59, 60, 75, 77 }, tree.InOrder());
        }

        [Test]
        public void IntTree_PreOrder()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(48);
            tree.Insert(22);
            tree.Insert(10);
            tree.Insert(28);
            tree.Insert(17);
            tree.Insert(1);
            tree.Insert(15);
            tree.Insert(75);
            tree.Insert(77);
            tree.Insert(59);
            tree.Insert(60);
            CollectionAssert.AreEqual(new[] { 48, 22, 10, 1, 17, 15, 28, 75, 59, 60, 77 }, tree.PreOrder());
        }

        [Test]
        public void IntTree_PostOrder_CustomComparer()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(Comparer<int>.Create((a, b) => a - b));
            tree.Insert(48);
            tree.Insert(22);
            tree.Insert(10);
            tree.Insert(28);
            tree.Insert(17);
            tree.Insert(1);
            tree.Insert(15);
            tree.Insert(75);
            tree.Insert(77);
            tree.Insert(59);
            tree.Insert(60);
            CollectionAssert.AreEqual(new[] { 1, 15, 17, 10, 28, 22, 60, 59, 77, 75, 48 }, tree.PostOrder());
        }

        [Test]
        public void StringTree_Contains()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("hello");
            tree.Insert("it's");
            tree.Insert("me");
            tree.Insert("Hello");
            tree.Insert("can");
            tree.Insert("you");
            Assert.IsTrue(tree.Contains("Hello"));
        }

        [Test]
        public void StringTree_Contains_Not()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("hello");
            tree.Insert("it's");
            tree.Insert("me");
            tree.Insert("Hello");
            tree.Insert("can");
            tree.Insert("you");
            Assert.IsFalse(tree.Contains("You"));
        }

        [Test]
        public void StringTree_InOrder()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("hello");
            tree.Insert("it's");
            tree.Insert("me");
            tree.Insert("Hello");
            tree.Insert("can");
            tree.Insert("you");
            tree.Insert("hear me");
            tree.Insert("I was");
            tree.Insert("wondering");
            CollectionAssert.AreEqual(new[] { "can", "hear me", "hello", "Hello", "I was", "it's", "me", "wondering", "you" }, tree.InOrder());
        }

        [Test]
        public void StringTree_PreOrder_CustomComparer()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(StringComparer.Create(CultureInfo.CurrentCulture, false));
            tree.Insert("hello");
            tree.Insert("it's");
            tree.Insert("me");
            tree.Insert("Hello");
            tree.Insert("can");
            tree.Insert("you");
            tree.Insert("hear me");
            tree.Insert("I was");
            tree.Insert("wondering");
            CollectionAssert.AreEqual(new[] { "hello", "can", "hear me", "it's", "Hello", "I was", "me", "you", "wondering" }, tree.PreOrder());
        }

        [Test]
        public void StringTree_PostOrder()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("hello");
            tree.Insert("it's");
            tree.Insert("me");
            tree.Insert("Hello");
            tree.Insert("can");
            tree.Insert("you");
            tree.Insert("hear me");
            tree.Insert("I was");
            tree.Insert("wondering");
            CollectionAssert.AreEqual(new[] { "hear me", "can", "I was", "Hello", "wondering", "you", "me", "it's", "hello" }, tree.PostOrder());
        }

        [Test]
        public void BookTree_InOrder()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>();
            tree.Insert(new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10));
            tree.Insert(new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2));
            tree.Insert(new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5));
            tree.Insert(new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4));
            tree.Insert(new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12));
            CollectionAssert.AreEqual(
                new[]
            {
                new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2),
                new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4),
                new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5),
                new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10),
                new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12)
            }, 
                tree.InOrder());
        }

        [Test]
        public void BookTree_InOrder_PageComparer()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(
                new BookComparer());
            tree.Insert(new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10));
            tree.Insert(new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2));
            tree.Insert(new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5));
            tree.Insert(new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4));
            tree.Insert(new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12));
            CollectionAssert.AreEqual(
                new[]
            {
                new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2),
                new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4),
                new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5),
                new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10),
                new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12)
            }, 
                tree.InOrder());
        }

        [Test]
        public void BookTree_PreOrder()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>();
            tree.Insert(new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10));
            tree.Insert(new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2));
            tree.Insert(new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5));
            tree.Insert(new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4));
            tree.Insert(new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12));
            CollectionAssert.AreEqual(
                new[]
            {
                new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10),
                new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2),
                new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5),
                new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4),
                new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12)
            }, 
                tree.PreOrder());
        }

        [Test]
        public void BookTree_PreOrder_PageComparer()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new BookComparer());
            tree.Insert(new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10));
            tree.Insert(new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2));
            tree.Insert(new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5));
            tree.Insert(new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4));
            tree.Insert(new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12));
            CollectionAssert.AreEqual(
                new[]
            {
                new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10),
                new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2),
                new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5),
                new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4),
                new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12)
            }, 
                tree.PreOrder());
        }

        [Test]
        public void BookTree_PostOrder()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>();
            tree.Insert(new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10));
            tree.Insert(new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2));
            tree.Insert(new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5));
            tree.Insert(new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4));
            tree.Insert(new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12));
            CollectionAssert.AreEqual(
                new[]
            {
                new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4),
                new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5),
                new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2),
                new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12),
                new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10),
            }, 
                tree.PostOrder());
        }

        [Test]
        public void BookTree_PostOrder_PageComparer()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>();
            tree.Insert(new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10));
            tree.Insert(new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2));
            tree.Insert(new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5));
            tree.Insert(new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4));
            tree.Insert(new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12));
            CollectionAssert.AreEqual(
                new[]
            {
                new Book("Dubrovskiy", "Pushkin", 1999, "AST", 3, 150, 4),
                new Book("Assassin", "Unknown", 2010, "EKSMO", 1, 200, 5),
                new Book("Red Hat", "Andersen", 2012, "AST", 4, 30, 2),
                new Book("War and peace", "Tolstoy", 2000, "St", 5, 600, 12),
                new Book("C#", "J.Skeet", 2015, "BH", 1, 400, 10),
            }, 
                tree.PostOrder());
        }

        [Test]
        public void PointTree_InOrder()
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointComparer());
            tree.Insert(new Point() { X = 48 });
            tree.Insert(new Point() { X = 22 });
            tree.Insert(new Point() { X = 10 });
            tree.Insert(new Point() { X = 28 });
            tree.Insert(new Point() { X = 17 });
            tree.Insert(new Point() { X = 1 });
            tree.Insert(new Point() { X = 15 });
            tree.Insert(new Point() { X = 75 });
            tree.Insert(new Point() { X = 77 });
            tree.Insert(new Point() { X = 59 });
            tree.Insert(new Point() { X = 60 });
            CollectionAssert.AreEqual(
                new[] 
                {
                new Point() { X = 1 },
                new Point() { X = 10 },
                new Point() { X = 15 },
                new Point() { X = 17 },
                new Point() { X = 22 },
                new Point() { X = 28 },
                new Point() { X = 48 },
                new Point() { X = 59 },
                new Point() { X = 60 },
                new Point() { X = 75 },
                new Point() { X = 77 }
                }, 
                tree.InOrder(), 
                Comparer<Point>.Create((p1, p2) => p1.X.CompareTo(p2.X)));
        }

        [Test]
        public void PointTree_PreOrder()
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointComparer());
            tree.Insert(new Point() { X = 48 });
            tree.Insert(new Point() { X = 22 });
            tree.Insert(new Point() { X = 10 });
            tree.Insert(new Point() { X = 28 });
            tree.Insert(new Point() { X = 17 });
            tree.Insert(new Point() { X = 1 });
            tree.Insert(new Point() { X = 15 });
            tree.Insert(new Point() { X = 75 });
            tree.Insert(new Point() { X = 77 });
            tree.Insert(new Point() { X = 59 });
            tree.Insert(new Point() { X = 60 });
            CollectionAssert.AreEqual(
                new[] 
                {
                    new Point() { X = 48 },
                    new Point() { X = 22 },
                    new Point() { X = 10 },
                    new Point() { X = 1 },
                    new Point() { X = 17 },
                    new Point() { X = 15 },
                    new Point() { X = 28 },
                    new Point() { X = 75 },
                    new Point() { X = 59 },
                    new Point() { X = 60 },
                    new Point() { X = 77 }
                },
                tree.PreOrder(), 
                Comparer<Point>.Create((p1, p2) => p1.X.CompareTo(p2.X)));
        }

        [Test]
        public void PointTree_PostOrder()
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointComparer());
            tree.Insert(new Point() { X = 48 });
            tree.Insert(new Point() { X = 22 });
            tree.Insert(new Point() { X = 10 });
            tree.Insert(new Point() { X = 28 });
            tree.Insert(new Point() { X = 17 });
            tree.Insert(new Point() { X = 1 });
            tree.Insert(new Point() { X = 15 });
            tree.Insert(new Point() { X = 75 });
            tree.Insert(new Point() { X = 77 });
            tree.Insert(new Point() { X = 59 });
            tree.Insert(new Point() { X = 60 });
            CollectionAssert.AreEqual(
                new[] 
                {
                    new Point() { X = 1 },
                    new Point() { X = 15 },
                    new Point() { X = 17 },
                    new Point() { X = 10 },
                    new Point() { X = 28 },
                    new Point() { X = 22 },
                    new Point() { X = 60 },
                    new Point() { X = 59 },
                    new Point() { X = 77 },
                    new Point() { X = 75 },
                    new Point() { X = 48 }
                },
                tree.PostOrder(), 
                Comparer<Point>.Create((p1, p2) => p1.X.CompareTo(p2.X)));
        }

        public class Point
        {
            public int X { get; set; }

            public override string ToString()
            {
                return $"{X}";
            }
        }
    }
}

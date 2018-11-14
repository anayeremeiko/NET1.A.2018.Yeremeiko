using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Collections.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Queue_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Queue<int>(null));
        }

        [Test]
        public void Queue_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Queue<string>(-1));
        }

        [Test]
        public void Enqueue_IntQueue()
        {
            var intQueue = new Queue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);

            CollectionAssert.AreEqual(new[] { 1, 2 }, intQueue.ToArray());
        }

        [Test]
        public void Enqueue_StringQueue_WithResize()
        {
            var stringQueue = new Queue<string>(1);
            stringQueue.Enqueue("test");
            stringQueue.Enqueue("cat");

            CollectionAssert.AreEqual(new[] { "test", "cat" }, stringQueue.ToArray());
        }

        [Test]
        public void Enqueue_PointQueue()
        {
            var pointQueue = new Queue<Point>();
            pointQueue.Enqueue(new Point() { X = 1, Y = 2 });

            CollectionAssert.AreEqual(new[] { new Point() { X = 1, Y = 2 } }, pointQueue.ToArray());
        }

        [Test]
        public void Peek_IntQueue()
        {
            var intQueue = new Queue<int>(2);
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);

            Assert.AreEqual(1, intQueue.Peek());
        }

        [Test]
        public void Peek_StringQueue()
        {
            var stringQueue = new Queue<string>(2);
            stringQueue.Enqueue("test");
            stringQueue.Enqueue("cat");

            Assert.AreEqual("test", stringQueue.Peek());
        }

        [Test]
        public void Peek_PointQueue()
        {
            var pointQueue = new Queue<Point>(2);
            pointQueue.Enqueue(new Point() { X = 1, Y = 2 });
            pointQueue.Enqueue(new Point() { X = 3, Y = 5 });

            Assert.AreEqual(new Point() { X = 1, Y = 2 }, pointQueue.Peek());
        }

        [Test]
        public void Peek_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new Queue<int>().Peek());
        }

        [Test]
        public void Dequeue_IntQueue()
        {
            var intQueue = new Queue<int>(5);
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);

            intQueue.Dequeue();

            CollectionAssert.AreEqual(new[] { 2 }, intQueue.ToArray());
        }

        [Test]
        public void Dequeue_StringQueue()
        {
            var stringQueue = new Queue<string>();
            stringQueue.Enqueue("pop");
            stringQueue.Enqueue("test");
            stringQueue.Enqueue("cat");

            stringQueue.Dequeue();

            CollectionAssert.AreEqual(new[] { "test", "cat" }, stringQueue.ToArray());
        }

        [Test]
        public void Dequeue_PointQueue()
        {
            var pointQueue = new Queue<Point>();
            pointQueue.Enqueue(new Point() { X = 1, Y = 2 });
            pointQueue.Enqueue(new Point() { X = 3, Y = 5 });
            pointQueue.Enqueue(new Point() { X = 2, Y = 4 });

            pointQueue.Dequeue();

            CollectionAssert.AreEqual(new[] { new Point() { X = 3, Y = 5 }, new Point() { X = 2, Y = 4 } }, pointQueue.ToArray());
        }

        [Test]
        public void Dequeue_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new Queue<string>().Dequeue());
        }

        [Test]
        public void IsEmpty_PointQueue()
        {
            var queue = new Queue<Point>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void IsEmpty_StringQueue()
        {
            var queue = new Queue<string>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void IsEmpty_IntQueue()
        {
            var queue = new Queue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Contains_IntQueue_True()
        {
            var queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(queue.Contains(2));
        }

        [Test]
        public void Contains_IntQueue_False()
        {
            var queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.IsFalse(queue.Contains(0));
        }

        [Test]
        public void Contains_StringQueue_True()
        {
            var queue = new Queue<string>(new[] { "pop", "push", "add" });
            Assert.IsTrue(queue.Contains("pop"));
        }

        [Test]
        public void Contains_StringQueue_False()
        {
            var queue = new Queue<string>(new[] { "pop", "push", "add" });
            Assert.IsFalse(queue.Contains("remove"));
        }

        [Test]
        public void Contains_PointQueue_True()
        {
            var queue = new Queue<Point>(new[] { new Point(1, 2), new Point(2, 3) });
            Assert.IsTrue(queue.Contains(new Point(1, 2)));
        }

        [Test]
        public void Contains_PointQueue_False()
        {
            var queue = new Queue<Point>(new[] { new Point(1, 2), new Point(2, 3) });
            Assert.IsFalse(queue.Contains(new Point(1, 0)));
        }

        public class Point : IEquatable<Point>
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point()
            {
            }

            public int X { get; set; }

            public int Y { get; set; }

            public bool Equals(Point p)
            {
                if (p == null)
                {
                    return false;
                }

                return p.X == X && p.Y == Y;
            }

            public override string ToString()
            {
                return $"{X}, {Y}";
            }
        }
    }
}

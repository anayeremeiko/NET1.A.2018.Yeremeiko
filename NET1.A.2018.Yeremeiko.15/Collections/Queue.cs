using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _start;
        private int _end;
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentException">Size need to be non negative.</exception>
        public Queue(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} need to be non negative.");
            }

            _queue = new T[size];
            _start = 0;
            _end = 0;
            Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue() : this(20)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="ArgumentNullException">Data need to be not null.</exception>
        public Queue(ICollection<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"{nameof(data)} need to be not null.");
            }

            _queue = new T[data.Count];
            Count = _queue.Length;
            foreach (T element in data)
            {
                Enqueue(element);
            }
        }

        /// <summary>
        /// Gets the number of element contained in Queue.
        /// </summary>
        /// <value>
        /// The number of elements is Queue.
        /// </value>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Enqueue(T element)
        {
            if (Count == _queue.Length)
            {
                Array.Resize(ref _queue, _queue.Length * 2);
            }

            _queue[_end++] = element;
            Count++;
            version++;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>The peek without deleting it.</returns>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException($"{nameof(_queue)} is empty.");
            }

            return _queue[_start];
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>The peek.</returns>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException($"{nameof(_queue)} is empty.");
            }

            T result = _queue[_start];
            Count--;
            _queue[_start++] = default(T);
            _start %= _queue.Length;
            version++;
            return result;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator((Queue<T>)this);

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public Enumerator GetEnumerator() => new Enumerator((Queue<T>)this);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => new Enumerator((Queue<T>)this);

        /// <summary>
        /// Sets the capacity of Queue to it's actual number, if the capacity is less then 90 percent of actual size.
        /// </summary>
        public void TrimExcess()
        {
            if (_queue.Length * 0.1 <= Count)
            {
                return;
            }

            T[] newQueue = new T[Count];
            Array.Copy(_queue, _start, newQueue, 0, Count);
            _queue = newQueue;
            _start = 0;
            _end = Count;
        }

        /// <summary>
        /// Copies the Queue elements to new array.
        /// </summary>
        /// <returns>Array.</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int k = 0;
            for (int i = _start; i < _end; i++)
            {
                array[k++] = _queue[i];
            }

            return array;
        }

        /// <summary>
        /// Copies elements of Queue in specified array from index.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <param name="startIndex">The index.</param>
        public void CopyTo(T[] array, int startIndex)
        {
            for (int i = _start; i <= _end; i++)
            {
                array[startIndex++] = _queue[i];
            }
        }

        /// <summary>
        /// Checks if item contains in the Queue.
        /// </summary>
        /// <param name="item">An item.</param>
        /// <returns>True if contains, false otherwise.</returns>
        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = _start; i < _end; i++)
            {
                if (item == null)
                {
                    if (_queue[i] == null)
                    {
                        return true;
                    }
                }
                else if (_queue[i] != null && comparer.Equals(_queue[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly Queue<T> _queue;
            private readonly int _version;
            private int _index;
            private T _currentElement;

            public Enumerator(Queue<T> queue)
            {
                _queue = queue;
                _version = queue.version;
                _index = _queue._start;
                _currentElement = default(T);
            }

            /// <summary>
            /// Current item.
            /// </summary>
            public T Current
            {
                get
                {
                    if (_version != _queue.version || (_index == (_queue._end + 1)))
                    {
                        throw new InvalidOperationException("Queue was modified!");
                    }

                    return _currentElement;
                }
            }

            /// <summary>
            /// The current object.
            /// </summary>
            object IEnumerator.Current => Current;

            /// <summary>
            /// Disposes the Enumerator.
            /// </summary>
            public void Dispose()
            {
                if (_version != _queue.version)
                {
                    throw new InvalidOperationException("Queue was modified!");
                }
            }

            /// <summary>
            /// Checks if collection contains next element.
            /// </summary>
            /// <returns>True if next item exists, false otherwise.</returns>
            public bool MoveNext()
            {
                if (_version != _queue.version)
                {
                    throw new InvalidOperationException("Queue was modified!");
                }

                if (_index < _queue._end)
                {
                    _currentElement = _queue._queue[_index];
                    _index++;
                    return true;
                }

                return false;
            }

            /// <summary>
            /// Resets the enumerator.
            /// </summary>
            public void Reset()
            {
                if (_version != _queue.version)
                {
                    throw new InvalidOperationException("Queue was modified!");
                }

                _index = 0;
                _currentElement = default(T);
            }
        }
    }
}

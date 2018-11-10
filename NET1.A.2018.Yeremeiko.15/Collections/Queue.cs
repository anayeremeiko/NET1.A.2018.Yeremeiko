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
            _start = size - 1;
            _end = size - 1;
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
        public Queue(ICollection<T> data)
        {
            _queue = new T[data.Count];
            foreach (T element in data)
            {
                Enqueue(element);
            }
        }

        /// <summary>
        /// The length of queue.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length { get; private set; }

        /// <summary>
        /// Enqueues the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Enqueue(T element)
        {
            if (Length == _queue.Length)
            {
                SetCapacity(_queue.Length * 2);
            }

            _queue[_end++] = element;
            Length++;
            _end %= _queue.Length;
        }

        /// <summary>
        /// Returns the peek without deleting it.
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
        /// Dequeues this instance.
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
            Length--;
            _queue[_start++] = default(T);
            _start %= _queue.Length;
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => Length == 0;

        /// <summary>
        /// Converts to size.
        /// </summary>
        public void TrimToSize()
        {
            T[] newQueue = new T[Length];
            Array.Copy(_queue, _start, newQueue, 0, Length);
            _queue = newQueue;
            _start = 0;
            _end = Length;
        }
        
        private void SetCapacity(int capacity)
        {
            T[] newQueue = new T[capacity];
            if (Length > 0)
            {
                Array.Copy(_queue, _start, newQueue, 0, _queue.Length - _start);
                Array.Copy(_queue, 0, newQueue, _queue.Length - _start, _end);
            }

            _queue = newQueue;
            _start = 0;
            _end = Length;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_queue).GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_queue).GetEnumerator();
    }
}

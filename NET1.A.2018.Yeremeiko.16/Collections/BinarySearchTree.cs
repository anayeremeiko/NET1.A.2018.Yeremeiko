using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node root;
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentException"><see cref="T"/> need to be comparable.</exception>
        public BinarySearchTree()
        {
            if (!typeof(T).GetInterfaces().Contains(typeof(IComparable)) && !typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
            {
                throw new ArgumentException($"{nameof(T)} need to be comparable.");
            }

            root = null;
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"><see cref="comparer"/> need to be not null.</exception>
        public BinarySearchTree(IComparer<T> comparer)
        {
            root = null;
            this.comparer = comparer ?? throw new ArgumentNullException($"{nameof(comparer)} need to be not null.");
        }

        /// <summary>
        /// Inserts the item in the tree.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException"><see cref="item"/> need to be not null.</exception>
        public void Insert(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{nameof(item)} need to be not null.");
            }

            if (root == null)
            {
                root = new Node() { Item = item };
            }
            
            Insert(item, root);
        }

        /// <summary>
        /// Defines if tree contains specified element.
        /// </summary>
        /// <param name="item">The element.</param>
        /// <returns>True if contains, false otherwise.</returns>
        public bool Contains(T item)
        {
            if (item == null)
            {
                return false;
            }

            return Find(item, root) != null;
        }

        /// <summary>
        /// Returns an enumerator that iterates in in-order through a collection
        /// </summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerable<T> InOrder()
        {
            if (root == null)
            {
                throw new ArgumentException("Tree is empty.");
            }

            return InOrderEnumerator(root);
        }

        /// <summary>
        /// Returns an enumerator that iterates in pre-order through a collection
        /// </summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerable<T> PreOrder()
        {
            if (root == null)
            {
                throw new ArgumentException("Tree is empty.");
            }

            return PreOrderEnumerator(root);
        }

        /// <summary>
        /// Returns an enumerator that iterates in post-order through a collection
        /// </summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerable<T> PostOrder()
        {
            if (root == null)
            {
                throw new ArgumentException("Tree is empty.");
            }

            return PostOrderEnumerator(root);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns>An object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        /// <summary>
        /// Inserts item in the tree.
        /// </summary>
        /// <param name="item">Item to insert.</param>
        /// <param name="current">Current node of tree.</param>
        private void Insert(T item, Node current)
        {
            if (comparer.Compare(current.Item, item) > 0)
            {
                if (current.Left == null)
                {
                    current.Left = new Node() { Item = item };
                }
                else
                {
                    Insert(item, current.Left);
                }
            }

            if (comparer.Compare(current.Item, item) < 0)
            {
                if (current.Right == null)
                {
                    current.Right = new Node() { Item = item };
                }
                else
                {
                    Insert(item, current.Right);
                }
            }
        }

        /// <summary>
        /// Finds the most left node.
        /// </summary>
        /// <param name="current">Current node.</param>
        /// <returns>The most left node.</returns>
        private Node FindSuccessor(Node current)
        {
            if (current.Left == null)
            {
                return current;
            }

            return FindSuccessor(current);
        }

        /// <summary>
        /// Finds the <see cref="Node"/> item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="current">Current node.</param>
        /// <returns>Specified node if finds, null otherwise.</returns>
        private Node Find(T item, Node current)
        {
            if (current == null)
            {
                return null;
            }

            if (comparer.Compare(current.Item, item) > 0)
            {
                return Find(item, current.Left);
            }

            if (comparer.Compare(current.Item, item) < 0)
            {
                return Find(item, current.Right);
            }

            return comparer.Compare(current.Item, item) == 0 ? current : null;
        }

        /// <summary>
        /// Returns tree in pre-order.
        /// </summary>
        /// <param name="current">Current node of the tree.</param>
        /// <returns>Tree nodes.</returns>
        private IEnumerable<T> PreOrderEnumerator(Node current)
        {
            yield return current.Item;
            if (current.Left != null)
            {
                foreach (var node in PreOrderEnumerator(current.Left))
                {
                    yield return node;
                }
            }

            if (current.Right != null)
            {
                foreach (var node in PreOrderEnumerator(current.Right))
                {
                    yield return node;
                }
            }
        }

        /// <summary>
        /// Returns tree in in-order.
        /// </summary>
        /// <param name="current">Current node of the tree.</param>
        /// <returns>Tree nodes.</returns>
        private IEnumerable<T> InOrderEnumerator(Node current)
        {
            if (current.Left != null)
            {
                foreach (var node in InOrderEnumerator(current.Left))
                {
                    yield return node;
                }
            }
            
            yield return current.Item;

            if (current.Right != null)
            {
                foreach (var node in InOrderEnumerator(current.Right))
                {
                    yield return node;
                }
            }
        }

        /// <summary>
        /// Returns tree in post-order.
        /// </summary>
        /// <param name="current">Current node of the tree.</param>
        /// <returns>Tree nodes.</returns>
        private IEnumerable<T> PostOrderEnumerator(Node current)
        {
            if (current.Left != null)
            {
                foreach (var node in PostOrderEnumerator(current.Left))
                {
                    yield return node;
                }
            }

            if (current.Right != null)
            {
                foreach (var node in PostOrderEnumerator(current.Right))
                {
                    yield return node;
                }
            }

            yield return current.Item;
        }

        private class Node
        {
            public T Item { get; set; }

            public Node Right { get; set; }

            public Node Left { get; set; }
        }
    }
}

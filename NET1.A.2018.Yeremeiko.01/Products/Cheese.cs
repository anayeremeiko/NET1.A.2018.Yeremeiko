using System;

namespace Products
{
    /// <summary>
    /// This is Cheese class
    /// </summary>
    public class Cheese
    {
        /// <summary>
        /// cheese name
        /// </summary>
        private string name;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">cheese name</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the cheese name is null 
        /// </exception>
        public Cheese(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.name = name;
        }

        /// <summary>
        /// The info method.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Info()
        {
            return $"Cheese {name}";
        }
    }
}

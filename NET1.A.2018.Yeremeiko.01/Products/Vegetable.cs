namespace Products
{
    /// <summary>
    /// Class describing a vegetable
    /// </summary>
    public class Vegetable
    {
        /// <summary>
        /// vegetable color
        /// </summary>
        private string color;

        /// <summary>
        /// weight of vegetable
        /// </summary>
        private double weight;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="color">vegetable color</param>
        /// <param name="weight">weight of vegetable</param>
        public Vegetable(string color, double weight)
        {
            this.color = color;
            this.weight = weight;
        }

        /// <summary>
        /// The info method.
        /// </summary>
        /// <returns>
        /// Color and weight of vegetable.
        /// </returns>
        public string Info()
        {
            return $"This vegetable is {color}, weight = {weight}";
        }
    }
}

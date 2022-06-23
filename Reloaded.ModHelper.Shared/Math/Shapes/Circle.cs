using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// TODO! Represents a Circle.
    /// </summary>
    public struct Circle : IShape2D
    {
        /// <summary>
        /// The center point of the circle.
        /// </summary>
        public Vector2 Center { get; private set; }

        /// <summary>
        /// The diameter of the circle.
        /// </summary>
        public float Diameter { get; private set; }

       

        /// <summary>
        /// TODO!
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Vector2 point)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a Random point from this Circle.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRandomPoint()
        {
            return Random.GetRandomPoint(this);
        }
    }
}

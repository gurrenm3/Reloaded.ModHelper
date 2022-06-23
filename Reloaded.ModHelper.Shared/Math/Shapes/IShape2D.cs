namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a 2 Dimensional Shape.
    /// </summary>
    public interface IShape2D
    {
        /// <summary>
        /// Returns whether or not this 2D shape contains the specified point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Vector2 point);

        /// <summary>
        /// Returns a random point from this 2D Shape.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRandomPoint();
    }
}

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a 3 Dimensional Shape
    /// </summary>
    public interface IShape3D
    {
        /// <summary>
        /// Returns whether or not this 3D shape contains the specified point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Vector3f point);

        /// <summary>
        /// Returns a random point from this 3D Shape.
        /// </summary>
        /// <returns></returns>
        public Vector3f GetRandomPoint();
    }
}

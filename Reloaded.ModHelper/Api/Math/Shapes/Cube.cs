using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// TODO! Represents a Cube
    /// </summary>
    public struct Cube : IShape3D
    {
        /// <summary>
        /// TODO!
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool Contains(Vector3 vector)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a random point from this Cube.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomPoint()
        {
            return Random.GetRandomPoint(this);
        }
    }
}

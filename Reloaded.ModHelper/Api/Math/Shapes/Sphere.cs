using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// TODO! Represents a Sphere.
    /// </summary>
    public struct Sphere : IShape3D
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
        /// Returns a random point from this Sphere.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomPoint()
        {
            return Random.GetRandomPoint(this);
        }
    }
}

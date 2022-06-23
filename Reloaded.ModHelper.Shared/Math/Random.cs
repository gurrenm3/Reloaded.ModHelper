using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A ThreadSafe way to easily generate random data for games. Based off of Unity's Random class.
    /// </summary>
    public sealed class Random
    {
        /// <summary>
        /// Instance of ThreadSafeRandom that is used in this class.
        /// </summary>
        public static ThreadSafeRandom _random { get => ThreadSafeRandom.Global; }

        /// <summary>
        /// Returns a random number between <paramref name="min"/> and <paramref name="max"/>.
        /// <br/><br/>Both the lower and upper bounds are inclusive.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Range(int min, int max)
        {
            return _random.Next(min, max);
        }

        /// <summary>
        /// Returns a random number between <paramref name="min"/> and <paramref name="max"/>.
        /// <br/><br/>Both the lower and upper bounds are inclusive.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Range(float min, float max)
        {
            return (float)_random.NextDouble(min, max);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPoint(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPoint(Circle circle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sphere"></param>
        /// <returns></returns>
        public static Vector3 GetRandomPoint(Sphere sphere)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="cube"></param>
        /// <returns></returns>
        public static Vector3 GetRandomPoint(Cube cube)
        {
            throw new NotImplementedException();
        }
    }
}

/// This has been removed for now. Not sure if I should use System.Numerics.Vector3
/// or make my own based off of Unity. Using System.Numerics.Vector3 is better in that it's
/// already created and it's hardware accelerated (ask Sewer for more info). Remaking could 
/// be better since then it's more familiar and everything needed would be 
/// under one namespace "Reloaded.ModHelper". Some more experienced programmers may dislike
/// making my own Vector3 because they'd wonder why I didn't just use the existing one. 
/// 
/// Think more on this.

using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to represent a 3D position.
    /// </summary>
    public struct Vector3
    {
        /// <summary>
        /// A default vector with no values. Used for comparisson.
        /// </summary>
        public static Vector3 Zero { get; } = new Vector3(0, 0, 0);

        /// <summary>
        /// The X coordinate of this position.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The Y coordinate of this position.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// The Z coordinate of this position.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Default constructor for <see cref="Vector3"/>
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <param name="z">z coordinate.</param>
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// An override of the default ToString method.
        /// </summary>
        /// <returns>A string of all the coordinate properties in order.
        /// <br/>Ex: (0, 10, 5)</returns>
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }


        #region Static Methods


        public static double GetDot(Vector3 point1, Vector3 point2)
        {
            return (point1.X * point2.X) + (point1.Y * point2.Y) + (point1.Z * point2.Z);
        }

        #endregion
    }
}

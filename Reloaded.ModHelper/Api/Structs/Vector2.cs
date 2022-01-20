/// This has been removed for now. Not sure if I should use System.Numerics.Vector2 
/// or make my own based off of Unity. Using System.Numerics.Vector2 is better in that it's
/// already created and it's hardware accelerated (ask Sewer for more info). Remaking could 
/// be better since then it's more familiar and everything needed would be 
/// under one namespace "Reloaded.ModHelper". Some more experienced programmers may dislike
/// making my own Vector2 because they'd wonder why I didn't just use the existing one. 
/// 
/// Think more on this.


using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to represent a 2D position. Heavily based off of Unity's Vector2 struct.
    /// </summary>
    public struct Vector2 : IEquatable<Vector2>
    {

        #region Static Properties

        /// <summary>
        /// A default vector with no values. Used for comparisson only.
        /// </summary>
        public static Vector2 Zero { get; } = new Vector2(0, 0);

        /// <summary>
        /// Shorthand for writing Vector2(0, -1).
        /// </summary>
        public static Vector2 Down { get; } = new Vector2(0, -1);

        /// <summary>
        /// 	Shorthand for writing Vector2(-1, 0).
        /// </summary>
        public static Vector2 Left { get; } = new Vector2(-1, 0);

        /// <summary>
        /// Shorthand for writing Vector2(0, 1).
        /// </summary>
        public static Vector2 Up { get; } = new Vector2(0, 1);

        /// <summary>
        /// Shorthand for writing Vector2(1, 0).
        /// </summary>
        public static Vector2 Right { get; } = new Vector2(1, 0);

        /// <summary>
        /// Shorthand for writing Vector2(1, 1).
        /// </summary>
        public static Vector2 One { get; } = new Vector2(1, 1);

        #endregion


        #region Properties

        /// <summary>
        /// The X coordinate of this position.
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// The Y coordinate of this position.
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// The length of the vector is square root of (x*x) + (y*y).
        /// <br/><br/>If you only need to compare magnitudes of some vectors, you can compare squared magnitudes of them using sqrMagnitude (computing squared magnitudes is faster).
        /// </summary>
        /// <remarks>Taken from Unity Documentation.</remarks>
        public double Magnitude
        {
            get { return magnitude == 0 ? magnitude = Math.Sqrt(SqrMagnitude) : magnitude; }
            private set { magnitude = value; }
        }
        private double magnitude;


        /// <summary>
        /// Calculating the squared magnitude instead of the magnitude is much faster. Often if you are comparing magnitudes of two vectors you can just compare their squared magnitudes.
        /// </summary>
        /// <remarks>Taken from Unity Documentation.</remarks>
        public double SqrMagnitude
        {
            get { return sqrMagnitude == 0 ? sqrMagnitude = (X * X) + (Y * Y) : sqrMagnitude; }
            private set { sqrMagnitude = value; }
        }
        private double sqrMagnitude;

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor for <see cref="Vector2"/>.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
            sqrMagnitude = 0;
            magnitude = 0;
        }

        /// <summary>
        /// Creates a Vector2 out of a <see cref="Point"/>.
        /// </summary>
        /// <param name="point">Point to use for X and Y coords.</param>
        public Vector2(Point point)
        {
            X = point.X;
            Y = point.Y;
            sqrMagnitude = 0;
            magnitude = 0;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Set X and Y components of an existing Vector2.
        /// </summary>
        /// <param name="newX">New X coordinate.</param>
        /// <param name="newY">New Y coordinate.</param>
        public void Set(float newX, float newY)
        {
            X = newX;
            Y = newY;
            Magnitude = 0;
            SqrMagnitude = 0;
        }

        public bool Equals(Vector2 other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        #endregion


        #region Overrided Methods

        /// <summary>
        /// An override of the default ToString method.
        /// </summary>
        /// <returns>A string of all the coordinate properties in order.
        /// <br/>Ex: (0, 10)</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        /// An override of the default Equals method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if <paramref name="obj"/> is of type <see cref="Vector2"/> and
        /// both X and Y values are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            bool isVector = obj is Vector2;
            return isVector ? this.Equals((Vector2)obj) : false;
        }

        /// <summary>
        /// An override of the default GetHashCode method. Taken straigt from Unity.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode() << 2;
        }

        #endregion


        #region Static Methods

        /// <summary>
        /// Returns Dot Product of two Vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double GetDot(Vector2 point1, Vector2 point2)
        {
            return (point1.X * point2.X) + (point1.Y * point2.Y);
        }

        /// <summary>
        /// UNTESTED: Returns the unsigned angle in degrees between <paramref name="from"/> and <paramref name="to"/>.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static double GetAngle(Vector2 from, Vector2 to)
        {
            double dot = GetDot(from, to);
            double totalMagniture = from.Magnitude * to.Magnitude;
            return Math.Acos(dot / totalMagniture);
        }

        /// <summary>
        /// Returns a vector that is made from the largest components of two vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Vector2 GetMax(Vector2 point1, Vector2 point2)
        {
            double x = point1.X > point2.X ? point1.X : point2.X;
            double y = point1.Y > point2.Y ? point1.Y : point2.Y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Returns a vector that is made from the smallest components of two vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Vector2 GetMin(Vector2 point1, Vector2 point2)
        {
            double x = point1.X < point2.X ? point1.X : point2.X;
            double y = point1.Y < point2.Y ? point1.Y : point2.Y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Returns the distance between <paramref name="point1"/> and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1">Starting point.</param>
        /// <param name="point2">Ending point.</param>
        /// <returns>The distance between both points.</returns>
        public static double GetDistance(Vector2 point1, Vector2 point2)
        {
            double x = point1.X - point2.X;
            double y = point1.Y - point2.Y;
            double sqrMagnitude = (x * x + y * y);
            return Math.Sqrt(sqrMagnitude);
        }

        #endregion


        #region Operators

        /// <summary>
        /// Returns a new <see cref="Vector3"/> whose values are taken from a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="point"></param>
        public static implicit operator Vector3(Vector2 point)
        {
            return new Vector3(point.X, point.Y, 0);
        }

        /// <summary>
        /// Returns a new <see cref="Vector2"/> whose values are taken from a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="point"></param>
        public static implicit operator Vector2(Vector3 point)
        {
            return new Vector2(point.X, point.Y);
        }

        /// <summary>
        /// Returns true if two vectors are approximately equal.
        /// </summary>
        /// <param name="point1">Point to check.</param>
        /// <param name="point2">Point to compare against.</param>
        /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
        public static bool operator ==(Vector2 point1, Vector2 point2)
        {
            return point1.Equals(point2);
        }

        /// <summary>
        /// Returns true if two vectors are not equal.
        /// </summary>
        /// <param name="point1">Point to check.</param>
        /// <param name="point2">Point to compare against.</param>
        /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
        public static bool operator !=(Vector2 point1, Vector2 point2)
        {
            return !point1.Equals(point2);
        }

        /// <summary>
        /// Subtracts one Vector from another.
        /// </summary>
        /// <param name="point1">Vector to subtract from.</param>
        /// <param name="point2">Vector whose values you want to subtract from <paramref name="point1"/>.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> - <paramref name="point2"/>.</returns>
        public static Vector2 operator -(Vector2 point1, Vector2 point2)
        {
            return new Vector2(point1.X - point2.X, point1.Y - point2.Y);
        }

        /// <summary>
        /// Subtracts an amount from both points of the Vector.
        /// </summary>
        /// <param name="point1">Vector to subtract from.</param>
        /// <param name="amount">Amount to subtract.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> - <paramref name="amount"/>.</returns>
        public static Vector2 operator -(Vector2 point1, double amount)
        {
            return new Vector2(point1.X - amount, point1.Y - amount);
        }

        /// <summary>
        /// Adds one Vector to another.
        /// </summary>
        /// <param name="point1">Vector to add to.</param>
        /// <param name="point2">Vector whose values you want to add to <paramref name="point1"/>.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> + <paramref name="point2"/>.</returns>
        public static Vector2 operator +(Vector2 point1, Vector2 point2)
        {
            return new Vector2(point1.X + point2.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// Add an amount to both points of a Vector.
        /// </summary>
        /// <param name="point1">Vector to add to.</param>
        /// <param name="amount">Amount to add by.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> + <paramref name="amount"/>.</returns>
        public static Vector2 operator +(Vector2 point1, double amount)
        {
            return new Vector2(point1.X + amount, point1.Y + amount);
        }

        /// <summary>
        /// Multiplies one Vector by another.
        /// </summary>
        /// <param name="point1">Vector to multiply.</param>
        /// <param name="point2">Vector to multiply by.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> * <paramref name="point2"/>.</returns>
        public static Vector2 operator *(Vector2 point1, Vector2 point2)
        {
            return new Vector2(point1.X * point2.X, point1.Y * point2.Y);
        }

        /// <summary>
        /// Multiply both points of a Vector by an amount.
        /// </summary>
        /// <param name="point1">Vector to multiply.</param>
        /// <param name="amount">Amount to multiply by.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> * <paramref name="amount"/>.</returns>
        public static Vector2 operator *(Vector2 point1, double amount)
        {
            return new Vector2(point1.X * amount, point1.Y * amount);
        }

        /// <summary>
        /// Divide one Vector by another.
        /// </summary>
        /// <param name="point1">Vector to divide.</param>
        /// <param name="point2">Vector to divide by.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> / <paramref name="point2"/>.</returns>
        public static Vector2 operator /(Vector2 point1, Vector2 point2)
        {
            return new Vector2(point1.X / point2.X, point1.Y / point2.Y);
        }

        /// <summary>
        /// Divide both points of a Vector by an amount.
        /// </summary>
        /// <param name="point1">Vector to divide.</param>
        /// <param name="amount">Amount to divide by.</param>
        /// <returns>A new Vector whose values are <paramref name="point1"/> / <paramref name="amount"/>.</returns>
        public static Vector2 operator /(Vector2 point1, double amount)
        {
            return new Vector2(point1.X / amount, point1.Y / amount);
        }

        #endregion
    }
}
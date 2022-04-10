using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to represent a 2D position. Heavily based off of Unity's Vector2 struct.
    /// </summary>
    [Serializable]
    public struct Vector2 : IEquatable<Vector2>
    {

        #region Static Properties

        /// <summary>
        /// Shorthand for writing Vector2(float.PositiveInfinity, float.PositiveInfinity).
        /// </summary>
        public static Vector2 positiveInfinity { get => Vector2.positiveInfinityVector; }
        private static readonly Vector2 positiveInfinityVector = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        /// <summary>
        /// Shorthand for writing Vector2(float.NegativeInfinity, float.NegativeInfinity).
        /// </summary>
        public static Vector2 negativeInfinity { get => Vector2.negativeInfinityVector; }
        private static readonly Vector2 negativeInfinityVector = new Vector2(float.NegativeInfinity, float.NegativeInfinity);


        /// <summary>
        /// Shorthand for writing Vector2(0, 0).
        /// </summary>
        public static Vector2 Zero { get => zero; }
        private static readonly Vector2 zero = new Vector2(0, 0);

        /// <summary>
        /// Shorthand for writing Vector2(0, -1).
        /// </summary>
        public static Vector2 Down { get => down; }
        private static readonly Vector2 down = new Vector2(0, -1);

        /// <summary>
        /// 	Shorthand for writing Vector2(-1, 0).
        /// </summary>
        public static Vector2 Left { get => left; }
        private static readonly Vector2 left = new Vector2(-1, 0);

        /// <summary>
        /// Shorthand for writing Vector2(0, 1).
        /// </summary>
        public static Vector2 Up { get => up; }
        private static readonly Vector2 up = new Vector2(0, 1);

        /// <summary>
        /// Shorthand for writing Vector2(1, 0).
        /// </summary>
        public static Vector2 Right { get => right; }
        private static readonly Vector2 right = new Vector2(1, 0);

        /// <summary>
        /// Shorthand for writing Vector2(1, 1).
        /// </summary>
        public static Vector2 One { get => one; }
        private static readonly Vector2 one = new Vector2(1, 1);

        #endregion


        #region Properties

        /// <summary>
        /// The X coordinate of this position.
        /// 
        /// <br/><br/>TODO: Check if this works with Json.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// The Y coordinate of this position.
        /// 
        /// <br/><br/>TODO: Check if this works with Json.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                if (index != 0 && index != 1)
                    throw new IndexOutOfRangeException("Invalid Vector2 index!");

                return index == 0 ? X : Y;
            }
            set
            {
                if (index != 0 && index != 1)
                    throw new IndexOutOfRangeException("Invalid Vector2 index!");

                if (index != 0)
                    Y = value;
                else
                    X = value;
            }
        }

        /// <summary>
        /// The length of the vector is square root of (x*x) + (y*y).
        /// <br/><br/>If you only need to compare magnitudes of some vectors, you can compare squared magnitudes of them using sqrMagnitude (computing squared magnitudes is faster).
        /// </summary>
        public float Magnitude
        {
            get { return magnitude == 0 ? magnitude = Mathf.Sqrt(SqrMagnitude) : magnitude; }
            private set { magnitude = value; }
        }
        [NonSerialized]
        private float magnitude;


        /// <summary>
        /// Calculating the squared magnitude instead of the magnitude is much faster. Often if you are comparing magnitudes of two vectors you can just compare their squared magnitudes.
        /// </summary>
        public float SqrMagnitude
        {
            get { return sqrMagnitude == 0 ? sqrMagnitude = (X * X) + (Y * Y) : sqrMagnitude; }
            private set { sqrMagnitude = value; }
        }
        [NonSerialized]
        private float sqrMagnitude;

        /// <summary>
        /// Returns a new Vector with a magnitude of 1 (Read Only)
        /// <br/>When normalized, a vector keeps the same direction but its length is 1.0.
        /// <br/><br/>Note that the current vector is unchanged and a new normalized vector is returned. 
        /// If you want to normalize the current vector, use <see cref="Normalize"/> function.
        /// <br/>If this vector is too small to be normalized it will be set to zero.
        /// </summary>
        public Vector2 normalized
        {
            get => new Vector2(X, Y).Normalize();
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor for <see cref="Vector2"/>.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
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
        /// Multiplies every component of this vector by the same component of <paramref name="scale"/>
        /// </summary>
        /// <param name="scale"></param>
        /// <returns>This Vector after it has been scaled.</returns>
        public Vector2 Scale(Vector2 scale)
        {
            X *= scale.X;
            Y *= scale.Y;
            return this;
        }

        /// <summary>
        /// Set X and Y components of an existing Vector2.
        /// </summary>
        /// <param name="newValue">The value to set both <see cref="X"/> and <see cref="Y"/> to.</param>
        /// <returns>This Vector after it has been set.</returns>
        public Vector2 Set(float newValue)
        {
            return Set(newValue, newValue);
        }

        /// <summary>
        /// Set X and Y components of an existing Vector2.
        /// </summary>
        /// <param name="newX">New X coordinate.</param>
        /// <param name="newY">New Y coordinate.</param>
        /// <returns>This Vector after it has been set.</returns>
        public Vector2 Set(float newX, float newY)
        {
            X = newX;
            Y = newY;
            Magnitude = 0;
            SqrMagnitude = 0;
            return this;
        }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// <br/>When normalized, a vector keeps the same direction but its length is 1.0.
        /// <br/><br/>Note that this function will change the current vector.
        /// If you want to keep the current vector unchanged, use <see cref="normalized"/> variable.
        /// <br/>If this vector is too small to be normalized it will be set to zero.
        /// </summary>
        /// <returns>This Vector after it has been normalized.</returns>
        public Vector2 Normalize()
        {
            float magnitude = this.Magnitude;
            if (magnitude > 1E-05f)
            {
                this /= magnitude;
            }
            else
            {
                this = Vector2.Zero;
            }

            return this;
        }

        /// <summary>
        /// Returns whether or not this <see cref="Vector2"/> is equal to another <see cref="Vector2"/>.
        /// </summary>
        /// <param name="other">Vector to comapre</param>
        /// <returns></returns>
        public bool Equals(Vector2 other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        /// <summary>
        /// Returns a formatted string for this vector.
        /// </summary>
        /// <returns>A string of all the coordinate properties in order.
        /// <br/>Ex: (0, 10)</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        /// Returns whether or not this <see cref="Vector2"/> is equal to another <see cref="Vector2"/>.
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
        /// Returns the unsigned angle in degrees between <paramref name="from"/> and <paramref name="to"/>.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            float num = (float)Math.Sqrt((double)(from.sqrMagnitude * to.sqrMagnitude));
            float result = 0f;

            if (num >= 1E-15f)
            {
                float num2 = Mathf.Clamp(Vector2.GetDot(from, to) / num, -1f, 1f);
                result = (float)Math.Acos((double)num2) * 57.29578f;
            }

            return result;
        }

        /// <summary>
        /// Returns a copy of <paramref name="vector"/> with its magnitude clamped to <paramref name="maxLength"/>
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static Vector2 ClampMagnitude(Vector2 vector, float maxLength)
        {
            float sqrMagnitude = vector.sqrMagnitude;
            Vector2 result = vector;

            if (sqrMagnitude > maxLength * maxLength)
            {
                float num = (float)Math.Sqrt((double)sqrMagnitude);
                float num2 = vector.X / num;
                float num3 = vector.Y / num;
                result = new Vector2(num2 * maxLength, num3 * maxLength);
            }

            return result;
        }

        /// <summary>
        /// Returns the distance between <paramref name="point1"/> and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1">Starting point.</param>
        /// <param name="point2">Ending point.</param>
        /// <returns>The distance between both points.</returns>
        public static float GetDistance(Vector2 point1, Vector2 point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            float sqrMagnitude = (x * x + y * y);
            return (float)Math.Sqrt(sqrMagnitude);
        }

        /// <summary>
        /// Returns Dot Product of two Vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float GetDot(Vector2 point1, Vector2 point2)
        {
            return (point1.X * point2.X) + (point1.Y * point2.Y);
        }

        /// <summary>
        /// Linearly interpolates between vectors <paramref name="point1"/> and 
        /// <paramref name="point2"/> by <paramref name="value"/>.
        /// 
        /// <br/>
        /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
        /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
        /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/>
        /// and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="value">The clamped to the range [0, 1].</param>
        /// <returns></returns>
        public static Vector2 Lerp(Vector2 point1, Vector2 point2, float value)
        {
            value = Mathf.Clamp01(value);

            float x = point1.X + (point2.X - point1.X) * value;
            float y = point1.Y + (point2.Y - point1.Y) * value;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Linearly interpolates between vectors <paramref name="point1"/> and 
        /// <paramref name="point2"/> by <paramref name="value"/>.
        /// 
        /// <br/>
        /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
        /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
        /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/>
        /// and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 LerpUnclamped(Vector2 point1, Vector2 point2, float value)
        {
            float x = point1.X + (point2.X - point1.X) * value;
            float y = point1.Y + (point2.Y - point1.Y) * value;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Returns a vector that is made from the largest components of two vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Vector2 GetMax(Vector2 point1, Vector2 point2)
        {
            return new Vector2(Mathf.Max(point1.X, point2.X), Mathf.Max(point1.Y, point2.Y));
        }

        /// <summary>
        /// Returns a vector that is made from the smallest components of two vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Vector2 GetMin(Vector2 point1, Vector2 point2)
        {
            return new Vector2(Mathf.Min(point1.X, point2.Y), Mathf.Min(point1.X, point2.Y));
        }

        /// <summary>
        /// Moves a point <paramref name="current"/> towards <paramref name="target"/>.
        /// <br/><br/>This is essentially the same as <see cref="Lerp(Vector2, Vector2, float)"/>
        /// but instead the function will ensure that the distance never exceeds <paramref name="maxDistanceDelta"/>.
        /// Negative values of <paramref name="maxDistanceDelta"/> pushes the vector away from <paramref name="target"/>.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        {
            float num = target.X - current.X;
            float num2 = target.Y - current.Y;
            float num3 = num * num + num2 * num2;

            Vector2 result;
            if (num3 == 0f || (maxDistanceDelta >= 0f && num3 <= maxDistanceDelta * maxDistanceDelta))
            {
                result = target;
            }
            else
            {
                float num4 = (float)Math.Sqrt((double)num3);
                result = new Vector2(current.X + num / num4 * maxDistanceDelta, current.Y + num2 / num4 * maxDistanceDelta);
            }
            return result;
        }

        /// <summary>
        /// Returns the 2D vector perpendicular to this 2D vector. The result is always rotated 90-degrees in a counter-clockwise direction for a 2D coordinate system where the positive Y axis goes up.
        /// </summary>
        /// <param name="inDirection">The input direction.</param>
        /// <returns>A new Vector2 in the perpendicular direction.</returns>
        public static Vector2 Perpendicular(Vector2 inDirection)
        {
            return new Vector2(-inDirection.Y, inDirection.X);
        }

        /// <summary>
        /// Reflects a vector off the vector defined by a normal.
        /// </summary>
        /// <param name="inDirection">The input direction.</param>
        /// <param name="inNormal"></param>
        /// <returns></returns>
        public static Vector2 Reflect(Vector2 inDirection, Vector2 inNormal)
        {
            float num = -2f * GetDot(inNormal, inDirection);
            return new Vector2(num * inNormal.X + inDirection.X, num * inNormal.Y + inDirection.Y);
        }

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// <br/><br/>Every component in the result is a component of a multiplied by the same component of b.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Vector2 Scale(Vector2 point1, Vector2 point2)
        {
            return new Vector2(point1.X * point2.X, point1.Y * point2.Y);
        }

        /// <summary>
        /// Returns the signed angle in degrees between <paramref name="from"/> and <paramref name="to"/>.
        /// <br/><br/>The angle returned is the signed acute clockwise angle between the two vectors. This means the smaller of the two possible angles between the two vectors is used. The result is never greater than 180 degrees or smaller than -180 degrees.
        /// </summary>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <param name="to">The vector to which the angular difference is measured.</param>
        /// <returns></returns>
        public static float SignedAngle(Vector2 from, Vector2 to)
        {
            float num = Vector2.GetAngle(from, to);
            float num2 = Mathf.Sign(from.X * to.Y - from.Y * to.X);
            return num * num2;
        }

        /// <summary>
        /// Gradually changes a vector towards a desired goal over time.
        /// <br/>The vector is smoothed by some spring-damper like function, which will never overshoot.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="deltaTime">The time since the last call to this function. Recommended to use <see cref="PseudoTime.DeltaTime"/>.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        /// <returns></returns>
        public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
        {
            smoothTime = Mathf.Max(0.0001f, smoothTime);
            float num = 2f / smoothTime;
            float num2 = num * deltaTime;
            float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
            float num4 = current.X - target.X;
            float num5 = current.Y - target.Y;
            Vector2 vector = target;
            float num6 = maxSpeed * smoothTime;
            float num7 = num6 * num6;
            float num8 = num4 * num4 + num5 * num5;
            if (num8 > num7)
            {
                float num9 = (float)Math.Sqrt((double)num8);
                num4 = num4 / num9 * num6;
                num5 = num5 / num9 * num6;
            }
            target.X = current.X - num4;
            target.Y = current.Y - num5;
            float num10 = (currentVelocity.X + num * num4) * deltaTime;
            float num11 = (currentVelocity.Y + num * num5) * deltaTime;
            currentVelocity.X = (currentVelocity.X - num * num10) * num3;
            currentVelocity.Y = (currentVelocity.Y - num * num11) * num3;
            float num12 = target.X + (num4 + num10) * num3;
            float num13 = target.Y + (num5 + num11) * num3;
            float num14 = vector.X - current.X;
            float num15 = vector.Y - current.Y;
            float num16 = num12 - vector.X;
            float num17 = num13 - vector.Y;
            if (num14 * num16 + num15 * num17 > 0f)
            {
                num12 = vector.X;
                num13 = vector.Y;
                currentVelocity.X = (num12 - vector.X) / deltaTime;
                currentVelocity.Y = (num13 - vector.Y) / deltaTime;
            }
            return new Vector2(num12, num13);
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
        /// Returns a new <see cref="Vector2"/> whose values are taken from a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="point"></param>
        public static implicit operator Vector2(System.Numerics.Vector2 point)
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
            float num = point1.X - point2.X;
            float num2 = point1.Y - point2.Y;
            return num * num + num2 * num2 < 9.99999944E-11f;
        }

        /// <summary>
        /// Returns true if two vectors are not equal.
        /// </summary>
        /// <param name="point1">Point to check.</param>
        /// <param name="point2">Point to compare against.</param>
        /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
        public static bool operator !=(Vector2 point1, Vector2 point2)
        {
            return !(point1 == point2);
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
        public static Vector2 operator +(Vector2 point1, float amount)
        {
            return new Vector2(point1.X + amount, point1.Y + amount);
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
        public static Vector2 operator -(Vector2 point1, float amount)
        {
            return new Vector2(point1.X - amount, point1.Y - amount);
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
        public static Vector2 operator *(Vector2 point1, float amount)
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
        public static Vector2 operator /(Vector2 point1, float amount)
        {
            return new Vector2(point1.X / amount, point1.Y / amount);
        }

        #endregion
    }
}
using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to represent a 3D position. Heavily based off of Unity's Vector3 class.
    /// </summary>
    /// <remarks>Documentation: https://docs.unity3d.com/ScriptReference/Vector3.html </remarks>
    [Serializable]
    public struct Vector3
    {

        #region Static Properties

        /// <summary>
        /// Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).
        /// </summary>
        public static Vector3 positiveInfinity { get => Vector3.positiveInfinityVector; }
        private static readonly Vector3 positiveInfinityVector = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        /// <summary>
        /// Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).
        /// </summary>
        public static Vector3 negativeInfinity { get => Vector3.negativeInfinityVector; }
        private static readonly Vector3 negativeInfinityVector = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);


        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 0).
        /// </summary>
        public static Vector3 Zero { get => zero; }
        private static readonly Vector3 zero = new Vector3(0, 0, 0);

        /// <summary>
        /// Shorthand for writing Vector3(1, 1, 1).
        /// </summary>
        public static Vector3 One { get => one; }
        private static readonly Vector3 one = new Vector3(1f, 1f, 1f);

        /// <summary>
        /// Shorthand for writing Vector3(0, 1, 0).
        /// </summary>
        public static Vector3 Up { get => up; }
        private static readonly Vector3 up = new Vector3(0f, 1f, 0f);

        /// <summary>
        /// Shorthand for writing Vector3(0, -1, 0).
        /// </summary>
        public static Vector3 Down { get => down; }
        private static readonly Vector3 down = new Vector3(0f, -1f, 0f);

        /// <summary>
        /// Shorthand for writing Vector3(-1, 0, 0).
        /// </summary>
        public static Vector3 Left { get => left; }
        private static readonly Vector3 left = new Vector3(-1f, 0f, 0f);

        /// <summary>
        /// Shorthand for writing Vector3(1, 0, 0).
        /// </summary>
        public static Vector3 Right { get => right; }
        private static readonly Vector3 right = new Vector3(1f, 0f, 0f);

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 1).
        /// </summary>
        public static Vector3 Forward { get => forward; }
        private static readonly Vector3 forward = new Vector3(0f, 0f, 1f);

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, -1).
        /// </summary>
        public static Vector3 Back { get => back; }
        private static readonly Vector3 back = new Vector3(0f, 0f, -1f);

        #endregion


        #region Properties

        /// <summary>
        /// The X coordinate of this position.
        /// <br/><br/>TODO: Check if this works with Json.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// The Y coordinate of this position.
        /// <br/><br/>TODO: Check if this works with Json.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// The Z coordinate of this position.
        /// <br/><br/>TODO: Check if this works with Json.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// The length of the vector is square root of (X*X) + (Y*Y) + (Z*Z).
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
            get { return sqrMagnitude == 0 ? sqrMagnitude = (X * X) + (Y * Y) + (Z * Z) : sqrMagnitude; }
            private set { sqrMagnitude = value; }
        }
        [NonSerialized]
        private float sqrMagnitude;

        /// <summary>
        /// Returns a new Vector with a magnitude of 1 (Read Only)
        /// <br/>When normalized, a vector keeps the same direction but its length is 1.0.
        /// <br/><br/>Note that the current vector is unchanged and a new normalized vector is returned. 
        /// If you want to normalize the current vector, use <see cref="Normalize(Vector3)"/> function.
        /// <br/>If this vector is too small to be normalized it will be set to zero.
        /// </summary>
        public Vector2 normalized
        {
            get => new Vector2(X, Y).Normalize();
        }

        #endregion



        #region Fields

        public const float kEpsilon = 1E-05f;
        public const float kEpsilonNormalSqrt = 1E-15f;

        #endregion



        #region Constructors


        /// <summary>
        /// Creates a Vector3 whose X, Y, Z coordinates are all set to <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        public Vector3(float value) : this (value, value, value)
        {

        }

        /// <summary>
        /// Default constructor for <see cref="Vector3"/>
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <param name="z">z coordinate.</param>
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            magnitude = 0;
            sqrMagnitude = 0;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// </summary>
        /// <param name="scale"></param>
        /// <returns>This Vector after it has been scaled.</returns>
        public Vector3 Scale(Vector3 scale)
        {
            X *= scale.X;
            Y *= scale.Y;
            Z *= scale.Z;
            return this;
        }

        /// <summary>
        /// Set x, y and z components of an existing Vector3.
        /// </summary>
        /// <param name="value">Value to set all components to.</param>
        /// <returns>This Vector after it has been set.</returns>
        public Vector3 Set(float value)
        {
            return Set(value, value, value);
        }

        /// <summary>
        /// Set x, y and z components of an existing Vector3.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>This Vector after it has been set.</returns>
        public Vector3 Set(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            magnitude = 0;
            sqrMagnitude = 0;
            return this;
        }

        /// <summary>
        /// Returns a formatted string for this vector.
        /// </summary>
        /// <returns>A string of all the coordinate properties in order.
        /// <br/>Ex: (0, 10, 5)</returns>
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        /// <summary>
        /// Returns true if the given vector is exactly equal to this vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vector3 other)
        {
            return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
        }

        /// <summary>
        /// Returns true if the given vector is exactly equal to this vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other is Vector3 && this.Equals((Vector3)other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode() << 2 ^ this.Z.GetHashCode() >> 2;
        }

        #endregion


        #region Static Methods

        /// <summary>
        /// Calculates the angle between two Vectors.
        /// </summary>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <param name="to">The vector to which the angular difference is measured.</param>
        /// <returns>The angle in degrees between the two vectors.</returns>
        public static float GetAngle(Vector3 from, Vector3 to)
        {
            float num = (float)Math.Sqrt((double)(from.sqrMagnitude * to.sqrMagnitude));
            float result;
            if (num < 1E-15f)
            {
                result = 0f;
            }
            else
            {
                float num2 = Mathf.Clamp(Vector3.GetDot(from, to) / num, -1f, 1f);
                result = (float)Math.Acos((double)num2) * 57.29578f;
            }
            return result;
        }

        /// <summary>
        /// Returns a copy of vector with its magnitude clamped to maxLength.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
        {
            float sqrMagnitude = vector.sqrMagnitude;
            Vector3 result;
            if (sqrMagnitude > maxLength * maxLength)
            {
                float num = (float)Math.Sqrt((double)sqrMagnitude);
                float num2 = vector.X / num;
                float num3 = vector.Y / num;
                float num4 = vector.Z / num;
                result = new Vector3(num2 * maxLength, num3 * maxLength, num4 * maxLength);
            }
            else
            {
                result = vector;
            }
            return result;
        }

        /// <summary>
        /// Cross Product of two vectors.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.Y * rhs.Z - lhs.Z * rhs.Y, lhs.Z * rhs.X - lhs.X * rhs.Z, lhs.X * rhs.Y - lhs.Y * rhs.X);
        }

        /// <summary>
        /// Returns the distance between <paramref name="point1"/> and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float Distance(Vector3 point1, Vector3 point2)
        {
            float num = point1.X - point2.X;
            float num2 = point1.Y - point2.Y;
            float num3 = point1.Z - point2.Z;
            return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
        }

        /// <summary>
        /// Dot Product of two vectors.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float GetDot(Vector3 point1, Vector3 point2)
        {
            return (point1.X * point2.X) + (point1.Y * point2.Y) + (point1.Z * point2.Z);
        }

        /// <summary>
        /// Linearly interpolates between two points, where <paramref name="value"/> will be
        /// clamped between [0, 1].
        /// 
        /// <br/>
        /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
        /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
        /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/> and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1">Start value, returned when value = 0.</param>
        /// <param name="point2">End value, returned when value = 1.</param>
        /// <param name="value">Value used to interpolate between point1 and point2, clamped to the range of [0, 1].</param>
        /// <returns>Interpolated value, equals to <paramref name="point1"/> +
        /// (<paramref name="point2"/> - <paramref name="point1"/>) * <paramref name="value"/>. </returns>
        public static Vector3 Lerp(Vector3 point1, Vector3 point2, float value)
        {
            value = Mathf.Clamp01(value);
            return new Vector3(point1.X + (point2.X - point1.X) * value, point1.Y + (point2.Y - point1.Y) * value, point1.Z + (point2.Z - point1.Z) * value);
        }

        /// <summary>
        /// Linearly interpolates between two points.
        /// 
        /// <br/>
        /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
        /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
        /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/> and <paramref name="point2"/>.
        /// </summary>
        /// <param name="point1">Start value, returned when value = 0.</param>
        /// <param name="point2">End value, returned when value = 1.</param>
        /// <param name="value">Value used to interpolate between point1 and point2.</param>
        /// <returns>Interpolated value, equals to <paramref name="point1"/> +
        /// (<paramref name="point2"/> - <paramref name="point1"/>) * <paramref name="value"/>. </returns>
        public static Vector3 LerpUnclamped(Vector3 point1, Vector3 point2, float value)
        {
            return new Vector3(point1.X + (point2.X - point1.X) * value, point1.Y + (point2.Y - point1.Y) * value, point1.Z + (point2.Z - point1.Z) * value);
        }

        /// <summary>
        /// Returns a vector that is made from the largest components of two vectors.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 GetMax(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Mathf.Max(lhs.X, rhs.X), Mathf.Max(lhs.Y, rhs.Y), Mathf.Max(lhs.Z, rhs.Z));
        }

        /// <summary>
        /// Returns a vector that is made from the smallest components of two vectors.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 GetMin(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Mathf.Min(lhs.X, rhs.X), Mathf.Min(lhs.Y, rhs.Y), Mathf.Min(lhs.Z, rhs.Z));
        }

        /// <summary>
        /// Calculate a position between the points specified by current and target, moving no 
        /// farther than the distance specified by maxDistanceDelta.
        /// </summary>
        /// <param name="current">The position to move from.</param>
        /// <param name="target">The position to move towards.</param>
        /// <param name="maxDistanceDelta">Distance to move <paramref name="current"/> per call.</param>
        /// <returns></returns>
        public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            float num = target.X - current.X;
            float num2 = target.Y - current.Y;
            float num3 = target.Z - current.Z;
            float num4 = num * num + num2 * num2 + num3 * num3;
            Vector3 result;
            if (num4 == 0f || (maxDistanceDelta >= 0f && num4 <= maxDistanceDelta * maxDistanceDelta))
            {
                result = target;
            }
            else
            {
                float num5 = (float)Math.Sqrt((double)num4);
                result = new Vector3(current.X + num / num5 * maxDistanceDelta, current.Y + num2 / num5 * maxDistanceDelta, current.Z + num3 / num5 * maxDistanceDelta);
            }
            return result;
        }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// <br/>When normalized, a vector keeps the same direction but its length is 1.0.
        /// <br/><br/>Note that this function will change the current vector.
        /// If you want to keep the current vector unchanged, use <see cref="normalized"/> variable.
        /// <br/>If this vector is too small to be normalized it will be set to zero.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 Normalize(Vector3 value)
        {
            float num = value.Magnitude;
            Vector3 result;
            if (num > 1E-05f)
            {
                result = value / num;
            }
            else
            {
                result = Vector3.zero;
            }
            return result;
        }

        /// <summary>
        /// Projects a vector onto another vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="onNormal"></param>
        /// <returns></returns>
        public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            float num = Vector3.GetDot(onNormal, onNormal);
            Vector3 result;
            if (num < Mathf.Epsilon)
            {
                result = Vector3.zero;
            }
            else
            {
                float num2 = Vector3.GetDot(vector, onNormal);
                result = new Vector3(onNormal.X * num2 / num, onNormal.Y * num2 / num, onNormal.Z * num2 / num);
            }
            return result;
        }

        /// <summary>
        /// Projects a vector onto a plane defined by a normal orthogonal to the plane.
        /// </summary>
        /// <param name="vector">The location of the vector above the plane.</param>
        /// <param name="planeNormal">The direction from the vector towards the plane.</param>
        /// <returns></returns>
        public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
        {
            float num = Vector3.GetDot(planeNormal, planeNormal);
            Vector3 result;
            if (num < Mathf.Epsilon)
            {
                result = vector;
            }
            else
            {
                float num2 = Vector3.GetDot(vector, planeNormal);
                result = new Vector3(vector.X - planeNormal.X * num2 / num, vector.Y - planeNormal.Y * num2 / num, vector.Z - planeNormal.Z * num2 / num);
            }
            return result;
        }

        /// <summary>
        /// Reflects a vector off the plane defined by a normal.
        /// </summary>
        /// <param name="inDirection"></param>
        /// <param name="inNormal"></param>
        /// <returns></returns>
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
        {
            float num = -2f * Vector3.GetDot(inNormal, inDirection);
            return new Vector3(num * inNormal.X + inDirection.X, num * inNormal.Y + inDirection.Y, num * inNormal.Z + inDirection.Z);
        }

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Scale(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        /// <summary>
        /// Calculates the signed angle between vectors from and to in relation to axis.
        /// </summary>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <param name="to">The vector to which the angular difference is measured.</param>
        /// <param name="axis">A vector around which the other vectors are rotated.</param>
        /// <returns></returns>
        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
        {
            float num = Vector3.GetAngle(from, to);
            float num2 = from.Y * to.Z - from.Z * to.Y;
            float num3 = from.Z * to.X - from.X * to.Z;
            float num4 = from.X * to.Y - from.Y * to.X;
            float num5 = Mathf.Sign(axis.X * num2 + axis.Y * num3 + axis.Z * num4);
            return num * num5;
        }

        /// <summary>
        /// Gradually changes a vector towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="deltaTime">The time since the last call to this function. By default <see cref="ITime.DeltaTime"/>.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        /// <returns></returns>
        public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
        {
            smoothTime = Mathf.Max(0.0001f, smoothTime);
            float num = 2f / smoothTime;
            float num2 = num * deltaTime;
            float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
            float num4 = current.X - target.X;
            float num5 = current.Y - target.Y;
            float num6 = current.Z - target.Z;
            Vector3 vector = target;
            float num7 = maxSpeed * smoothTime;
            float num8 = num7 * num7;
            float num9 = num4 * num4 + num5 * num5 + num6 * num6;
            if (num9 > num8)
            {
                float num10 = (float)Math.Sqrt((double)num9);
                num4 = num4 / num10 * num7;
                num5 = num5 / num10 * num7;
                num6 = num6 / num10 * num7;
            }
            target.X = current.X - num4;
            target.Y = current.Y - num5;
            target.Z = current.Z - num6;
            float num11 = (currentVelocity.X + num * num4) * deltaTime;
            float num12 = (currentVelocity.Y + num * num5) * deltaTime;
            float num13 = (currentVelocity.Z + num * num6) * deltaTime;
            currentVelocity.X = (currentVelocity.X - num * num11) * num3;
            currentVelocity.Y = (currentVelocity.Y - num * num12) * num3;
            currentVelocity.Z = (currentVelocity.Z - num * num13) * num3;
            float num14 = target.X + (num4 + num11) * num3;
            float num15 = target.Y + (num5 + num12) * num3;
            float num16 = target.Z + (num6 + num13) * num3;
            float num17 = vector.X - current.X;
            float num18 = vector.Y - current.Y;
            float num19 = vector.Z - current.Z;
            float num20 = num14 - vector.X;
            float num21 = num15 - vector.Y;
            float num22 = num16 - vector.Z;
            if (num17 * num20 + num18 * num21 + num19 * num22 > 0f)
            {
                num14 = vector.X;
                num15 = vector.Y;
                num16 = vector.Z;
                currentVelocity.X = (num14 - vector.X) / deltaTime;
                currentVelocity.Y = (num15 - vector.Y) / deltaTime;
                currentVelocity.Z = (num16 - vector.Z) / deltaTime;
            }
            return new Vector3(num14, num15, num16);
        }



        #endregion


        #region Operators

        /// <summary>
        /// Returns true if two vectors are approximately equal.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 point1, Vector3 point2)
        {
            float num = point1.X - point2.X;
            float num2 = point1.Y - point2.Y;
            float num3 = point1.Z - point2.Z;
            float num4 = num * num + num2 * num2 + num3 * num3;
            return num4 < 9.99999944E-11f;
        }

        /// <summary>
        /// Returns true if vectors are different.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3 point1, Vector3 point2)
        {
            return !(point1 == point2);
        }

        /// <summary>
        /// Returns a new Vector whose components are the sum of 2 Vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Returns a new Vector whose components are the sum of a Vector and a value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="value">Value to add to Vector components</param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 a, float value)
        {
            return new Vector3(a.X + value, a.Y + value, a.Z + value);
        }

        /// <summary>
        /// Returns a new Vector whose components are the difference between two Vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Returns a new Vector whose components are the difference between a Vector and a value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="value">Value to subtract from Vector components.</param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 a, float value)
        {
            return new Vector3(a.X - value, a.Y - value, a.Z - value);
        }

        /// <summary>
        /// Returns a new Vector whose components are the product of two Vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        /// <summary>
        /// Returns a new Vector whose components are the product of a Vector and a value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="value">Value to multiply Vector components by.</param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 a, float value)
        {
            return new Vector3(a.X * value, a.Y * value, a.Z * value);
        }

        /// <summary>
        /// Returns a new Vector whose components are the result of one Vector divided by another.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        /// <summary>
        /// Returns a new Vector whose components are the result of one Vector divided by a value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="value">Value to divide Vector components by.</param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 a, float value)
        {
            return new Vector3(a.X / value, a.Y / value, a.Z / value);
        }

        #endregion
    }
}
